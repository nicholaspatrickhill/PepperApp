using FluentValidation.Results;
using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperApp.Services
{
    public class PepperService
    {
        private readonly IPepperRepository _pepperRepository;

        public PepperService(IPepperRepository pepperRepository)
        {
            _pepperRepository = pepperRepository;
        }

        public async Task AddPepperServiceAsync(string? pepperName, int? pepperScovilleUnitMin, int? pepperScovilleUnitMax)
        {
            if (string.IsNullOrEmpty(pepperName))
            {
                throw new ArgumentException("Pepper name cannot be null or empty.");
            }

            var existingPepper = await _pepperRepository.GetPepperByNameAsync(pepperName);
            if (existingPepper?.PepperName != null)
            {
                throw new ArgumentException("A pepper with that name already exists in the database. Please enter a unique name.");
            }

            if (!pepperScovilleUnitMin.HasValue)
            {
                throw new ArgumentException("Minimum Scoville Heat Unit rating is required.");
            }

            if (!pepperScovilleUnitMax.HasValue)
            {
                throw new ArgumentException("Maximum Scoville Heat Unit rating is required.");
            }

            var pepper = new Pepper
            {
                PepperName = pepperName,
                PepperScovilleUnitMin = pepperScovilleUnitMin.Value,
                PepperScovilleUnitMax = pepperScovilleUnitMax.Value
            };

            var validator = new PepperValidator();
            ValidationResult results = validator.Validate(pepper);

            if (!results.IsValid)
            {
                throw new ArgumentException($"Pepper failed validation. Errors: {string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMax);
            await _pepperRepository.AddPepperAsync(pepper);
        }


        public async Task<List<Pepper>> GetAllPeppersServiceAsync()
        {
            return await _pepperRepository.GetAllPeppersAsync();
        }

        // public Task<Pepper?> GetPepperByNameServiceAsync(string pepperName)
       

        // public Task RemovePepperServiceAsync(Pepper pepperToRemove)
        
    }
}
