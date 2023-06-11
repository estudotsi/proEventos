using ProEventosApplication.Dtos;
using System.Threading.Tasks;

namespace ProEventosApplication.Contratos
{
    public interface IEventoService
    {
        Task<EventoDto> AddEventos(EventoDto model);
        Task<EventoDto> UpdateEvento(int eventoId, EventoDto model);
        Task<bool> DeleteEvento(int eventoId);

        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false);

        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        
        Task<EventoDto> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
