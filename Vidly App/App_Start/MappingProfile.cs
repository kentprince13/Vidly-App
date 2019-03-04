using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_App.DTOs;
using Vidly_App.Models;

namespace Vidly_App.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movies, MoviesDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<MembershipType, MembershipDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MoviesDto, Movies>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipDto, MembershipType>();
            Mapper.CreateMap<GenreDto, Genre>();

        }
    }
}