using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PepperApp.Entities;
using PepperApp.Repository;

namespace PepperApp.Services
{
    public class PepperService : IPepperService
    {
        private readonly IPepperRepository _repository;

        public PepperService(IPepperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Pepper?> GetPepperByNameServiceAsync(string pepperName)
        {
            return await _repository.GetPepperByNameAsync(pepperName);
        }

        public async Task AddPepperServiceAsync(Pepper pepper)
        {
            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMax);
            await _repository.AddPepperAsync(pepper);
        }

        public async Task RemovePepperServiceAsync(string pepperName)
        {
            var pepperToRemove = await _repository.GetPepperByNameAsync(pepperName);

            if (pepperToRemove != null)
            {
                if (pepperToRemove.IsReadOnly)
                {
                    throw new InvalidOperationException("I'm sorry but that pepper is read-only and cannot be removed from the database.");
                }

                await _repository.RemovePepperAsync(pepperToRemove);
            }
            else
            {
                throw new ArgumentException("No pepper with the specified name was found in the database. Please try again.");
            }
        }

        public async Task<List<Pepper>> GetAllPeppersServiceAsync()
        {
            return await _repository.GetAllPeppersAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}