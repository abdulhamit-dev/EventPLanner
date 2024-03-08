using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EventAttendee:Entity<Guid>
    {
        public int AttendeeId { get; set; }
        public int? TicketId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AttendanceStatus { get; set; }
    }
}
