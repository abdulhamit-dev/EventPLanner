using Application.Features.Events.Commands.Create;
using Application.Features.Events.Commands.Delete;
using Application.Features.Events.Commands.Update;
using Application.Features.Events.Queries.GetById;
using Application.Features.Events.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : BaseController
    {

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]CreateEventCommand createEventCommand)
        {
            var response=await Mediator.Send(createEventCommand);

            return Ok(response);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListEventQuery getListEventQuery =new() { PageRequest = pageRequest };
            GetListResponse<GetListEventListItemDto> getListResponse = await Mediator.Send(getListEventQuery);

            return Ok(getListResponse);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdEventQuery getByIdEventQuery = new() { Id = id };

            GetByIdEventResponse getByIdEventResponse = await Mediator.Send(getByIdEventQuery);

            return Ok(getByIdEventResponse);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
        {
            var response = await Mediator.Send(updateEventCommand);

            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedEventResponse deletedEventResponse=await Mediator.Send(new DeleteEventCommand { Id = id });

            return Ok(deletedEventResponse);
        }
    }
}
