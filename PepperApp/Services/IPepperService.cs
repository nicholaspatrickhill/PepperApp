using PepperApp.Entities;

namespace PepperApp.Services
{
    public interface IPepperService
    {
        Task AddPepperServiceAsync(Pepper pepper);
        void Dispose();
        Task<List<Pepper>> GetAllPeppersServiceAsync();
        Task<Pepper?> GetPepperByNameServiceAsync(string pepperName);
        Task RemovePepperServiceAsync(string pepperName);
    }
}