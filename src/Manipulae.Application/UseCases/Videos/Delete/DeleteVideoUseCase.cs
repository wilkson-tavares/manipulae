using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Video;
using Manipulae.Exception.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Application.UseCases.Videos.Delete
{
    public class DeleteVideoUseCase : IDeleteVideoUseCase
    {
        private readonly IVideoDeleteRepository _repository;
        private readonly IVideoReadRepository _readRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVideoUseCase(
            IVideoDeleteRepository repository, 
            IVideoReadRepository readRepository, 
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            _ = await _readRepository.GetByIdAsync(id) ??
                throw new NotFoundException("Video Not Found");

            await _repository.Delete(id);

            await _unitOfWork.Commit();
        }
    }
}
