using AddressBook.Shared.Towns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Services.Interfaces
{
    public interface ITownsService
    {
        Task<IEnumerable<AllTownsForDropDownViewModel>> GetAllForDropDownAsync();
    }
}
