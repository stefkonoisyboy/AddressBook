using AddressBook.Shared.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Services.Interfaces
{
    public interface IPlacesService
    {
        Task CreateAsync(CreatePlaceInputModel input);

        Task<PlaceDetailsViewModel> GetByIdAsync(int id);

        Task<IEnumerable<AllPlacesByViewModel>> GetAllAsync();

        Task<IEnumerable<AllPlacesByViewModel>> GetAllByTownIdAsync(int townId);
    }
}
