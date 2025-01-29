using AutoMapper;
using Manipulae.Domain.Entities;
using Manipulae.Domain.Requests.Users;
using Manipulae.Domain.Requests.Video;
using Manipulae.Domain.Responses.Users;
using Manipulae.Domain.Responses.Video;


namespace Manipulae.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<UserRequest, UserEntity>()
                .ForMember(dest => dest.Password, config => config.Ignore());

            CreateMap<VideoRequest, VideoEntity>();
        }

        private void EntityToResponse()
        {
            CreateMap<VideoEntity, RegisteredVideoResponse>();

            CreateMap<VideoEntity, ShortVideoResponse>();

            CreateMap<UserEntity, UserProfileResponse>();
        }
    }
}
