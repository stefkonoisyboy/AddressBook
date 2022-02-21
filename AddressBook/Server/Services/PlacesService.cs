using AddressBook.Server.Data;
using AddressBook.Server.Models;
using AddressBook.Server.Services.Interfaces;
using AddressBook.Shared.Places;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Server.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly ApplicationDbContext dbContext;

        public PlacesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CreatePlaceInputModel input)
        {
            Place place = new Place
            {
                Name = input.Name,
                Phone = input.Phone,
                Photo = input.Photo,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                Email = input.Email,
                Notes = input.Notes,
                TownId = input.TownId,
                GroupId = input.GroupId,
            };

            await this.dbContext.Places.AddAsync(place);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllPlacesByViewModel>> GetAllAsync()
        {
            return await this.dbContext.Places
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Town)
                .ThenBy(p => p.Group)
                .Select(p => new AllPlacesByViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Photo = p.Photo,
                    Town = p.Town.Name,
                    Group = p.Group.Name,
                    IsCompleted = this.dbContext.Objectives.Any(o => o.PlaceId == p.Id && DateTime.UtcNow.Year == o.VisitedOn.Year && DateTime.UtcNow.Month == o.VisitedOn.Month && DateTime.UtcNow.Day == o.VisitedOn.Day),
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllPlacesByViewModel>> GetAllByTownIdAsync(int townId)
        {
            if (townId == 0)
            {
                return await this.dbContext.Places
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Town)
                .ThenBy(p => p.Group)
                .Select(p => new AllPlacesByViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Photo = p.Photo,
                    Town = p.Town.Name,
                    Group = p.Group.Name,
                    IsCompleted = this.dbContext.Objectives.Any(o => o.PlaceId == p.Id && DateTime.UtcNow.Year == o.VisitedOn.Year && DateTime.UtcNow.Month == o.VisitedOn.Month && DateTime.UtcNow.Day == o.VisitedOn.Day),
                })
                .ToListAsync();
            }

            return await this.dbContext.Places
                .Where(p => p.TownId == townId)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Town)
                .ThenBy(p => p.Group)
                .Select(p => new AllPlacesByViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Photo = p.Photo,
                    Town = p.Town.Name,
                    Group = p.Group.Name,
                    IsCompleted = this.dbContext.Objectives.Any(o => o.PlaceId == p.Id && DateTime.UtcNow.Year == o.VisitedOn.Year && DateTime.UtcNow.Month == o.VisitedOn.Month && DateTime.UtcNow.Day == o.VisitedOn.Day),
                })
                .ToListAsync();
        }

        public async Task<PlaceDetailsViewModel> GetByIdAsync(int id)
        {
            return await this.dbContext.Places
                .Where(p => p.Id == id)
                .Select(p => new PlaceDetailsViewModel
                {
                    Name = p.Name,
                    Photo = p.Photo,
                    Phone = p.Phone,
                    Email = p.Email,
                    Group = p.Group.Name,
                    Address = $"https://www.google.com/maps/search/?api=1&query={p.Latitude},{p.Longitude}",
                })
                .FirstOrDefaultAsync();
        }
    }
}
