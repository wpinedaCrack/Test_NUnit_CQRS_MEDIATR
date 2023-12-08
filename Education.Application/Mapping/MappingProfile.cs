using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Curso, CursoDTO>();
        }
    }
}
