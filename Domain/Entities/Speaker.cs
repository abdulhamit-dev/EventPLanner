using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Speaker:Entity<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Website { get; set; }
    }
}
