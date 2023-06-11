using AutoMapper;
using ProEventosApplication.Dtos;
using ProEventosDomain;

namespace ProEventosApplication.Helpers
{
    public class ProEventosProfile : Profile
    {
        public ProEventosProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
        }
    }
}
