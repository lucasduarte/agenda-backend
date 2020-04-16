using System;

namespace Agenda.Data.Models
{
    public class Base
    {
        public int? Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}