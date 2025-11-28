using OopProjectPartC.Core;

namespace OopProjectPartC.Tests
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        public void NumberOfLegs_Property_ReturnsValidValue()
        {
            // Arrange
            var table = new Table();

            // Act
            var place = table.Place;

            // Assert
            Assert.AreEqual(4, table.NumberOfLegs);
        }

        [TestMethod]
        public void Move_UpdatesPlace()
        {
            // Arrange
            var table = new Table();
            var newPlace = Place.South;

            // Act
            table.Move(newPlace);

            // Assert
            Assert.AreEqual(newPlace, table.Place);
        }
    }
}
