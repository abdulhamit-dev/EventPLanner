using Application.Features.Events.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EventAttendees.Queries.GetList
{
    public class GetListEventAttendeeQuery : IRequest<GetListResponse<GetListEventAttendeeListItemDto>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListEventQueryHandler : IRequestHandler<GetListEventAttendeeQuery, GetListResponse<GetListEventAttendeeListItemDto>>
        {
            private readonly IEventAttendeeRepository _eventAttendeeRepository;
            private readonly IMapper _mapper;

            public GetListEventQueryHandler(IEventAttendeeRepository eventAttendeeRepository, IMapper mapper)
            {
                _eventAttendeeRepository = eventAttendeeRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListEventAttendeeListItemDto>> Handle(GetListEventAttendeeQuery request, CancellationToken cancellationToken)
            {
                Paginate<EventAttendee> eventAttedees = await _eventAttendeeRepository.GetListAsync(
                     include: e => e.Include(e => e.Event),
                     index: request.PageRequest.PageIndex,
                     size: request.PageRequest.PageSize
                     );

                var response=_mapper.Map<GetListResponse<GetListEventAttendeeListItemDto>>(eventAttedees);

                return response;
            }
        }
    }
}
