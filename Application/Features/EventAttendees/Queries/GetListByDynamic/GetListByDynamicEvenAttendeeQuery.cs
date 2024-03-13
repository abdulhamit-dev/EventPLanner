using Application.Features.EventAttendees.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EventAttendees.Queries.GetListByDynamic
{


    public class GetListByDynamicEvenAttendeeQuery : IRequest<GetListResponse<GetListByDynamicEventAttendeeListItemDto>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }
        public class GetListByDynamicEvenAttendeeQueryHandler : IRequestHandler<GetListByDynamicEvenAttendeeQuery, GetListResponse<GetListByDynamicEventAttendeeListItemDto>>
        {
            private readonly IEventAttendeeRepository _eventAttendeeRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicEvenAttendeeQueryHandler(IEventAttendeeRepository eventAttendeeRepository, IMapper mapper)
            {
                _eventAttendeeRepository = eventAttendeeRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListByDynamicEventAttendeeListItemDto>> Handle(GetListByDynamicEvenAttendeeQuery request, CancellationToken cancellationToken)
            {
                Paginate<EventAttendee> eventAttedees = await _eventAttendeeRepository.GetListByDynamicAsync(
                    dynamic: request.DynamicQuery,
                     include: e => e.Include(e => e.Event),
                     index: request.PageRequest.PageIndex,
                     size: request.PageRequest.PageSize
                     );

                var response = _mapper.Map<GetListResponse<GetListByDynamicEventAttendeeListItemDto>>(eventAttedees);

                return response;
            }
        }
    }
}
