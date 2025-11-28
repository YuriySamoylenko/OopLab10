using OopProjectPartC.Core;

namespace OopProjectPartC.Tests
{
    [TestClass]
    public class BathroomTests
    {
        [TestMethod]
        public void Area_Property_SetCorrectly()
        {
            // Arrange
            var bathroom = new Bathroom(8, ApartmentTests.TempFurnitureMovedEventHandlerStub);

            // Act
            var area = bathroom.Area;

            // Assert
            Assert.IsTrue(area > 0);
            Assert.AreEqual(8, area);
        }

        [TestMethod]
        public void AddFurniture_AddsFurnitureToList()
        {
            // Arrange
            var bathroom = new Bathroom(8, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var chair = new Chair();

            // Act
            bathroom.AddFurniture(chair);

            // Assert
            Assert.AreEqual(1, bathroom.GetFurniture().Count);
            CollectionAssert.Contains(bathroom.GetFurniture().ToList(), chair);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddInvalidFurniture_ThrowsException()
        {
            // Arrange
            var bathroom = new Bathroom(8, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var bed = new Bed();

            // Act
            bathroom.AddFurniture(bed);
        }

        [TestMethod]
        public void RemoveFurniture_RemovesFurnitureFromList()
        {
            // Arrange
            var bathroom = new Bathroom(8, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var chair = new Chair();
            bathroom.AddFurniture(chair);

            // Act
            bathroom.RemoveFurniture(chair);

            // Assert
            Assert.AreEqual(0, bathroom.GetFurniture().Count);
        }
    }
}
