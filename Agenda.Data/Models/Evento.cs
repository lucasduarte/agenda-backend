using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Data.Models
{
    public class Evento : Base
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo deve conter entre 3 e 30 caracteres")]
        [MinLength(3, ErrorMessage = "O campo deve conter entre 3 e 30 caracteres")]
        public string Nome { get; set; }
        
        [MaxLength(200, ErrorMessage = "O campo deve conter no máximo 200 caracteres")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Inicio { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Fim { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Sala inválida")]
        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Responsável inválido")]
        public int ResponsavelId { get; set; }
        public Responsavel Responsavel { get; set; }
    }
}