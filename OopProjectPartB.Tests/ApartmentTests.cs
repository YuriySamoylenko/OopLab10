using OopProjectPartC.Core;

namespace OopProjectPartC.Tests
{
    [TestClass]
    public class ApartmentTests
    {
        public static void AddFurnitureEventHandlerMockStub(Furniture furniture, Room room)
        {
        }

        public static void TempFurnitureMovedEventHandlerStub(Furniture furniture)
        {
        }

        [TestMethod]
        public void Constructor_CreatesCorrectNumberOfRooms()
        {
            var apartment = new Apartment(2, AddFurnitureEventHandlerMockStub, TempFurnitureMovedEventHandlerStub);

            var rooms = apartment.GetRooms();
            Assert.AreEqual(4, rooms.Count);

            Assert.IsTrue(rooms.Any(r => r is Bathroom));
            Assert.IsTrue(rooms.Any(r => r is Kitchen));
            Assert.AreEqual(2, rooms.Count(r => r is Bedroom));
        }

        [TestMethod]
        public void Constructor_WithZeroBedrooms_CreatesTwoRooms()
        {
            var apartment = new Apartment(0, AddFurnitureEventHandlerMockStub, TempFurnitureMovedEventHandlerStub);
            Assert.AreEqual(2, apartment.GetRooms().Count);
        }

        [TestMethod]
        public void ToString_ContainsApartmentId_AndOrderedRoomsWithFurniture()
        {
            var apartment = new Apartment(1, AddFurnitureEventHandlerMockStub, TempFurnitureMovedEventHandlerStub);
            var bedroom = apartment.GetRooms().OfType<Bedroom>().First();
            bedroom.AddFurniture(new Bed());
            bedroom.AddFurniture(new Chair());

            var str = apartment.ToString();

            Assert.IsTrue(str.Contains("Apartment"));
            Assert.IsTrue(str.Contains(apartment.Id.ToString()));
            Assert.IsTrue(str.Contains("Bathroom"));
            Assert.IsTrue(str.Contains("Bedroom"));
            Assert.IsTrue(str.Contains("Kitchen"));
            Assert.IsTrue(str.Contains("Bed"));
            Assert.IsTrue(str.Contains("Chair"));
        }
    }
}
