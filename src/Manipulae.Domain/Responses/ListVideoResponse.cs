using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Responses
{
    public class ListVideoResponse
    {
        public List<ShortVideoResponse> Expenses { get; set; } = new List<ShortVideoResponse>();
    }
}
