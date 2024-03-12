using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EventAttendee:Entity<Guid>
    {
        public Guid EventId { get; set; }
        public Guid AttendeeId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public EventAttendeeState AttendanceState { get; set; }

        public virtual Event? Event {  get; set; }
        public virtual Attendee? Attendee { get; set; }

        public EventAttendee()
        {
            
        }

        public EventAttendee(Guid id, Guid eventId,Guid attendeeId):this()
        {
            Id= id;
            EventId = eventId;
            AttendeeId = attendeeId;
        }
    }
}
