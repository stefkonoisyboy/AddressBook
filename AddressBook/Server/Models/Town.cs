using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Models
{
    public class Town
    {
        public Town()
        {
            this.Places = new HashSet<Place>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
