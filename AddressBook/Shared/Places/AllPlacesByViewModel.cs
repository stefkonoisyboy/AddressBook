using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Places
{
    public class AllPlacesByViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public string Town { get; set; }

        public string Group { get; set; }

        public bool IsCompleted { get; set; }
    }
}
