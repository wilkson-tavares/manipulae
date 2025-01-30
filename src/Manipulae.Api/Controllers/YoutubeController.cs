using Manipulae.Application.UseCases.Videos.Delete;
using Manipulae.Application.UseCases.Videos.Filter;
using Manipulae.Application.UseCases.Videos.GetById;
using Manipulae.Application.UseCases.Videos.Register;
using Manipulae.Application.UseCases.Videos.Update;
using Manipulae.Application.UseCases.Youtube;
using Manipulae.Domain.Requests.Video;
using Manipulae.Domain.Responses.Error;
using Manipulae.Domain.Responses.Video;
using Microsoft.AspNetCore.Mvc;

namespace Manipulae.Api.Controllers
{
    /// <summary>
    /// Controller responsible for communicating youtube api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        /// <summary>
        /// Filter videos in youtube api
        /// </summary>
        /// <param name="req">Object containing the necessary data to filter an videos</param>
        /// <param name="useCase"></param>
        /// <returns>List of video entity</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListVideoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Filter(
            [FromServices] IYoutubeUseCase useCase,
            [FromQuery] VideoRequest req)
        {
            var response = await useCase.Execute(req);

            if (response.data.Count != 0)
                return Ok(response);

            return NoContent();
        }
    }
}
