namespace PepperApp.Services
{
    public interface IPepperService
    {
        Task CreatePepperServiceAsync(PepperDto pepperDto);
        Task<List<PepperDto>> GetAllPeppersServiceAsync();
        Task<List<PepperDto>> GetHotPeppersServiceAsync();
        Task<List<PepperDto>> GetMediumHotPeppersServiceAsync();
        Task<List<PepperDto>> GetMediumPeppersServiceAsync();
        Task<List<PepperDto>> GetMildPeppersServiceAsync();
        Task<PepperDto?> GetPepperByNameServiceAsync(string pepperName);
        Task<List<PepperDto>> GetSuperHotPeppersServiceAsync();
        Task RemovePepperServiceAsync(PepperDto pepperToRemove);
        Task UpdatePepperServiceAsync(PepperDto pepperToUpdate);
    }
}