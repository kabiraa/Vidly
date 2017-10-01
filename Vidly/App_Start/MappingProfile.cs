using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Note: When createMap method is called, automapper uses reflection and maps the properties into destination
            //object from source object based on same names. This is also known as name convention based mapping.
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore()); //Note: A key property shouldn't be changed, thus mapping from DTO to domain object, this needs to be ignored.

            Mapper.CreateMap<Movie, MoviesDTO>();
            Mapper.CreateMap<MoviesDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}