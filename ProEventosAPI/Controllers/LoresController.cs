using Microsoft.AspNetCore.Mvc;
using ProEventosApplication.Contratos;
using ProEventosApplication.Dtos;

namespace ProEventosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotesController : ControllerBase
    {
        //private readonly ILoteService _loteService;

        //public LotesController(ILoteService loteServicee)
        //{
        //    _loteService = loteServicee;
        //}

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var eventos = await _loteService.GetAllLotesAsync(true);
                if (eventos == null)
                    return NoContent();

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, EventoDto model)
        //{
        //    try
        //    {
        //        var evento = await _eventoService.UpdateEvento(id, model);
        //        if (evento == null) return NoContent();

        //        return Ok(evento);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _eventoService.GetAllEventoByIdAsync(id, true);
                if (evento == null) return NoContent();

                return await _eventoService.DeleteEvento(id) ? Ok(new { message = "Deletado" }) : throw new Exception("Ocorreu um erro não expecificadp ao tentar deletar evento");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar eventos. Erro: {ex.Message}");
            }
        }
    }
}