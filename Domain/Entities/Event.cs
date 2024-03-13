using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SpeakerId { get; set; }
        public Guid? RoomId { get; set; }
        public string Website { get; set; }
        public string EventType { get; set; }

        //public virtual Category? Category { get; set; }
        //public virtual Speaker? Speaker { get; set; }
        //public virtual Room? Room { get; set; }
        public virtual ICollection<EventAttendee>? EventAttendees { get; set; }

        public Event()
        {
            EventAttendees = new HashSet<EventAttendee>();
        }
    }
}
