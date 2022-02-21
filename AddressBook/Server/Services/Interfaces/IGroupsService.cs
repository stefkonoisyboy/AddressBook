using AddressBook.Shared.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Services.Interfaces
{
    public interface IGroupsService
    {
        Task<IEnumerable<AllGroupsForDropDownViewModel>> GetAllForDropDownAsync();
    }
}
