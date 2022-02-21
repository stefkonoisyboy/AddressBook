using AddressBook.Server.Data;
using AddressBook.Server.Models;
using AddressBook.Server.Services.Interfaces;
using AddressBook.Shared.Objectives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Services
{
    public class ObjectivesService : IObjectivesService
    {
        private readonly ApplicationDbContext dbContext;

        public ObjectivesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CreateObjectiveInputModel input)
        {
            Objective objective = new Objective
            {
                PlaceId = input.PlaceId,
                VisitedById = input.VisitedBy,
                VisitedOn = DateTime.UtcNow,
            };

            await this.dbContext.Objectives.AddAsync(objective);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllObjectivesInPeriodViewModel>> GetAllAsync()
        {
            return await this.dbContext.Objectives
               .OrderBy(o => o.Place.Name)
               .Select(o => new AllObjectivesInPeriodViewModel
               {
                   Id = o.PlaceId,
                   PlaceAddress = $"https://www.google.com/maps/search/?api=1&query={o.Place.Latitude},{o.Place.Longitude}",
                   PlaceGroup = o.Place.Group.Name,
                   PlaceTown = o.Place.Town.Name,
                   PlaceName = o.Place.Name,
                   PlacePhoto = o.Place.Photo,
                   VisitedOn = o.VisitedOn,
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<AllObjectivesInPeriodViewModel>> GetAllByTownIdAsync(int townId)
        {
            return await this.dbContext.Objectives
              .Where(o => o.Place.TownId == townId)
              .OrderBy(o => o.Place.Name)
              .Select(o => new AllObjectivesInPeriodViewModel
              {
                  Id = o.PlaceId,
                  PlaceAddress = $"https://www.google.com/maps/search/?api=1&query={o.Place.Latitude},{o.Place.Longitude}",
                  PlaceGroup = o.Place.Group.Name,
                  PlaceTown = o.Place.Town.Name,
                  PlaceName = o.Place.Name,
                  PlacePhoto = o.Place.Phone,
                  VisitedOn = o.VisitedOn,
              })
              .ToListAsync();
        }

        public async Task<IEnumerable<AllObjectivesInPeriodViewModel>> GetAllInPeriodAsync(FilterObjectivesInputModel input)
        {
            return await this.dbContext.Objectives
                .Where(o => o.VisitedOn >= input.StartDate && o.VisitedOn <= input.EndDate)
                .OrderBy(o => o.Place.Name)
                .Select(o => new AllObjectivesInPeriodViewModel
                {
                    Id = o.PlaceId,
                    PlaceAddress = $"https://www.google.com/maps/search/?api=1&query={o.Place.Latitude},{o.Place.Longitude}",
                    PlaceGroup = o.Place.Group.Name,
                    PlaceTown = o.Place.Town.Name,
                    PlaceName = o.Place.Name,
                    PlacePhoto = o.Place.Phone,
                    VisitedOn = o.VisitedOn,
                })
                .ToListAsync();
        }

        public bool IsCompleted(int placeId)
        {
            return this.dbContext.Objectives.Any(o => o.PlaceId == placeId && DateTime.UtcNow.Year == o.VisitedOn.Year && DateTime.UtcNow.Month == o.VisitedOn.Month && DateTime.UtcNow.Day == o.VisitedOn.Day);
        }
    }
}
