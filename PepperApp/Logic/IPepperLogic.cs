using PepperApp.Entities;

namespace PepperApp.Logic
{
    public interface IPepperLogic
    {
        Task AddPepperAsync(Pepper pepper);
        void Dispose();
        Task<List<Pepper>> GetAllPeppersAsync();
        Task<Pepper?> GetPepperByNameAsync(string pepperName);
        Task RemovePepperAsync(Pepper pepperToRemove);
    }
}