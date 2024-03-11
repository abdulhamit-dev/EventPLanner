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

namespace Application.Features.Events.Profiles
{
    public class MappingProfiles:Profile
    {

        public MappingProfiles()
        {
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, CreatedEventResponse>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, UpdatedEventResponse>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap();
            CreateMap<Event, DeletedEventResponse>().ReverseMap();
            CreateMap<Event, GetListEventListItemDto>().ReverseMap();
            CreateMap<Event, GetByIdEventResponse>().ReverseMap();
            CreateMap<Paginate<Event>, GetListResponse<GetListEventListItemDto>>().ReverseMap();
        }
    }
}
