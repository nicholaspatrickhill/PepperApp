using PepperApp.Entities;

namespace PepperApp.Services
{
    public interface IPepperService
    {
        Task AddPepperServiceAsync(string? pepperName, int? pepperScovilleUnitMin, int? pepperScovilleUnitMax);
        Task<List<Pepper>> GetAllPeppersServiceAsync();
        Task<List<Pepper>> GetHotPeppersServiceAsync();
        Task<List<Pepper>> GetMediumHotPeppersServiceAsync();
        Task<List<Pepper>> GetMediumPeppersServiceAsync();
        Task<List<Pepper>> GetMildPeppersServiceAsync();
        Task<Pepper?> GetPepperByNameServiceAsync(string pepperName);
        Task<List<Pepper>> GetSuperHotPeppersServiceAsync();
        Task RemovePepperServiceAsync(Pepper pepperToRemove);
        Task UpdatePepperServiceAsync(Pepper updatedPepper);
    }
}