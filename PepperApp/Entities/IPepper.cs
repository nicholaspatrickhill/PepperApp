namespace PepperApp.Entities
{
    public interface IPepper
    {
        Guid PepperId { get; set; }
        bool IsReadOnly { get; set; }
        string? PepperHeatClass { get; set; }
        string? PepperName { get; set; }
        int PepperScovilleUnitMaximum { get; set; }
        int PepperScovilleUnitMinimum { get; set; }
    }
}