using AutoMapper;
using Microsoft.Extensions.Logging;
using ProEventosApplication.Contratos;
using ProEventosApplication.Dtos;
using ProEventosDomain;
using ProEventosPersistence.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventosApplication.Service
{
    public class LoteService : ILoteService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly ILotePersist _lotePersist;
        private readonly IMapper _mapper;

        public LoteService(IGeralPersist geralPersist, ILotePersist lotePersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _lotePersist = lotePersist;
            _mapper = mapper;
        }

        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                _geralPersist.Add<Evento>(evento);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _lotePersist.GetAllEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);

                if (evento == null)

                    return null;

                model.Id = evento.Id;

                _mapper.Map(model, evento);

                _geralPersist.Update<Evento>(evento);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetAllEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeleteLote(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersist.GetLoteByIdsAsync(eventoId, loteId);

                if (lote == null)

                    throw new Exception("Lote para deletar não encontrado");

                _geralPersist.Delete<Lote>(lote);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

		public async Task<LoteDto[]> GetLoteByEventoIdAsync(int eventoId)
		{
			try
			{
                var lotes = await _lotePersist.GetLotesByEventoIdAsync(eventoId);
				if (lotes == null)
					return null;

                var resultado = _mapper.Map<LoteDto[]>(lotes);

                return resultado;
            }
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<LoteDto> GetLoteByIdsAsync(int eventoId, int loteId)
		{
			try
			{
                var lote = await _lotePersist.GetLoteByIdsAsync(eventoId, loteId);
				if (lote == null)
					return null;

                var resultado = _mapper.Map<LoteDto>(lote);

				return resultado;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

    }
}
