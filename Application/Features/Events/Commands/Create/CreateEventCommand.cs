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

        public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreatedEventResponse>
        {
            public Task<CreatedEventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
            {
                CreatedEventResponse response = new();
                response.Name = request.Name;
                response.Id = new Guid();
                return null;
              
            }
        }
    }
}
