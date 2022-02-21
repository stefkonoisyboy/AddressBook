using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Models
{
    public class Place
    {
        public Place()
        {
            this.Objectives = new HashSet<Objective>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Objective> Objectives { get; set; }
    }
}
