namespace PepperApp.Entities
{
    public class DefaultPeppers : Pepper
    {
        // Scoville values sourced from chilipeppermadness.com

        public static readonly Dictionary<string, Pepper> defaultPeppers = new Dictionary<string, Pepper>
        {
            { "anaheim", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Anaheim", PepperScovilleUnitMinimum = 500, PepperScovilleUnitMaximum = 2500, PepperHeatClass = "mild", IsReadOnly = true } },
            { "bellPepper", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Bell Pepper", PepperScovilleUnitMinimum = 0, PepperScovilleUnitMaximum=0, PepperHeatClass = "mild", IsReadOnly = true } },
            { "carolinaReaper", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Carolina Reaper", PepperScovilleUnitMinimum = 1400000, PepperScovilleUnitMaximum = 2200000, PepperHeatClass = "super-hot", IsReadOnly = true } },
            { "cayenne", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Cayenne", PepperScovilleUnitMinimum = 30000, PepperScovilleUnitMaximum = 50000, PepperHeatClass = "medium-hot", IsReadOnly = true } },
            { "bananaPepper", new Pepper
                {PepperId = Guid.NewGuid(), PepperName = "Banana Pepper", PepperScovilleUnitMinimum = 0, PepperScovilleUnitMaximum = 500, PepperHeatClass = "mild", IsReadOnly = true } },
            { "ghostPepper", new Pepper
                { PepperId = Guid.NewGuid(),  PepperName = "Ghost Pepper", PepperScovilleUnitMinimum = 855000, PepperScovilleUnitMaximum = 1100000, PepperHeatClass =  "super-hot", IsReadOnly = true } },
            { "habanero", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Habanero", PepperScovilleUnitMinimum = 100000, PepperScovilleUnitMaximum = 350000, PepperHeatClass = "hot", IsReadOnly = true } },
            { "jalapeno", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Jalapeno", PepperScovilleUnitMinimum = 2500, PepperScovilleUnitMaximum = 8000, PepperHeatClass = "medium", IsReadOnly = true } },
            { "poblano", new Pepper
                { PepperId = Guid.NewGuid(), PepperName= "Poblano", PepperScovilleUnitMinimum = 1000, PepperScovilleUnitMaximum = 2000, PepperHeatClass = "mild", IsReadOnly = true } },
            { "scotchBonnet", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Scotch Bonnet", PepperScovilleUnitMinimum = 100000, PepperScovilleUnitMaximum = 350000, PepperHeatClass = "hot", IsReadOnly = true } },
            { "serrano", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Serrano", PepperScovilleUnitMinimum = 10000, PepperScovilleUnitMaximum = 23000, PepperHeatClass = "medium-hot", IsReadOnly = true } },
            { "thaiChili", new Pepper
                { PepperId = Guid.NewGuid(), PepperName = "Thai Chili", PepperScovilleUnitMinimum = 50000, PepperScovilleUnitMaximum = 100000, PepperHeatClass = "medium-hot", IsReadOnly = true } }
        };
    }
}