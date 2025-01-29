using AutoMapper;
using Manipulae.Domain.Interface.Video;
using Manipulae.Domain.Responses.Video;
using Manipulae.Exception.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Application.UseCases.Videos.GetById
{
    internal class GetVideoByIdUseCase : IGetVideoByIdUseCase
    {
        private readonly IVideoReadRepository _repository;
        private readonly IMapper _mapper;

        public GetVideoByIdUseCase(
            IVideoReadRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RegisteredVideoResponse> Execute(long id)
        {
            var result = await _repository.GetByIdAsync(id);

            return result is null
                ? throw new NotFoundException("Video Not Found")
                : _mapper.Map<RegisteredVideoResponse>(result);
        }
    }
}
