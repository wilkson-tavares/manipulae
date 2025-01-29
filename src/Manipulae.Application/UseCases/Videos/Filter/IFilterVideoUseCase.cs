using Manipulae.Domain.Requests.Video;
using Manipulae.Domain.Responses.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Application.UseCases.Videos.Filter
{
    public interface IFilterVideoUseCase
    {
        Task<ListVideoResponse> Execute(VideoRequest req);
    }
}
