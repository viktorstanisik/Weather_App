using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_Domain.Models;
using WeatherApp_Service.Models;

namespace WeatherApp_Service.Interfaces
{
    public interface IUserService
    {
        Task<int> Create(UserDto userDtoModel);
        Task<JwtResponseModel> Login(LoginModel userDtoModel);
    }
}
