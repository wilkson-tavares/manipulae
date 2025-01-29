using Manipulae.Domain.Requests.Login;
using Manipulae.Domain.Responses.Users;
using Microsoft.AspNetCore.Mvc;
using Manipulae.Domain.Responses.Error;
using Manipulae.Application.UseCases.Login;

namespace Manipulae.Api.Controllers
{
    /// <summary>
    /// Controller responsible for managing login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Do login
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(RegisteredUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginAsync(
            [FromServices] IDoLoginUseCase useCase,
            [FromBody] LoginRequest req)
        {
            var response = await useCase.Execute(req);

            return Ok(response);
        }
    }
}
