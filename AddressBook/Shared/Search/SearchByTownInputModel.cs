using AddressBook.Shared.Towns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Search
{
    public class SearchByTownInputModel
    {
        public int TownId { get; set; }

        public IEnumerable<AllTownsForDropDownViewModel> Towns { get; set; }
    }
}
