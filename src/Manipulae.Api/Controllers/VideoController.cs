using Manipulae.Application.UseCases.Videos.Delete;
using Manipulae.Application.UseCases.Videos.Filter;
using Manipulae.Application.UseCases.Videos.GetById;
using Manipulae.Application.UseCases.Videos.Register;
using Manipulae.Application.UseCases.Videos.Update;
using Manipulae.Domain.Requests.Video;
using Manipulae.Domain.Responses.Error;
using Manipulae.Domain.Responses.Video;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manipulae.Api.Controllers
{
    /// <summary>
    /// Controller responsible for managing videos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        /// <summary>
        /// Register a new video in the system
        /// </summary>
        /// <param name="req">Object containing the necessary data to create a new video register</param>
        /// <param name="useCase">Service</param>
        /// <returns>Return the registered object or an error on validation</returns>
        /// <response code="201">Succeeded</response>
        /// <response code="400">Error while creating the register</response>
        [HttpPost]
        [ProducesResponseType(typeof(RegisteredVideoResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(
            [FromServices] IRegisterVideoUseCase useCase,
            [FromBody] VideoRequest req)
        {
            var response = await useCase.Execute(req);

            return CreatedAtAction(nameof(GetVideoById), new { id = response.Id }, response);
        }

        /// <summary>
        /// Filter all videos
        /// </summary>
        /// <param name="req">Object containing the necessary data to filter an videos</param>
        /// <param name="useCase"></param>
        /// <returns>List of video entity</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListVideoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<IActionResult> FilterAllVideos(
            [FromServices] IFilterVideoUseCase useCase,
            [FromQuery] VideoRequest req)
        {
            var response = await useCase.Execute(req);

            if (response.data.Count != 0)
                return Ok(response);

            return NoContent();
        }

        /// <summary>
        /// Get an video by its Id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(RegisteredVideoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVideoById(
            [FromServices] IGetVideoByIdUseCase useCase,
            long id)
        {
            var response = await useCase.Execute(id);

            if (response.Id > 0)
                return Ok(response);

            return BadRequest();
        }

        /// <summary>
        /// Updates an video by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="req"></param>
        /// <param name="useCase"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(RegisteredVideoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(
            [FromRoute] long id,
            [FromBody] VideoRequest req,
            [FromServices] IUpdateVideoUseCase useCase)
        {
            var response = await useCase.Execute(id, req);

            return Ok(response);
        }

        /// <summary>
        /// Delete an video by id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteVideoUseCase useCase, [FromRoute] long id)
        {
            await useCase.Execute(id);

            return NoContent();
        }
    }
}
