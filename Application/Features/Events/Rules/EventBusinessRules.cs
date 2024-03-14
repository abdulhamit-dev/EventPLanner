using Application.Features.Events.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Events.Rules
{
    public class EventBusinessRules:BaseBusinessRules
    {
        private readonly IEventRepository _eventRepository;

        public EventBusinessRules(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task EventNameCannotBeDuplicatedWhenInserted(string name)
        {
            var result=await _eventRepository.GetAsync(predicate:e=>e.Name.ToLower() == name.ToLower());
            if (result != null)
            {
                throw new BusinessException(EventMessages.EventNameExists);
            }
        }
    }
}
