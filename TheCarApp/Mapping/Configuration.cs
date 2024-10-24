using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Data.Models;



namespace Mapping
{
    public class Configuration
    {
        public IMapper Config() { 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Administrator, AdministratorDTO>();
                cfg.CreateMap<AdministratorDTO, Administrator>();
                cfg.CreateMap<Car, CarDTO>();
                cfg.CreateMap<CarDTO, Car>();
                cfg.CreateMap<News, CarNewsDTO>();
                cfg.CreateMap<CarNewsDTO, News>();
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<CommentDTO, Comment>();
                cfg.CreateMap<CarExtra, ExtraDTO>();
                cfg.CreateMap<ExtraDTO, CarExtra>();
                cfg.CreateMap<CarPicture, PictureDTO>();
                cfg.CreateMap<PictureDTO, CarPicture>();
                cfg.CreateMap<Rental, RentACarDTO>();
                cfg.CreateMap<RentACarDTO, Rental>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();

            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
