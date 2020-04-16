using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Data.Models
{
    public class Sala : Base
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(20, ErrorMessage = "O campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "O campo deve conter entre 3 e 20 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool? Ativa { get; set; }

        public virtual IList<Evento> Eventos { get; set; } = new List<Evento>();
    }
}