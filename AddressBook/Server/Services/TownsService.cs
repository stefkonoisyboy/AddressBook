using AddressBook.Server.Data;
using AddressBook.Server.Services.Interfaces;
using AddressBook.Shared.Towns;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Services
{
    public class TownsService : ITownsService
    {
        private readonly ApplicationDbContext dbContext;

        public TownsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllTownsForDropDownViewModel>> GetAllForDropDownAsync()
        {
            return await this.dbContext.Towns
                .OrderBy(t => t.Name)
                .Select(t => new AllTownsForDropDownViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }
    }
}
