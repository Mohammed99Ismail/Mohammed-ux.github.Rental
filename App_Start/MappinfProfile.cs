using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenMovie.Models;
using VenMovie.Dtos;
using AutoMapper;

namespace VenMovie.App_Start
{
    public class MappinfProfile:Profile
    {
        public MappinfProfile()
        {
            //Domain to DTO
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            //DTO to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            
        }
    }
}