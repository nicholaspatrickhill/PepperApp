namespace PepperApp.DataTransferObject
{
    public class PepperDto
    {
        public Guid PepperId { get; set; }
        public string? PepperName { get; set; }
        public string? PepperHeatClass { get; set; }
        public int PepperScovilleUnitMinimum { get; set; }
        public int PepperScovilleUnitMaximum { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
