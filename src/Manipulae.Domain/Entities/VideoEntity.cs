using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Entities
{
    public class VideoEntity
    {
        public long Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public TimeSpan Duracao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Canal { get; set; } = string.Empty;
        public bool Excluido { get; set; }
    }
}
