using Application.Features.Events.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.Create
{
    public class CreateEventCommand:IRequest<CreatedEventResponse>,ITransactionRequest,ICacheRemoverRequest,ILoggableRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string EventType { get; set; }
        public string Location { get; set; }

        public string? CacheKey => "";
        public bool BypassCache => false;
        public string? CacheGroupKey => "getEvents";

        public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreatedEventResponse>
        {
            private IEventRepository _eventRepository;
            private readonly IMapper _mapper;
            private readonly EventBusinessRules _eventBusinessRules;


            public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, EventBusinessRules eventBusinessRules)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
                _eventBusinessRules = eventBusinessRules;
            }

            public async Task<CreatedEventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
            {
              
                await _eventBusinessRules.EventNameCannotBeDuplicatedWhenInserted(request.Name);
                
                Event @event = _mapper.Map<Event>(request);
                @event.Id=Guid.NewGuid();

                await _eventRepository.AddAsync(@event);


                CreatedEventResponse response =_mapper.Map<CreatedEventResponse>(@event);

                return response;
              
            }
        }
    }
}
