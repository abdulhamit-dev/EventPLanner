using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.Update
{
    public class UpdateEventCommand : IRequest<UpdatedEventResponse>,ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string EventType { get; set; }
        public string Location { get; set; }

        public string? CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "getEvents";

        public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdatedEventResponse>
        {
            private readonly IMapper _mapper;
            private readonly IEventRepository _eventRepository;

            public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
            {
                _mapper = mapper;
                _eventRepository = eventRepository;
            }

            public async Task<UpdatedEventResponse> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
            {

                Event @event = await _eventRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);

                @event = _mapper.Map(request, @event);

                 await _eventRepository.UpdateAsync(@event);

                var response = _mapper.Map<UpdatedEventResponse>(@event);
                return response;
            }
        }
    }
}
