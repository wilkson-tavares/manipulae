using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Requests.Video
{
    public class VideoRequest
    {
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public TimeSpan? Duracao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string? Descricao { get; set; }
        public string? Canal { get; set; }
        public string? q { get; set; }
    }
}
