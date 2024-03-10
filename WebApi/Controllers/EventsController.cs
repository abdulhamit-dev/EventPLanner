using Application.Features.Events.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateEventCommand createEventCommand)
        {
            var response=await Mediator.Send(createEventCommand);

            return Ok(response);
        }
    }
}
