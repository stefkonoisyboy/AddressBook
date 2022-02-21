using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Objectives
{
    public class CreateObjectiveInputModel
    {
        public int PlaceId { get; set; }

        public DateTime VisitedOn { get; set; }

        public string VisitedBy { get; set; }
    }
}
