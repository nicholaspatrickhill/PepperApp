﻿using Microsoft.EntityFrameworkCore;
using PepperApp.Data;
using PepperApp.Entities;

namespace PepperApp.Repositories
{
    public class PepperRepository : IPepperRepository
    {
        private readonly PepperContext _context;

        public PepperRepository()
        {
            _context = new PepperContext();
        }

        // Gets a pepper by name
        public async Task<Pepper?> GetPepperByNameAsync(string pepperName)
        {
            return await _context.Peppers.FirstOrDefaultAsync(p => p.PepperName == pepperName);
        }

        // Adds a pepper to the database
        public async Task AddPepperAsync(Pepper pepper)
        {
            await _context.Peppers.AddAsync(pepper);
            await _context.SaveChangesAsync();
        }

        // Removes a pepper from the database
        public async Task RemovePepperAsync(Pepper pepperToRemove)
        {
            var deletedPepper = await _context.Peppers.SingleOrDefaultAsync(p => p.PepperName == pepperToRemove.PepperName);

            if (deletedPepper != null)
            {
                _context.Peppers.Remove(deletedPepper);
                await _context.SaveChangesAsync();
            }
        }      

        // Generates a list of all peppers in the database sorted by name
        public async Task<List<Pepper>> GetAllPeppersAsync()
        {
            var peppers = await _context.Peppers.ToListAsync();

            return peppers.OrderBy(p => p.PepperName).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

