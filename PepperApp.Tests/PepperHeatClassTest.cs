using PepperApp.Entities;

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

            Pepper pep = new()
            {
                PepperName = "SomeMildPepper",
                PepperScovilleUnitMin = 0,
                PepperScovilleUnitMax = 5000
            };

            pep.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pep.PepperScovilleUnitMax);

            string expected = "mild";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as medium.")]
        public void MediumHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as medium.");

            Pepper pep = new()
            {
                PepperName = "SomeMediumPepper",
                PepperScovilleUnitMin = 5001,
                PepperScovilleUnitMax = 15000
            };

            pep.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pep.PepperScovilleUnitMax);

            string expected = "medium";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as medium-hot.")]
        public void MediumHotHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as medium.");

            Pepper pep = new()
            {
                PepperName = "SomeMediumHotPepper",
                PepperScovilleUnitMin = 15001,
                PepperScovilleUnitMax = 100000
            };

            pep.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pep.PepperScovilleUnitMax);

            string expected = "medium-hot";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as hot.")]
        public void HotHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as hot.");

            Pepper pep = new()
            {
                PepperName = "SomeHotPepper",
                PepperScovilleUnitMin = 100001,
                PepperScovilleUnitMax = 350000
            };

            pep.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pep.PepperScovilleUnitMax);

            string expected = "hot";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Checks to see if PepperHeatClass returns as super-hot.")]
        public void SuperHotHeatClassTest()
        {
            TestContext?.WriteLine("Validates that PepperHeatClass returns as super-hot.");

            Pepper pep = new()
            {
                PepperName = "SomeSuperHotPepper",
                PepperScovilleUnitMin = 350001,
                PepperScovilleUnitMax = 1000000
            };

            pep.PepperHeatClass = PepperHeatClass.AssignPepperHeatClass(pep.PepperScovilleUnitMax);

            string expected = "super-hot";

            string? actual = pep.PepperHeatClass;

            Assert.AreEqual(expected, actual);
        }
    }
}