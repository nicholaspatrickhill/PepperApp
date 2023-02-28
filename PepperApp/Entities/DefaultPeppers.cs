namespace PepperApp.Entities
{
    public class DefaultPeppers : Pepper
    {
        // Scoville values sourced from chilipeppermadness.com

        public static readonly Dictionary<string, Pepper> defaultPeppers = new Dictionary<string, Pepper>
        {
            { "anaheim", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Anaheim", PepperScovilleUnitMin = 500, PepperScovilleUnitMax = 2500, PepperHeatClass = "mild", IsReadOnly = true } },
            { "bellPepper", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Bell Pepper", PepperScovilleUnitMin = 0, PepperScovilleUnitMax=0, PepperHeatClass = "mild", IsReadOnly = true } },
            { "carolinaReaper", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Carolina Reaper", PepperScovilleUnitMin = 1400000, PepperScovilleUnitMax = 2200000, PepperHeatClass = "super-hot", IsReadOnly = true } },
            { "cayenne", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Cayenne", PepperScovilleUnitMin = 30000, PepperScovilleUnitMax = 50000, PepperHeatClass = "medium-hot", IsReadOnly = true } },
            { "bananaPepper", new Pepper
                {Id = Guid.NewGuid(), PepperName = "Banana Pepper", PepperScovilleUnitMin = 0, PepperScovilleUnitMax = 500, PepperHeatClass = "mild", IsReadOnly = true } },
            { "ghostPepper", new Pepper
                { Id = Guid.NewGuid(),  PepperName = "Ghost Pepper", PepperScovilleUnitMin = 855000, PepperScovilleUnitMax = 1100000, PepperHeatClass =  "super-hot", IsReadOnly = true } },
            { "habanero", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Habanero", PepperScovilleUnitMin = 100000, PepperScovilleUnitMax = 350000, PepperHeatClass = "hot", IsReadOnly = true } },
            { "jalapeno", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Jalapeno", PepperScovilleUnitMin = 2500, PepperScovilleUnitMax = 8000, PepperHeatClass = "medium", IsReadOnly = true } },
            { "poblano", new Pepper
                { Id = Guid.NewGuid(), PepperName= "Poblano", PepperScovilleUnitMin = 1000, PepperScovilleUnitMax = 2000, PepperHeatClass = "mild", IsReadOnly = true } },
            { "scotchBonnet", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Scotch Bonnet", PepperScovilleUnitMin = 100000, PepperScovilleUnitMax = 350000, PepperHeatClass = "hot", IsReadOnly = true } },
            { "serrano", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Serrano", PepperScovilleUnitMin = 10000, PepperScovilleUnitMax = 23000, PepperHeatClass = "medium-hot", IsReadOnly = true } },
            { "thaiChili", new Pepper
                { Id = Guid.NewGuid(), PepperName = "Thai Chili", PepperScovilleUnitMin = 50000, PepperScovilleUnitMax = 100000, PepperHeatClass = "medium-hot", IsReadOnly = true } }
        };
    }
}