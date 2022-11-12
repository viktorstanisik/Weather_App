using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeatherApp_DataAccess.Interfaces;
using WeatherApp_Domain;
using WeatherApp_Domain.Models;
using WeatherApp_Shared;

namespace WeatherApp_DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WeatherAppDbContext _dbContext;
        private readonly IConfiguration _configuration;


        public UserRepository(WeatherAppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<User> CreateUser(User userModel)
        {
            var userExist = await _dbContext.User.FirstOrDefaultAsync(x => x.Email == userModel.Email);
            if(userExist != null) throw new Exception(ErrorMessages.UserAlredyExist);

            try
            {
                var user = new User()
                {
                    Email = userModel.Email,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Password = userModel.Password,
                };

                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return user;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUser(string email, string password)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email);
        }



    }
}
