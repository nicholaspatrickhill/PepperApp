using PepperApp.Entities;

namespace PepperApp.Repository
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