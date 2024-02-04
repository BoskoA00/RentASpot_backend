<<<<<<< HEAD
﻿using ProjekatSI.Data;

namespace ProjekatSI.Interface
{
    public interface IUserInterface
    {
        Task<List<User>> GetAllUsersAsync();
        Task RegisterUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        string GenerateToken(User user);
        string HashPassword(string password);
        Task <User?> GetByUserName(string userName);
        Task <User?> GetUserById(int id);
        Task <bool> CheckPassword(string password);
    } 
}
=======
﻿using ProjekatSI.Data;

namespace ProjekatSI.Interface
{
    public interface IUserInterface
    {
        Task<List<User>> GetAllUsersAsync();
        Task RegisterUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        string GenerateToken(User user);
        string HashPassword(string password);
        Task <User?> GetByUserName(string userName);
        Task <User?> GetUserById(int id);
        Task <bool> CheckPassword(string password);
    } 
}
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
