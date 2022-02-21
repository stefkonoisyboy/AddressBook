using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Models
{
    public class Objective
    {
        public int Id { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public DateTime VisitedOn { get; set; }

        public string VisitedById { get; set; }

        public virtual ApplicationUser VisitedBy { get; set; }
    }
}
