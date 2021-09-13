using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Mapping
{
    public class ApiMappingProfile : Profile
    {

        public ApiMappingProfile()
        {
            CreateMap<Contracts.HomeworkCreate, Core.Entites.Homework>();
            CreateMap<Contracts.Homework,Core.Entites.Homework>().ReverseMap();
        }
    }
}
