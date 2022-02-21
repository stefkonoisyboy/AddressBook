using AddressBook.Server.Services.Interfaces;
using AddressBook.Shared.Places;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Controllers
{
    public class PlacesController : ApiController
    {
        private readonly IPlacesService placesService;
        private readonly ITownsService townsService;
        private readonly IGroupsService groupsService;

        public PlacesController(IPlacesService placesService, ITownsService townsService, IGroupsService groupsService)
        {
            this.placesService = placesService;
            this.townsService = townsService;
            this.groupsService = groupsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllPlacesByViewModel>>> GetAll()
        {
            IEnumerable<AllPlacesByViewModel> viewModel = await this.placesService.GetAllAsync();
            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet("{townId}")]
        public async Task<ActionResult<IEnumerable<AllPlacesByViewModel>>> GetAllByTownId(int townId = 0)
        {
            IEnumerable<AllPlacesByViewModel> viewModel = await this.placesService.GetAllByTownIdAsync(townId);
            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaceDetailsViewModel>> GetById(int id)
        {

            PlaceDetailsViewModel viewModel = await this.placesService.GetByIdAsync(id);
            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CreatePlaceInputModel>> Create()
        {
            CreatePlaceInputModel input = new CreatePlaceInputModel
            {
                Towns = await this.townsService.GetAllForDropDownAsync(),
                Groups = await this.groupsService.GetAllForDropDownAsync(),
            };

            return this.Ok(input);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePlaceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Towns = await this.townsService.GetAllForDropDownAsync();
                input.Groups = await this.groupsService.GetAllForDropDownAsync();
                return this.BadRequest(input);
            }

            await this.placesService.CreateAsync(input);

            return this.Ok();
        }
    }
}
