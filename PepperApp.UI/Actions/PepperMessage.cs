using PepperApp.DataTransferObject;
using static System.Console;

namespace PepperApp.UI
{
    public class PepperMessage
    {
        // Console message that displays information about a pepper in the database
        public static string PrintPepperDetails(PepperDto pepperDto)
        {
            return $"The {pepperDto.PepperName} is a {pepperDto.PepperHeatClass} pepper with SHU rating of {pepperDto.PepperScovilleUnitMinimum} - {pepperDto.PepperScovilleUnitMaximum}";
        }
    }
}
