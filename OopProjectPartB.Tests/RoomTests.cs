using OopProjectPartC.Core;

namespace OopProjectPartC.Tests
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void Room_Constructor_SetsAreaCorrectly()
        {
            var room = new Bedroom(20f, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            Assert.AreEqual(20f, room.Area);
        }

        [TestMethod]
        public void AddFurniture_And_RemoveFurniture_Works()
        {
            var room = new Kitchen(12f, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var chair = new Chair();

            room.AddFurniture(chair);
            Assert.IsTrue(room.GetFurniture().Contains(chair));

            room.RemoveFurniture(chair);
            Assert.IsFalse(room.GetFurniture().Contains(chair));
        }

        [TestMethod]
        public void Bathroom_RejectsBed_ThrowsException()
        {
            var bathroom = new Bathroom(6f, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var bed = new Bed();

            var ex = Assert.ThrowsException<ArgumentException>(() =>
                bathroom.AddFurniture(bed));

            Assert.IsTrue(ex.Message.Contains("Bed"));
            Assert.IsTrue(ex.Message.Contains("Bathroom"));
        }

        [TestMethod]
        public void Kitchen_RejectsBed_ThrowsException()
        {
            var kitchen = new Kitchen(10f, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var bed = new Bed();

            var ex = Assert.ThrowsException<ArgumentException>(() =>
                kitchen.AddFurniture(bed));

            Assert.IsTrue(ex.Message.Contains("Bed"));
            Assert.IsTrue(ex.Message.Contains("Kitchen"));
        }

        [TestMethod]
        public void Bedroom_AcceptsBed_NoException()
        {
            var bedroom = new Bedroom(15f, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            var bed = new Bed();

            bedroom.AddFurniture(bed);

            Assert.IsTrue(bedroom.GetFurniture().Contains(bed));
        }

        [TestMethod]
        public void ToString_ContainsRoomName_Id_AndFurniture()
        {
            var kitchen = new Kitchen(10f, ApartmentTests.TempFurnitureMovedEventHandlerStub);
            kitchen.AddFurniture(new Chair());
            kitchen.AddFurniture(new Table());

            var str = kitchen.ToString();
            Assert.IsTrue(str.Contains("Kitchen"));
            Assert.IsTrue(str.Contains(kitchen.Id.ToString()));
            Assert.IsTrue(str.Contains("Chair"));
            Assert.IsTrue(str.Contains("Table"));
        }

        [TestMethod]
        public void CompareTo_SortsRoomsByTypeName()
        {
            var rooms = new Room[]
            {
                new Bedroom(15, ApartmentTests.TempFurnitureMovedEventHandlerStub),
                new Kitchen(10, ApartmentTests.TempFurnitureMovedEventHandlerStub),
                new Bathroom(8, ApartmentTests.TempFurnitureMovedEventHandlerStub),
                new Bedroom(18, ApartmentTests.TempFurnitureMovedEventHandlerStub),
            };

            var sorted = rooms.OrderBy(r => r).ToArray();

            Assert.AreEqual(rooms[0], sorted[0]);
            Assert.AreEqual(rooms[1], sorted[1]);
            Assert.AreEqual(rooms[2], sorted[2]);
            Assert.AreEqual(rooms[3], sorted[3]);
        }
    }
}
