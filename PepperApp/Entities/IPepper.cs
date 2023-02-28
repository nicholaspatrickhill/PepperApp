namespace PepperApp.Entities
{
    public interface IPepper
    {
        Guid Id { get; set; }
        bool IsReadOnly { get; set; }
        string? PepperHeatClass { get; set; }
        string? PepperName { get; set; }
        int PepperScovilleUnitMax { get; set; }
        int PepperScovilleUnitMin { get; set; }
    }
}