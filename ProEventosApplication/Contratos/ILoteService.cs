using ProEventosApplication.Dtos;
using System.Threading.Tasks;

namespace ProEventosApplication.Contratos
{
    public interface ILoteService
    {
       
        Task<LoteDto> SaveLote(int eventoId, LoteDto[] models);
        Task<bool> DeleteEvento(int eventoId, int loteId);
        Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId);
        Task<LoteDto> GetLoteByIdsAsync(int eventoId, int intLoteId);
    }
}
