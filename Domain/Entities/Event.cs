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
        public int CategoryId { get; set; }
        public int? SpeakerId { get; set; }
        public int? RoomId { get; set; }
        public string Website { get; set; }
        public string EventType { get; set; }

    }
}
