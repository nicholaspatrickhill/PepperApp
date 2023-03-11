using PepperApp.Entities;

namespace PepperApp.Test
{
    [TestClass]
    public class PepperTest : TestBase
    {
        [TestMethod]
        [Description("Check to see that values passed as strings are written to console are as expected.")]
        public void PrintPepperToConsoleTest()
        {
            TestContext?.WriteLine("Validating that values passed are written to console as expected.");

            Pepper pep = new()
            {
                PepperName = "SomePepper",
                PepperScovilleUnitMinimum = 1000,
                PepperScovilleUnitMaximum = 5000
            };

            string expected = "The SomePepper has a SHU rating of 1000 - 5000";

            string actual = $"The {pep.PepperName} has a SHU rating of {pep.PepperScovilleUnitMinimum} - {pep.PepperScovilleUnitMaximum}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Check to see if object added is a type of Pepper.")]
        public void IsInstanceOfTypeTest()
        {
            TestContext?.WriteLine("Validating that object added is a type of Pepper.");

            Pepper pep = new()
            {
                PepperName = "SomePepper",
                PepperScovilleUnitMinimum = 1000,
                PepperScovilleUnitMaximum = 5000
            };

            Assert.IsInstanceOfType(pep, typeof(Pepper));
        }
    }
}