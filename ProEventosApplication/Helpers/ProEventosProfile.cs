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
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<Palestrante, Palestrante>().ReverseMap();
        }
    }
}
