using FluentValidation;
using FluentValidation.Results;
using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Validators;
using Serilog;

namespace PepperApp.Services
{
    public class PepperService : IPepperService
    {
        private readonly PepperRepository _pepperRepository;

        public PepperService(PepperRepository pepperRepository)
        {
            _pepperRepository = pepperRepository;
        }

        // Calls method from the repository to get pepper by name
        public async Task<Pepper?> GetPepperByNameAsync(string pepperName)
        {
            return await _pepperRepository.GetPepperByNameAsync(pepperName);
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
                throw new ArgumentException("A pepper with that name already exists in the database.");
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
                PepperScovilleUnitMinimum = pepperScovilleUnitMin.Value,
                PepperScovilleUnitMaximum = pepperScovilleUnitMax.Value
            };

            var validator = new PepperValidator();
            ValidationResult results = validator.Validate(pepper);

            if (!results.IsValid)
            {
                throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMaximum);
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
                throw new ArgumentException("No pepper with the specified name was found in the database.");
            }

            if (existingPepper.IsReadOnly)
            {
                throw new InvalidOperationException("That pepper is read-only and cannot be removed from the database.");
            }

            await _pepperRepository.RemovePepperAsync(pepperToRemove);
        }

        // Validates the pepper to be updated and then calls the update method from the repository
        public async Task UpdatePepperServiceAsync(Pepper updatedPepper)
        {
            var existingPepper = await _pepperRepository.GetPepperByIdAsync(updatedPepper.PepperId);

            if (existingPepper == null)
            {
                throw new ArgumentException("No pepper with the specified ID was found in the database.");
            }

            if (existingPepper.IsReadOnly)
            {
                throw new InvalidOperationException("That pepper is read-only and cannot be updated in the database.");                
            }

            existingPepper.PepperName = updatedPepper.PepperName;
            existingPepper.PepperScovilleUnitMinimum = updatedPepper.PepperScovilleUnitMinimum;
            existingPepper.PepperScovilleUnitMaximum = updatedPepper.PepperScovilleUnitMaximum;
            existingPepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(updatedPepper.PepperScovilleUnitMaximum);

            await _pepperRepository.UpdatePepperAsync(existingPepper);
        }


        //public async Task UpdatePepperServiceAsync(Pepper updatedPepper)
        //{
        //    var existingPepper = await _pepperRepository.GetPepperByIdAsync(updatedPepper.PepperId);

        //    if (existingPepper == null)
        //    {
        //        throw new ArgumentException("No pepper with the specified name was found in the database.");
        //    }

        //    if (existingPepper.IsReadOnly)
        //    {
        //        throw new InvalidOperationException("That pepper is read-only and cannot be updated in the database.");
        //    }

        //    var validator = new PepperValidator();
        //    ValidationResult results = validator.Validate(updatedPepper);

        //    if (!results.IsValid)
        //    {
        //        //throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
        //        throw new ValidationException(string.Join(", ", results.Errors.Select(e => e.ErrorMessage)));

        //    }

        //    updatedPepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(updatedPepper.PepperScovilleUnitMaximum);
        //    await _pepperRepository.UpdatePepperAsync(updatedPepper);
        //}
    }
}

