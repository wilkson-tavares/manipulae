using Manipulae.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Domain.Interface.Video
{
    public interface IVideoWriteRepository
    {
        Task Add(VideoEntity video);
    }
}
