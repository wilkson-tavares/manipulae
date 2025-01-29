using Manipulae.Domain.Responses.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Application.UseCases.Videos.GetById
{
    public interface IGetVideoByIdUseCase
    {
        Task<RegisteredVideoResponse> Execute(long id);
    }
}
