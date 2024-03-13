using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EventAttendees.Queries.GetList
{
    public class GetListEventAttendeeListItemDto
    {
        public string EventName { get; set; }
        public string AttendeeName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public EventAttendeeState AttendanceState { get; set; }
    }
}
