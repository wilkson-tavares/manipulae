using AutoMapper;
using Manipulae.Application.UseCases.Videos.Filter;
using Manipulae.Application.UseCases.Videos.Register;
using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Service.LoggedUser;
using Manipulae.Domain.Interface.Service.YoutubeApi;
using Manipulae.Domain.Interface.User;
using Manipulae.Domain.Requests.Users;
using Manipulae.Domain.Requests.Video;
using Manipulae.Domain.Responses.Users;
using Manipulae.Domain.Responses.Video;
using Manipulae.Exception.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Manipulae.Application.UseCases.Youtube
{
    public class YoutubeUseCase : IYoutubeUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegisterVideoUseCase _registerVideoUseCase;
        private readonly IFilterVideoUseCase _filterVideoUseCase;
        private readonly IYoutubeService _youtubeService;
        private readonly IMapper _mapper;

        public YoutubeUseCase(
            IUnitOfWork unitOfWork, 
            IRegisterVideoUseCase registerVideoUseCase, 
            IFilterVideoUseCase filterVideoUseCase,
            IYoutubeService youtubeService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _registerVideoUseCase = registerVideoUseCase;
            _filterVideoUseCase = filterVideoUseCase;
            _youtubeService = youtubeService;
            _mapper = mapper;
        }

        public async Task<ListVideoResponse> Execute(VideoRequest req)
        {
            var listVideos = await _youtubeService.GetVideosAsync(req);
            if (!listVideos.data.Any())
                throw new NotFoundException("Videos Not Found");

            InsertVideos(listVideos);

            return listVideos;
        }

        private void InsertVideos(ListVideoResponse listVideos)
        {
            foreach (var v in listVideos.data)
            {
                var req = _mapper.Map<VideoRequest>(v);
                _registerVideoUseCase.Execute(req);
            }
        }
    }
}
