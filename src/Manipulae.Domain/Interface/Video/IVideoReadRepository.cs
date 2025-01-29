using Manipulae.Domain.Entities;
using Manipulae.Domain.Requests.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Interface.Video
{
    public interface IVideoReadRepository
    {
        Task<IEnumerable<VideoEntity>> Filter(VideoRequest request);
    }
}
