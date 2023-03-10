using FluentValidation.Results;
using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Validators;

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
