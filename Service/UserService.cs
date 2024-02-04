using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjekatSI.Data;
using ProjekatSI.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjekatSI.Service
{
    public class UserService : IUserInterface
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;
        public UserService(DatabaseContext databaseContext,IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public async Task<bool> CheckPassword(string password)
        {
           var users =await _databaseContext.Users.ToListAsync();
            var provera = false;
            foreach (var user in users)
            {
                if (user.Password == password) provera = true;                
            }

            return provera;
        }

        public async Task DeleteUser(User user)
        {
         
            var oglasi = await _databaseContext.Oglasi.Where(o => o.UserId == user.Id).ToListAsync();
            _databaseContext.Oglasi.RemoveRange(oglasi);


            var pitanja = await _databaseContext.Questions.Where(q => q.UserId == user.Id).ToListAsync();
            _databaseContext.Questions.RemoveRange(pitanja);
            var odgovori = await _databaseContext.Answers.Where(a => a.UserId == user.Id).ToListAsync();
            _databaseContext.Answers.RemoveRange(odgovori);

            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Auth:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _databaseContext.Users.Include( a => a.Oglasi).ToListAsync();
        }

        public async Task<User?> GetByUserName(string Email)
        {
            return await _databaseContext.Users.Include(x=>x.Oglasi).Where(x => x.Email == Email).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _databaseContext.Users.Include(x => x.Oglasi).Where(x =>x.Id == id).FirstOrDefaultAsync();
        }

        public string HashPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return String.Empty;
            }

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }

        public async Task RegisterUser(User user)
        {
            _databaseContext.Users.Add(user);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _databaseContext.Users.FindAsync(user.Id);

            if (existingUser == null)
            {
                return;
            }

            existingUser.Email = user.Email;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Password = user.Password;

            await _databaseContext.SaveChangesAsync();
        }
    }
}
