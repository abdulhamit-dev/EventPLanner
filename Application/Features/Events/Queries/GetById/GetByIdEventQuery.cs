using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Events.Queries.GetById
{
    public class GetByIdEventQuery:IRequest<GetByIdEventResponse>
    {
        public Guid Id { get; set; }

        public class GetByIdEventQueryHandler : IRequestHandler<GetByIdEventQuery, GetByIdEventResponse>
        {
            private readonly IMapper _mapper;
            private readonly IEventRepository _eventRepository;

            public GetByIdEventQueryHandler(IMapper mapper, IEventRepository eventRepository)
            {
                _mapper = mapper;
                _eventRepository = eventRepository;
            }

            public async Task<GetByIdEventResponse> Handle(GetByIdEventQuery request, CancellationToken cancellationToken)
            {
                var @event= await _eventRepository.GetAsync(predicate: e => e.Id == request.Id,cancellationToken:cancellationToken);

                GetByIdEventResponse response = _mapper.Map<GetByIdEventResponse>(@event);

                return response;
            }
        }


       
    }
}
