using AddressBook.Server.Services.Interfaces;
using AddressBook.Shared.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ITownsService townsService;

        public SearchController(ITownsService townsService)
        {
            this.townsService = townsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<SearchByTownInputModel>> GetTowns()
        {
            SearchByTownInputModel input = new SearchByTownInputModel
            {
                Towns = await this.townsService.GetAllForDropDownAsync(),
            };

            return this.Ok(input);
        }
    }
}
