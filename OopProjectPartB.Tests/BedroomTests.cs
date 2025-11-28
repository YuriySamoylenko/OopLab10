using OopProjectPartC.Core;

namespace OopProjectPartC.Tests
{
    [TestClass]
    public class BedroomTests
    {
        [TestMethod]
        public void Furniture_Property_InitializesAsEmptyList()
        {
            // Arrange
            var bedroom = new Bedroom(15, ApartmentTests.TempFurnitureMovedEventHandlerStub);

            // Act & Assert
            Assert.IsNotNull(bedroom.GetFurniture());
            Assert.AreEqual(0, bedroom.GetFurniture().Count);
        }

        [TestMethod]
        public void Area_Property_SetCorrectly()
        {
            // Arrange
            var bedroom = new Bedroom(15, ApartmentTests.TempFurnitureMovedEventHandlerStub);

            // Act
            var area = bedroom.Area;

            // Assert
            Assert.IsTrue(area > 0);
            Assert.AreEqual(15, area);
        }

        [TestMethod]
        public void AddFurniture_AddsFurnitureToList()
        {
            // Arrange
            var bedroom = new Bedroom(15, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var bed = new Bed();

            // Act
            bedroom.AddFurniture(bed);

            // Assert
            Assert.AreEqual(1, bedroom.GetFurniture().Count);
            CollectionAssert.Contains(bedroom.GetFurniture().ToList(), bed);
        }

        [TestMethod]
        public void RemoveFurniture_RemovesFurnitureFromList()
        {
            // Arrange
            var bedroom = new Bedroom(15, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var bed = new Bed();
            bedroom.AddFurniture(bed);

            // Act
            bedroom.RemoveFurniture(bed);

            // Assert
            Assert.AreEqual(0, bedroom.GetFurniture().Count);
        }
    }
}
