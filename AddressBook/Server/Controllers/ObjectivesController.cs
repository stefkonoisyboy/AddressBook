using AddressBook.Server.Services.Interfaces;
using AddressBook.Shared.Objectives;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AddressBook.Server.Controllers
{
    public class ObjectivesController : ApiController
    {
        private readonly IObjectivesService objectivesService;

        public ObjectivesController(IObjectivesService objectivesService)
        {
            this.objectivesService = objectivesService;
        }

        [Authorize]
        [HttpGet("{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<AllObjectivesInPeriodViewModel>>> GetAllInPeriod(DateTime startDate, DateTime endDate)
        {
            try
            {
                FilterObjectivesInputModel input = new FilterObjectivesInputModel
                {
                    StartDate = startDate,
                    EndDate = endDate,
                };

                IEnumerable<AllObjectivesInPeriodViewModel> viewModel = await this.objectivesService.GetAllInPeriodAsync(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return this.Ok(await this.objectivesService.GetAllAsync());
        }

        [Authorize]
        [HttpGet("{townId}")]
        public async Task<ActionResult<IEnumerable<AllObjectivesInPeriodViewModel>>> GetAllByTownId(int townId)
        {
            IEnumerable<AllObjectivesInPeriodViewModel> viewModel = await this.objectivesService.GetAllByTownIdAsync(townId);
            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllObjectivesInPeriodViewModel>>> GetAll()
        {
            IEnumerable<AllObjectivesInPeriodViewModel> viewModel = await this.objectivesService.GetAllAsync();
            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateObjectiveInputModel input)
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            input.VisitedBy = userId;
            await this.objectivesService.CreateAsync(input);
            return this.Ok();
        }
    }
}
