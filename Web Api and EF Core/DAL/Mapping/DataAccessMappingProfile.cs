using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            //cory sarquma entity(aranc revers map)
            CreateMap<Core.Entites.Homework, Entities.Homework>().ReverseMap();
        }

    }
}
