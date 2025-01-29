using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Responses.Video
{
    public class ListVideoResponse
    {
        public List<ShortVideoResponse> data { get; set; } = new List<ShortVideoResponse>();
    }
}
