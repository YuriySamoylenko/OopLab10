using OopProjectPartC.Core;

namespace OopProjectPartC.Tests
{
    [TestClass]
    public class ChairTests
    {
        [TestMethod]
        public void NumberOfLegs_Property_ReturnsValidValue()
        {
            // Arrange
            var chair = new Chair();

            // Act
            var place = chair.Place;

            // Assert
            Assert.AreEqual(4, chair.NumberOfLegs);
        }

        [TestMethod]
        public void Move_UpdatesPlace()
        {
            // Arrange
            var chair = new Chair();
            var newPlace = Place.West;

            // Act
            chair.Move(newPlace);

            // Assert
            Assert.AreEqual(newPlace, chair.Place);
        }
    }
}
