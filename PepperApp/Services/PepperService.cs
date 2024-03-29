﻿using AutoMapper;
using FluentValidation.Results;
using PepperApp.DataTransferObject;
using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Validators;
using Serilog;
using System.Globalization;

namespace PepperApp.Services
{
    public class PepperService : IPepperService
    {
        private readonly PepperRepository _pepperRepository;
        private readonly IMapper _mapper;

        public PepperService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pepper, PepperDto>();
                cfg.CreateMap<PepperDto, Pepper>();
            });

            _mapper = config.CreateMapper();
            _pepperRepository = new PepperRepository();
        }

        // Calls method from the repository to get pepper by name
        public async Task<PepperDto?> GetPepperByNameServiceAsync(string pepperName)
        {
            // Convert the input string to title case
            pepperName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pepperName.ToLower());

            var result = await _pepperRepository.GetPepperByNameAsync(pepperName);

            if (result == null)
            {
                Log.Error($"No pepper with the specified name was found in the database.");
                throw new ArgumentException($"Pepper was unable to be retrieved from the database: No pepper by that name was found in the database.");
            }

            return _mapper.Map<PepperDto>(result);
        }

        // Validates pepper to be added then calls the add method from the repository
        public async Task CreatePepperServiceAsync(PepperDto pepperDto)
        {
            var pepperName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pepperDto.PepperName!.ToLower());
            var existingPepper = await _pepperRepository.GetPepperByNameAsync(pepperName!);
            if (existingPepper != null)
            {
                Log.Error($"Creation failed. A pepper with that name already exists in the database: {pepperDto.PepperName}");
                throw new ArgumentException("A pepper with that name already exists in the database.");
            }

            var validator = new PepperValidator();
            ValidationResult results = validator.Validate(pepperDto);

            if (!results.IsValid)
            {
                Log.Error($"Creation failed. Validation Error: {string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
                throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            Log.Information($"Pepper was added to the database: {pepperDto.PepperName}");

            var pepper = _mapper.Map<Pepper>(pepperDto);
            pepper.PepperName = pepperName;
            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMaximum);
            pepper.IsReadOnly = false;

            await _pepperRepository.CreatePepperAsync(pepper);
        }

        // Validates the pepper to be removed and then calls the removal method from the repository
        public async Task RemovePepperServiceAsync(PepperDto pepperToRemove)
        {
            var existingPepper = await _pepperRepository.GetPepperByNameAsync(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pepperToRemove.PepperName!.ToLower()));

            if (existingPepper == null)
            {
                Log.Error($"Removal failed. No pepper with the specified name was found in the database.");
                throw new ArgumentException("No pepper with the specified name was found in the database.");
            }

            if (existingPepper.IsReadOnly)
            {
                Log.Error($"Removal failed. That pepper is read-only and cannot be removed from the database: {existingPepper.PepperName}");
                throw new InvalidOperationException("That pepper is read-only and cannot be removed from the database.");
            }

            Log.Information($"Pepper was removed from the database: {pepperToRemove.PepperName}");
            var pepper = _mapper.Map<Pepper>(pepperToRemove);
            await _pepperRepository.RemovePepperAsync(pepper);
        }

        // Validates the pepper to be updated and then calls the update method from the repository
        public async Task UpdatePepperServiceAsync(PepperDto pepperDto)
        {
            pepperDto.PepperName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pepperDto.PepperName!.ToLower());

            var existingPepper = await _pepperRepository.GetPepperByIdAsync(pepperDto.PepperId);

            if (existingPepper == null)
            {
                Log.Error($"Update failed. No pepper with the specified name was found in the database.");
                throw new ArgumentException("No pepper with the specified name was found in the database.");
            }

            if (existingPepper.IsReadOnly)
            {
                Log.Error($"Updated failed. That pepper is read-only and cannot be updated: {existingPepper.PepperName}");
                throw new InvalidOperationException("That pepper is read-only and cannot be updated in the database.");
            }

            var validator = new PepperValidator();
            ValidationResult results = validator.Validate(pepperDto);

            if (!results.IsValid)
            {
                Log.Error($"Update failed. Validation Error: {string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
                throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            //existingPepper.PepperName = pepperDto.PepperName;
            existingPepper.PepperName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pepperDto.PepperName.ToLower());
            existingPepper.PepperScovilleUnitMinimum = pepperDto.PepperScovilleUnitMinimum;
            existingPepper.PepperScovilleUnitMaximum = pepperDto.PepperScovilleUnitMaximum;
            existingPepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepperDto.PepperScovilleUnitMaximum);
            existingPepper.IsReadOnly = false;

            Log.Information($"Pepper was updated: {pepperDto.PepperName}");

            var pepper = _mapper.Map<Pepper>(pepperDto);

            await _pepperRepository.UpdatePepperAsync(pepper);
        }

        // Calls repository method to get a list of all peppers in the database
        public async Task<List<PepperDto>> GetAllPeppersServiceAsync()
        {
            var peppers = await _pepperRepository.GetAllPeppersAsync();
            return _mapper.Map<List<PepperDto>>(peppers);
        }

        // Calls repository method to get a list of all mild peppers in the database
        public async Task<List<PepperDto>> GetMildPeppersServiceAsync()
        {
            var mildPeppers = await _pepperRepository.GetMildPeppersAsync();
            return _mapper.Map<List<PepperDto>>(mildPeppers);
        }

        // Calls repository method to get a list of all medium peppers in the database
        public async Task<List<PepperDto>> GetMediumPeppersServiceAsync()
        {
            var mediumPeppers = await _pepperRepository.GetMediumPeppersAsync();
            return _mapper.Map<List<PepperDto>>(mediumPeppers);
        }

        // Calls repository method to get a list of all medium-hot peppers in the database
        public async Task<List<PepperDto>> GetMediumHotPeppersServiceAsync()
        {
            var mediumHotPeppers = await _pepperRepository.GetMediumHotPeppersAsync();
            return _mapper.Map<List<PepperDto>>(mediumHotPeppers);
        }

        // Calls repository method to get a list of all hot peppers in the database
        public async Task<List<PepperDto>> GetHotPeppersServiceAsync()
        {
            var hotPeppers = await _pepperRepository.GetHotPeppersAsync();
            return _mapper.Map<List<PepperDto>>(hotPeppers); ;
        }

        // Calls repository method to get a list of all super-hot peppers in the database
        public async Task<List<PepperDto>> GetSuperHotPeppersServiceAsync()
        {
            var superHotPeppers = await _pepperRepository.GetSuperHotPeppersAsync();
            return _mapper.Map<List<PepperDto>>(superHotPeppers);
        }
    }
}

