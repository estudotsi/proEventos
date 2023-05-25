﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventosDomain
{
	public class Lote
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public DateTime? DataInicio { get; set; }
		public DateTime? Datafim { get; set; }
		public int Quantidade { get; set; }
		public int EventoId { get; set; }
		public Evento Evento { get; set; }
	}
}
