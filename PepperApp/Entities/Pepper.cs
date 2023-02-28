namespace PepperApp.Entities
{
    public class Pepper : IPepper, IReadOnlyPepper
    {
        public Guid Id { get; set; }
        public string? PepperName { get; set; }
        public string? PepperHeatClass { get; set; }
        public int PepperScovilleUnitMin { get; set; }
        public int PepperScovilleUnitMax { get; set; }
        public bool IsReadOnly { get; set; }
    }
}