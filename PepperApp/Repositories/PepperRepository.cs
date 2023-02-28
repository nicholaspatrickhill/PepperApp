using Microsoft.EntityFrameworkCore;
using PepperApp.Data;
using PepperApp.Entities;

namespace PepperApp.Repository
{
    public class PepperRepository : IPepperRepository
    {
        private readonly PepperContext _context;

        public PepperRepository()
        {
            _context = new PepperContext();
        }

        public async Task<Pepper?> GetPepperByNameAsync(string pepperName)
        {
            return await _context.Peppers.FirstOrDefaultAsync(p => p.PepperName == pepperName);
        }

        // Assigns a value to the PepperHeatClass property of a user added pepper, adds it to the database context and saves
        public async Task AddPepperAsync(Pepper pepper)
        {
            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMax);

            await _context.Peppers.AddAsync(pepper);
            await _context.SaveChangesAsync();
        }

        // Removes pepper from the database based on matching userinput to the PepperName and saves
        public async Task RemovePepperAsync(Pepper pepperToRemove)
        {
            var deletedPepper = await _context.Peppers.SingleOrDefaultAsync(p => p.PepperName == pepperToRemove.PepperName);

            if (deletedPepper != null)
            {
                if (deletedPepper.IsReadOnly)
                {
                    throw new InvalidOperationException("I'm sorry but that pepper is read-only and cannot be removed from the database.");
                }

                _context.Peppers.Remove(deletedPepper);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("No pepper with the specified name was found in the database. Please try again.");
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
