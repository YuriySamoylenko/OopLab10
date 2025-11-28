using static OopProjectPartC.Core.Furniture;
using static OopProjectPartC.Core.Room;

namespace OopProjectPartC.Core
{
    public class Apartment : BaseEntity
    {
        private List<Room> Rooms = new List<Room>();

        private List<Furniture> AllFurniture = new List<Furniture>();

        private FurnitureAddRemoveHandler furnitureAddRemoveHandler;

        public Apartment(int bedRoomCount, FurnitureAddRemoveHandler furnitureAddRemoveHandler, FurnitureMovedHandler furnitureMovedHandler)
        {
            this.furnitureAddRemoveHandler = furnitureAddRemoveHandler;
            var bathroom = new Bathroom(8, furnitureMovedHandler);
            this.SubscribeRoom(bathroom);
            var kitched = new Kitchen(10, furnitureMovedHandler);
            this.SubscribeRoom(kitched);
            this.Rooms.Add(bathroom);
            this.Rooms.Add(kitched);
            for (int i = 0; i < bedRoomCount; i++)
            {
                var bedroom = new Bedroom(15, furnitureMovedHandler);
                this.SubscribeRoom(bedroom);
                this.Rooms.Add(bedroom);
            }
        }

        public List<Room> GetRooms()
        {
            return this.Rooms;
        }

        public override string ToString()
        {
            var result = $"Apartment {this.Id}\n";
            foreach (var item in this.Rooms.Order())
            {
                result += $"\t {item}";
            }

            return result;
        }

        public List<Furniture> GetAllFurniture()
        {
            return this.AllFurniture.ToList();
        }

        private void AddFurnitureEventHandler(Furniture furniture, Room room)
        {
            this.AllFurniture.Add(furniture);
        }

        private void RemoveFurnitureEventHandler(Furniture furniture, Room room)
        {
            this.AllFurniture.Remove(furniture);
        }

        private void SubscribeRoom(Room room)
        {
            room.FurnitureAdded += this.AddFurnitureEventHandler;
            room.FurnitureRemoved += this.RemoveFurnitureEventHandler;
            room.FurnitureAdded += this.furnitureAddRemoveHandler;
            room.FurnitureRemoved += this.furnitureAddRemoveHandler;
        }
    }
}
