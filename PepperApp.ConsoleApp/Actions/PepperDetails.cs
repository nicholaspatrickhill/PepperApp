using PepperApp.DataTransferObject;

namespace PepperApp.ConsoleApp
{
    public class PepperDetails
    {
        // Returns a string that displays information about a pepper in the database
        public static string PepperDetailsString(PepperDto pepperDto)
        {
            return $"The {pepperDto.PepperName} is a {pepperDto.PepperHeatClass} pepper with SHU rating of {pepperDto.PepperScovilleUnitMinimum} - {pepperDto.PepperScovilleUnitMaximum}";
        }
    }
}
