using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventosApplication.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [
            Required(ErrorMessage = "O campo {0} é obrigatório"),
            StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo entre 3 e 5a caracteres")
        ]
        public string Tema { get; set; }
        [
            Display(Name = "Quantidade de pessoas"),
            Range(1, 350, ErrorMessage = "{0} não pode ser menor que 1 e maior que 350")
        ]
        public int QtdPessoas { get; set; }
        [
            RegularExpression(@".*\.(gif|jpe?g|bmp|png)", ErrorMessage = "Não é uma imagem válida")
        ]
        public string ImagemURL { get; set; }
        [
            Required(ErrorMessage = "O campo {0} é obrigatório"),
            Phone(ErrorMessage = "O campos {0} está com o numero inválido")
        ]
        public string Telefone { get; set; }
        [
            Required(ErrorMessage = "O campo {0} é obrigatório"),
            Display(Name = "e-mail"),
            EmailAddress(ErrorMessage = "O campo {0} precisa ser um {0} válido")
        ]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}
