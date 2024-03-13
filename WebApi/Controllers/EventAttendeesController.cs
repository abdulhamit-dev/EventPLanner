using Application.Features.EventAttendees.Queries.GetList;
using Application.Features.EventAttendees.Queries.GetListByDynamic;
using Application.Features.Events.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAttendeesController : BaseController
    {
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListEventAttendeeQuery getListEventAttendeeQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListEventAttendeeListItemDto> getListResponse = await Mediator.Send(getListEventAttendeeQuery);

            return Ok(getListResponse);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
        {
            GetListByDynamicEvenAttendeeQuery getListByDynamicEvenAttendeeQuery = new() { PageRequest = pageRequest,DynamicQuery=dynamicQuery };

            GetListResponse<GetListByDynamicEventAttendeeListItemDto> getListResponse = await Mediator.Send(getListByDynamicEvenAttendeeQuery);

            return Ok(getListResponse);
        }
    }
}
