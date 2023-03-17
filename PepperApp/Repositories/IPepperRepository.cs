using PepperApp.Entities;

namespace PepperApp.Repositories
{
    public interface IPepperRepository
    {
        Task CreatePepperAsync(Pepper pepper);
        void Dispose();
        Task<List<Pepper>> GetAllPeppersAsync();
        Task<List<Pepper>> GetHotPeppersAsync();
        Task<List<Pepper>> GetMediumHotPeppersAsync();
        Task<List<Pepper>> GetMediumPeppersAsync();
        Task<List<Pepper>> GetMildPeppersAsync();
        Task<Pepper?> GetPepperByIdAsync(Guid pepperId);
        Task<Pepper?> GetPepperByNameAsync(string pepperName);
        Task<List<Pepper>> GetSuperHotPeppersAsync();
        Task RemovePepperAsync(Pepper pepperToRemove);
        Task UpdatePepperAsync(Pepper pepperToUpdate);
    }
}