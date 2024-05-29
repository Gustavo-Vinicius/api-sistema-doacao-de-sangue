using AutoMapper;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Entities;

namespace Sistema_de_Doacao_de_Sangue.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Doador, DoadorDTO>().ReverseMap();
        }
    }
}