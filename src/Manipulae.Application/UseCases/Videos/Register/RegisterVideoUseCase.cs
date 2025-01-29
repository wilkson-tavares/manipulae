using AutoMapper;
using Manipulae.Domain.Entities;
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

namespace Manipulae.Application.UseCases.Videos.Register
{
    public class RegisterVideoUseCase : IRegisterVideoUseCase
    {
        private readonly IVideoWriteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterVideoUseCase(
            IVideoWriteRepository repository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RegisteredVideoResponse> Execute(VideoRequest req)
        {
            Validate(req);

            var expenseEntity = _mapper.Map<VideoEntity>(req);

            await _repository.Add(expenseEntity);

            await _unitOfWork.Commit();

            return _mapper.Map<RegisteredVideoResponse>(expenseEntity);
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
