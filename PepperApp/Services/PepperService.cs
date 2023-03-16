using AutoMapper;
using FluentValidation.Results;
using PepperApp.Entities;
using PepperApp.Repositories;
using PepperApp.Validators;

namespace PepperApp.Services
{
    public class PepperService : IPepperService
    {
        private readonly PepperRepository _pepperRepository;
        private readonly IMapper _mapper;

        public PepperService(PepperRepository pepperRepository, IMapper mapper)
        {
            _pepperRepository = pepperRepository;
            _mapper = mapper;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pepper, PepperDto>();
                cfg.CreateMap<PepperDto, Pepper>();
            });

            _mapper = config.CreateMapper();
        }

        // Calls method from the repository to get pepper by name
        public async Task<PepperDto?> GetPepperByNameServiceAsync(string pepperName)
        {
            var result = await _pepperRepository.GetPepperByNameAsync(pepperName);

            if (result == null)
            {
                throw new ArgumentException($"No pepper by that name was found in the database.");
            }

            return _mapper.Map<PepperDto>(result);
        }

        // Validates pepper to be added then calls the add method from the repository
        public async Task AddPepperServiceAsync(PepperDto pepperDto)
        {
            var existingPepper = await _pepperRepository.GetPepperByNameAsync(pepperDto.PepperName!);
            if (existingPepper?.PepperName != null)
            {
                throw new ArgumentException("A pepper with that name already exists in the database.");
            }

            var validator = new PepperValidator();
            ValidationResult results = validator.Validate(pepperDto);

            if (!results.IsValid)
            {
                throw new ArgumentException($"{string.Join(", ", results.Errors.Select(e => e.ErrorMessage))}");
            }

            var pepper = _mapper.Map<Pepper>(pepperDto);
            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMaximum);
            await _pepperRepository.AddPepperAsync(pepper);
        }

        // Calls repository method to get list of all peppers in the database
        public async Task<List<PepperDto>> GetAllPeppersServiceAsync()
        {
            var peppers = await _pepperRepository.GetAllPeppersAsync();
            return _mapper.Map<List<PepperDto>>(peppers);
        }

        // Validates the pepper to be removed and then calls the removal method from the repository
        public async Task RemovePepperServiceAsync(PepperDto pepperToRemove)
        {
            var existingPepper = await _pepperRepository.GetPepperByNameAsync(pepperToRemove.PepperName!);

            if (existingPepper == null)
            {
                throw new ArgumentException("No pepper with the specified name was found in the database.");
            }

            if (existingPepper.IsReadOnly)
            {
                throw new InvalidOperationException("That pepper is read-only and cannot be removed from the database.");
            }

            var pepper = _mapper.Map<Pepper>(pepperToRemove);
            await _pepperRepository.RemovePepperAsync(pepper);
        }

        // Validates the pepper to be updated and then calls the update method from the repository
        public async Task UpdatePepperServiceAsync(PepperDto updatedPepperDto)
        {
            var existingPepper = await _pepperRepository.GetPepperByIdAsync(updatedPepperDto.PepperId);

            if (existingPepper == null)
            {
                throw new ArgumentException("No pepper with the specified name was found in the database.");
            }

            if (existingPepper.IsReadOnly)
            {
                throw new InvalidOperationException("That pepper is read-only and cannot be updated in the database.");
            }

            existingPepper.PepperName = updatedPepperDto.PepperName;
            existingPepper.PepperScovilleUnitMinimum = updatedPepperDto.PepperScovilleUnitMinimum;
            existingPepper.PepperScovilleUnitMaximum = updatedPepperDto.PepperScovilleUnitMaximum;

            var pepper = _mapper.Map<Pepper>(updatedPepperDto);
            pepper.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pepper.PepperScovilleUnitMaximum);

            await _pepperRepository.UpdatePepperAsync(pepper);
        }

        // Calls repository method to get list of all mild peppers in the database
        public async Task<List<PepperDto>> GetMildPeppersServiceAsync()
        {
            var mildPeppers = await _pepperRepository.GetMildPeppersAsync();
            return _mapper.Map<List<PepperDto>>(mildPeppers);
        }

        // Calls repository method to get list of all medium peppers in the database
        public async Task<List<PepperDto>> GetMediumPeppersServiceAsync()
        {
            var mediumPeppers = await _pepperRepository.GetMediumPeppersAsync();
            return _mapper.Map<List<PepperDto>>(mediumPeppers);
        }

        // Calls repository method to get list of all medium-hot peppers in the database
        public async Task<List<PepperDto>> GetMediumHotPeppersServiceAsync()
        {
            var mediumHotPeppers = await _pepperRepository.GetMediumHotPeppersAsync();
            return _mapper.Map<List<PepperDto>>(mediumHotPeppers);
        }

        // Calls repository method to get list of all hot peppers in the database
        public async Task<List<PepperDto>> GetHotPeppersServiceAsync()
        {
            var hotPeppers = await _pepperRepository.GetHotPeppersAsync();
            return _mapper.Map<List<PepperDto>>(hotPeppers); ;
        }

        // Calls repository method to get list of all super-hot peppers in the database
        public async Task<List<PepperDto>> GetSuperHotPeppersServiceAsync()
        {
            var superHotPeppers = await _pepperRepository.GetSuperHotPeppersAsync();
            return _mapper.Map<List<PepperDto>>(superHotPeppers);
        }
    }
}

