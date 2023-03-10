using PepperApp.Entities;

namespace PepperApp.Services
{
    public interface IPepperService
    {
        Task AddPepperServiceAsync(string? pepperName, int? pepperScovilleUnitMin, int? pepperScovilleUnitMax);
        Task<List<Pepper>> GetAllPeppersServiceAsync();
        Task RemovePepperServiceAsync(Pepper pepperToRemove);
    }
}