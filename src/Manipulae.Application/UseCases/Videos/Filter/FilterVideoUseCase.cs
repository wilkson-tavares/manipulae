using AutoMapper;
using Manipulae.Domain.Interface.Video;
using Manipulae.Domain.Requests.Video;
using Manipulae.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Application.UseCases.Videos.Filter
{
    public class FilterVideoUseCase : IFilterVideoUseCase
    {
        private readonly IVideoReadRepository _repository;
        private readonly IMapper _mapper;

        public FilterVideoUseCase(
            IVideoReadRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListVideoResponse> Execute(VideoRequest req)
        {
            var result = await _repository.Filter(req);

            return new ListVideoResponse
            {
                data = _mapper.Map<List<ShortVideoResponse>>(result)
            };
        }
    }
}
