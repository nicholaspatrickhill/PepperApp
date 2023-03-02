using PepperApp.Entities;

namespace PepperApp.Repositories
{
    public interface IPepperRepository
    {
        Task AddPepperAsync(Pepper pepper);
        void Dispose();
        Task<List<Pepper>> GetAllPeppersAsync();
        Task<Pepper?> GetPepperByNameAsync(string pepperName);
        Task RemovePepperAsync(Pepper pepperToRemove);
    }
}