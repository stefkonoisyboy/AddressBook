using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Objectives
{
    public class AllObjectivesInPeriodViewModel
    {
        public int Id { get; set; }

        public string PlaceName { get; set; }

        public string PlacePhoto { get; set; }

        public string PlaceTown { get; set; }

        public string PlaceGroup { get; set; }

        public string PlaceAddress { get; set; }

        public DateTime VisitedOn { get; set; }
    }
}
