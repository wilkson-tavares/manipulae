using AutoMapper;
using Manipulae.Domain.Entities;
using Manipulae.Domain.Interface;
using Manipulae.Domain.Interface.Security.Cryptography;
using Manipulae.Domain.Interface.Security.Tokens;
using Manipulae.Domain.Interface.User;
using Manipulae.Domain.Requests.Users;
using Manipulae.Domain.Responses.Users;
using Manipulae.Exception;
using Manipulae.Exception.ExceptionBase;
using FluentValidation.Results;

namespace Manipulae.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public RegisterUserUseCase(
            IMapper mapper, 
            IPasswordEncripter passwordEncripter,
            IUserReadRepository userReadRepository,
            IUnitOfWork unitOfWork,
            IUserWriteRepository userWriteRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _unitOfWork = unitOfWork;
            _tokenGenerator = jwtTokenGenerator;
        }

        public async Task<RegisteredUserResponse> Execute(UserRequest req)
        {
            await Validate(req);

            var user = _mapper.Map<UserEntity>(req);
            user.Password = _passwordEncripter.Encrypt(req.Password);
            user.UserId = Guid.NewGuid();

            await _userWriteRepository.Add(user);

            await _unitOfWork.Commit();

            return new RegisteredUserResponse
            {
                Name = user.Name,
                Token = _tokenGenerator.Generate(user)
            };
        }

        private async Task Validate(UserRequest req)
        {
            var result = new UserValidator().Validate(req);

            var isEmailValid = await _userReadRepository.ExistUserWithEmail(req.Email);
            if (isEmailValid)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, "Email already registered"));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
