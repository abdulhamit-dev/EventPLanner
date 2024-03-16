using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Events.Queries.GetList
{
    public class GetListEventQuery : IRequest<GetListResponse<GetListEventListItemDto>>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public string CacheKey => $"GetListEventQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

        public bool BypassCache { get; }

        public TimeSpan? SlidingExpiration { get; }

        public string? CacheGroupKey => "getEvents";

        public class GetListEventQueryHandler : IRequestHandler<GetListEventQuery, GetListResponse<GetListEventListItemDto>>
        {
            private readonly IEventRepository _eventRepository;
            private readonly IMapper _mapper;
            
            public GetListEventQueryHandler(IEventRepository eventRepository, IMapper mapper)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListEventListItemDto>> Handle(GetListEventQuery request, CancellationToken cancellationToken)
            {
                Paginate<Event> events = await _eventRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken
                    );
                GetListResponse<GetListEventListItemDto> getListResponse = _mapper.Map<GetListResponse<GetListEventListItemDto>>(events);

                return getListResponse;
            }
        }
    }
}
