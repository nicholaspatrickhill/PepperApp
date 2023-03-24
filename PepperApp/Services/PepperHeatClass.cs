namespace PepperApp.Services
{
    public class PepperHeatClass
    {
        // Determines the heat class of a pepper based on its Scoville unit range and returns its heat class as a string
        public static string AssignPepperHeatClass(int PepperScovilleUnitMax)
        {
            // scoville ranges sourced from chilipeppermadness.com
            // mild 0-5000
            // medium 5001-15000
            // mediumHot 15001-100000
            // hot 100001 - 350000
            // superhot 350001+

            if (PepperScovilleUnitMax <= 5000)
            {
                return "mild";
            }
            else if (PepperScovilleUnitMax <= 15000)
            {
                return "medium";
            }
            else if (PepperScovilleUnitMax <= 100000)
            {
                return "medium-hot";
            }
            else if (PepperScovilleUnitMax <= 350000)
            {
                return "hot";
            }
            else
            {
                return "super-hot";
            }
        }
    }
}
