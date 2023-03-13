using Microsoft.EntityFrameworkCore;
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

        // Gets a pepper by ID
        public async Task<Pepper?> GetPepperByIdAsync(Guid pepperId)
        {
            return await _context.Peppers.FindAsync(pepperId);
        }

        // Generates a list of all peppers in the database sorted by name
        public async Task<List<Pepper>> GetAllPeppersAsync()
        {
            var peppers = await _context.Peppers.ToListAsync();

            return peppers.OrderBy(p => p.PepperName).ToList();
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

        // Updates a pepper in the database
        public async Task UpdatePepperAsync(Pepper pepperToUpdate)
        {
            var existingPepper = await _context.Peppers.SingleOrDefaultAsync(p => p.PepperId == pepperToUpdate.PepperId);

            if (existingPepper == null)
            {
                throw new ArgumentException("No pepper with the specified name was found in the database.");
            }

            _context.Update(existingPepper);
            await _context.SaveChangesAsync();        
        }

        // Uses raw sql to query the database to return peppers sorted by heat class
        public async Task<List<Pepper>> GetMildPeppersAsync()
        {
            using (var context = new PepperContext())
            {
                var mildPeppers = await context.Peppers.FromSqlRaw(@"
                    SELECT * FROM Peppers WHERE PepperScovilleUnitMaximum <= 5000;")    
                    .ToListAsync();
                return mildPeppers;
            }
        }

        public async Task<List<Pepper>> GetMediumPeppersAsync()
        {
            using (var context = new PepperContext())
            {
                var mediumPeppers = await context.Peppers.FromSqlRaw(@"
                    SELECT * FROM Peppers WHERE PepperScovilleUnitMaximum <= 15000 AND PepperScovilleUnitMaximum > 5000;")           
                    .ToListAsync();
                return mediumPeppers;
            }
        }

        public async Task<List<Pepper>> GetMediumHotPeppersAsync()
        {
            using (var context = new PepperContext())
            {
                var mediumHotPeppers = await context.Peppers.FromSqlRaw(@"
                    SELECT * FROM Peppers WHERE PepperScovilleUnitMaximum <= 100000 AND PepperScovilleUnitMaximum > 15000;")
                    .ToListAsync();
                return mediumHotPeppers;
            }
        }

        public async Task<List<Pepper>> GetHotPeppersAsync()
        {
            using (var context = new PepperContext())
            {
                var hotPeppers = await context.Peppers.FromSqlRaw(@"
                    SELECT * FROM Peppers WHERE PepperScovilleUnitMaximum <= 350000 AND PepperScovilleUnitMaximum > 100000;")
                    .ToListAsync();
                return hotPeppers;
            }
        }

        public async Task<List<Pepper>> GetSuperHotPeppersAsync()
        {
            using (var context = new PepperContext())
            {
                var superHotPeppers = await context.Peppers.FromSqlRaw(@"
                    SELECT * FROM Peppers WHERE PepperScovilleUnitMaximum > 350000;")
                    .ToListAsync();
                return superHotPeppers;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

