using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_Domain.Models;

namespace WeatherApp_DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(string email, string password);
        Task<User> GetUserByEmail(string email);

    }
}
