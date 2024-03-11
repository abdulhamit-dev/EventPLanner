using Application.Features.Events.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Events.Commands.Delete
{
    public class DeleteEventCommand:IRequest<DeletedEventResponse>
    {
        public Guid Id { get; set; }
        public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, DeletedEventResponse>
        {
            private readonly IMapper _mapper;
            private readonly IEventRepository _eventRepository;

            public DeleteEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
            {
                _mapper = mapper;
                _eventRepository = eventRepository;
            }

            public async Task<DeletedEventResponse> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
            {

                Event @event = await _eventRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);


                await _eventRepository.DeleteAsync(@event);

                var response = _mapper.Map<DeletedEventResponse>(@event);

                return response;
            }
        }
    }
}
