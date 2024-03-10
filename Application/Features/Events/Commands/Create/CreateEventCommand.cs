﻿using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.Create
{
    public class CreateEventCommand:IRequest<CreatedEventResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string EventType { get; set; }
        public string Location { get; set; }

        public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreatedEventResponse>
        {
            private IEventRepository _eventRepository;
            private readonly IMapper _mapper;


            public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
            }

            public async Task<CreatedEventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
            {
                

                Event @event = _mapper.Map<Event>(request);
                @event.Id=Guid.NewGuid();

                var result=await _eventRepository.AddAsync(@event);

                CreatedEventResponse response =_mapper.Map<CreatedEventResponse>(result);

                return response;
              
            }
        }
    }
}