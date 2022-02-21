using AddressBook.Server.Data;
using AddressBook.Server.Services.Interfaces;
using AddressBook.Shared.Groups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly ApplicationDbContext dbContext;

        public GroupsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllGroupsForDropDownViewModel>> GetAllForDropDownAsync()
        {
            return await this.dbContext.Groups
                .OrderBy(g => g.Name)
                .Select(g => new AllGroupsForDropDownViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToListAsync();
        }
    }
}
