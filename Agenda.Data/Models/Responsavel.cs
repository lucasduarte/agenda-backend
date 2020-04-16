using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Data.Models
{
    public class Responsavel : Base
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo deve conter entre 3 e 30 caracteres")]
        [MinLength(3, ErrorMessage = "O campo deve conter entre 3 e 30 caracteres")]

        public string Nome { get; set; }

        public IList<Evento> Eventos { get; set; } = new List<Evento>();
    }
}