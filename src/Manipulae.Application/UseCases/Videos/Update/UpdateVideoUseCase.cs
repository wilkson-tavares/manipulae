using AutoMapper;
using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Video;
using Manipulae.Domain.Requests.Video;
using Manipulae.Domain.Responses;
using Manipulae.Exception.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Application.UseCases.Videos.Update
{
    internal class UpdateVideoUseCase : IUpdateVideoUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideoUpdateRepository _repository;
        private readonly IVideoReadRepository _readRepository;

        public UpdateVideoUseCase(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IVideoUpdateRepository repository,
            IVideoReadRepository readRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _readRepository = readRepository;
        }

        public async Task<RegisteredVideoResponse> Execute(long id, VideoRequest req)
        {
            Validate(req);

            var videoEntity = await _readRepository.GetByIdAsync(id) ??
                throw new NotFoundException("Video Not Found");

            _mapper.Map(req, videoEntity);

            _repository.Update(videoEntity);

            await _unitOfWork.Commit();

            return _mapper.Map<RegisteredVideoResponse>(videoEntity);
        }

        private static void Validate(VideoRequest req)
        {
            var validator = new VideoValidator();

            var result = validator.Validate(req);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
