﻿using ProEventosDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventosApplication.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string Datafim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
    }
}
