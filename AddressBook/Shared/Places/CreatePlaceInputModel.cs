using AddressBook.Shared.Groups;
using AddressBook.Shared.Towns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Places
{
    public class CreatePlaceInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Photo { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        [Required]
        public int TownId { get; set; }

        public IEnumerable<AllTownsForDropDownViewModel> Towns { get; set; }

        [Required]
        public int GroupId { get; set; }

        public IEnumerable<AllGroupsForDropDownViewModel> Groups { get; set; }
    }
}
