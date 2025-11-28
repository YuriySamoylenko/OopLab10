using OopProjectPartC.Core;

namespace OopProjectPartC.Tests
{
    [TestClass]
    public class KitchenTests
    {
        [TestMethod]
        public void Furniture_Property_InitializesAsEmptyList()
        {
            // Arrange
            var kitchen = new Kitchen(10, ApartmentTests.TempFurnitureMovedEventHandlerStub);

            // Act & Assert
            Assert.IsNotNull(kitchen.GetFurniture());
            Assert.AreEqual(0, kitchen.GetFurniture().Count);
        }

        [TestMethod]
        public void Area_Property_SetCorrectly()
        {
            // Arrange
            var kitchen = new Kitchen(10, ApartmentTests.TempFurnitureMovedEventHandlerStub);

            // Act
            var area = kitchen.Area;

            // Assert
            Assert.IsTrue(area > 0);
            Assert.AreEqual(10, area);
        }

        [TestMethod]
        public void AddFurniture_AddsFurnitureToList()
        {
            // Arrange
            var kitchen = new Kitchen(10, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var table = new Table();

            // Act
            kitchen.AddFurniture(table);

            // Assert
            Assert.AreEqual(1, kitchen.GetFurniture().Count);
            CollectionAssert.Contains(kitchen.GetFurniture().ToList(), table);
        }

        [TestMethod]
        public void RemoveFurniture_RemovesFurnitureFromList()
        {
            // Arrange
            var kitchen = new Kitchen(10, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var table = new Table();
            kitchen.AddFurniture(table);

            // Act
            kitchen.RemoveFurniture(table);

            // Assert
            Assert.AreEqual(0, kitchen.GetFurniture().Count);
        }
    }
}
