using Manipulae.Application.UseCases.Users.ChangePassword;
using Manipulae.Application.UseCases.Users.Delete;
using Manipulae.Application.UseCases.Users.Profile;
using Manipulae.Application.UseCases.Users.Register;
using Manipulae.Application.UseCases.Users.Update;
using Manipulae.Domain.Requests.Users;
using Manipulae.Domain.Responses.Error;
using Manipulae.Domain.Responses.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manipulae.Api.Controllers
{
    /// <summary>
    /// Controller responsible for managing users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Register an user
        /// </summary>
        /// <param name="req"></param>
        /// <param name="useCase"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(RegisteredUserResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] UserRequest req
            )
        {
            var response = await useCase.Execute(req);

            return Created(string.Empty, response);
        }


        /// <summary>
        /// Get user profile
        /// </summary>
        /// <param name="useCase"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(UserProfileResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfileAsync([FromServices] IGetUserProfileUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }

        /// <summary>
        /// Update user profile informations
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("profile")]
        [Authorize]
        [ProducesResponseType(typeof(UserProfileResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserProfileAsync(
            [FromServices] IUpdateUserUseCase useCase,
            [FromBody] UpdateUserRequest req)
        {
            var response = await useCase.Execute(req);

            return Ok(response);
        }

        /// <summary>
        /// update user´s password
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("change-password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePasswordAsync(
            [FromServices] IChangePasswordUseCase useCase,
            [FromBody] ChangePasswordRequest req)
        {
            await useCase.Execute(req);

            return NoContent();
        }

        /// <summary>
        /// Delete user and its expenses
        /// </summary>
        /// <param name="useCase"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProfileAsync([FromServices] IDeleteUserAccountUseCase useCase)
        {
            await useCase.Execute();
            return NoContent();
        }
    }
}
