using Application.Features.EventAttendees.Queries.GetList;
using Application.Features.EventAttendees.Queries.GetListByDynamic;
using Application.Features.Events.Commands.Create;
using Application.Features.Events.Commands.Delete;
using Application.Features.Events.Commands.Update;
using Application.Features.Events.Queries.GetById;
using Application.Features.Events.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EventAttendees.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<EventAttendee, GetListEventAttendeeListItemDto>()
                .ForMember(destinationMember:e=>e.EventName,memberOptions:opt=>opt.MapFrom(e=>e.Event.Name)).ReverseMap();
            CreateMap<Paginate<EventAttendee>, GetListResponse<GetListEventAttendeeListItemDto>>().ReverseMap();
            CreateMap<Paginate<EventAttendee>, GetListResponse<GetListByDynamicEventAttendeeListItemDto>>().ReverseMap();
        }
    }
}
