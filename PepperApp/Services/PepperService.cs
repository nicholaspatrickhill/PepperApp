using FluentValidation.Results;
using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Validators;

namespace PepperApp.Services
{
    public class PepperService : IPepperService
    {
        private readonly IPepperRepository _pepperRepository;

        public PepperService(IPepperRepository pepperRepository)
        {
            _pepperRepository = pepperRepository;
        }

        // Validates pepper to be added then calls the add method from the repository

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
                throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMax);
            await _pepperRepository.AddPepperAsync(pepper);
        }

        // Calls repository method to get list of all peppers in the database
        public async Task<List<Pepper>> GetAllPeppersServiceAsync()
        {
            return await _pepperRepository.GetAllPeppersAsync();
        }

        // Validates the pepper to be removed and then calls the removal method from the repository
        public async Task RemovePepperServiceAsync(Pepper pepperToRemove)
        {
            var existingPepper = await _pepperRepository.GetPepperByNameAsync(pepperToRemove.PepperName ?? string.Empty);

            if (existingPepper == null)
            {
                throw new ArgumentException("No pepper with the specified name was found in the database. Please try again.");
            }

            if (existingPepper.IsReadOnly)
            {
                throw new InvalidOperationException("I'm sorry but that pepper is read-only and cannot be removed from the database.");
            }

            await _pepperRepository.RemovePepperAsync(pepperToRemove);
        }
    }
}
