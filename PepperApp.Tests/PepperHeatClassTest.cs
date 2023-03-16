using PepperApp.DataTransferObject;
using PepperApp.Services;

namespace PepperApp.Test
{
    // scoville ranges sourced from chilipeppermadness.com
    // mild 0-5000
    // medium 5001-15000
    // mediumHot 15001-100000
    // hot 100001 - 350000
    // superhot 350001+

    [TestClass]
    public class PepperHeatClassTest : TestBase
    {
        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as mild.")]
        public void MildHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as mild.");

            PepperDto pep = new()
            {
                PepperName = "SomeMildPepper",
                PepperScovilleUnitMinimum = 0,
                PepperScovilleUnitMaximum = 5000
            };

            pep.PepperHeatClass = PepperService.AssignPepperHeatClass(pep.PepperScovilleUnitMaximum);

            string expected = "mild";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as medium.")]
        public void MediumHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as medium.");

            PepperDto pep = new()
            {
                PepperName = "SomeMediumPepper",
                PepperScovilleUnitMinimum = 5001,
                PepperScovilleUnitMaximum = 15000
            };

            pep.PepperHeatClass = PepperService.AssignPepperHeatClass(pep.PepperScovilleUnitMaximum);

            string expected = "medium";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as medium-hot.")]
        public void MediumHotHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as medium.");

            PepperDto pep = new()
            {
                PepperName = "SomeMediumHotPepper",
                PepperScovilleUnitMinimum = 15001,
                PepperScovilleUnitMaximum = 100000
            };

            pep.PepperHeatClass = PepperService.AssignPepperHeatClass(pep.PepperScovilleUnitMaximum);

            string expected = "medium-hot";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as hot.")]
        public void HotHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as hot.");

            PepperDto pep = new()
            {
                PepperName = "SomeHotPepper",
                PepperScovilleUnitMinimum = 100001,
                PepperScovilleUnitMaximum = 350000
            };

            pep.PepperHeatClass = PepperService.AssignPepperHeatClass(pep.PepperScovilleUnitMaximum);

            string expected = "hot";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as super-hot.")]
        public void SuperHotHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as super-hot.");

            PepperDto pep = new()
            {
                PepperName = "SomeSuperHotPepper",
                PepperScovilleUnitMinimum = 350001,
                PepperScovilleUnitMaximum = 1000000
            };

            pep.PepperHeatClass = PepperService.AssignPepperHeatClass(pep.PepperScovilleUnitMaximum);

            string expected = "super-hot";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }
    }
}