using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp_Domain.Models;

namespace WeatherApp_Shared.Helpers
{
    public static class Mapper
    {
        //od domain u DTO
        public static UserDto ToDto(this User domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<UserDto>(domainModel);
        }

        //od DTO u domain
        public static User ToDomain(this UserDto domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, User>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<User>(domainModel);
        }
    }
}
