using AddressBook.Shared.Objectives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Services.Interfaces
{
    public interface IObjectivesService
    {
        Task CreateAsync(CreateObjectiveInputModel input);

        Task<IEnumerable<AllObjectivesInPeriodViewModel>> GetAllAsync();

        Task<IEnumerable<AllObjectivesInPeriodViewModel>> GetAllByTownIdAsync(int townId);

        Task<IEnumerable<AllObjectivesInPeriodViewModel>> GetAllInPeriodAsync(FilterObjectivesInputModel input);

        bool IsCompleted(int placeId);
    }
}
