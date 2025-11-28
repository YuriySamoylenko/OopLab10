using OopProjectPartC.Core;

namespace OopProjectPartC
{
    public class Program
    {
        public static List<Apartment> db = new List<Apartment>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var mainMenu = new List<KeyValuePair<string, Action<List<Apartment>>>>();
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Create Apartment", CreateApartment));
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Fill all empty Apartments with Furniture", FillApartmentsWithFurniture));
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Add Furniture to room", AddFurnitureToRoom));
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Use all Furniture", UseAllFurniture));
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Move furniture in room", MoveFurniture));
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Remove furniture", RemoveFurniture));
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Remove apartment", RemoveApartment));
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Show all furniture", ShowAllFurniture));
            mainMenu.Add(new KeyValuePair<string, Action<List<Apartment>>>("Display", Show));

            RunMenu("Main menu", mainMenu);
        }

        static void RunMenu(string name, IList<KeyValuePair<string, Action<List<Apartment>>>> menu)
        {
            while (menu.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine(name);
                Console.WriteLine();
                for (int i = 0; i < menu.Count; i++)
                {
                    var menuItem = menu[i];
                    Console.WriteLine($"{i + 1} - {menuItem.Key}");
                }
                Console.WriteLine("0 - Exit");
                Console.WriteLine();

                var value = ReadUserNumber($"Enter menu number: ", 0, menu.Count);
                if (value == 0)
                {
                    Console.WriteLine($"Exiting {name}");
                    break;
                }
                else
                {
                    var item = menu[value - 1];
                    item.Value(db);
                }
            }
        }

        public static void CreateApartment(List<Apartment> database)
        {
            var bedroomsCount = ReadUserNumber("Enter bedroom count (1 - 10): ", 1, 10);
            var apartment = new Apartment(bedroomsCount, AddFurnitureEventHandler, FurnitureMovedEventHandler);
            database.Add(apartment);
        }

        public static void AddFurnitureEventHandler(Furniture furniture, Room room)
        {
            Console.WriteLine();
            Console.WriteLine($"Event raised\n{furniture} added or removed. \n{room}");
            Console.WriteLine();
        }

        public static void FurnitureMovedEventHandler(Furniture furniture)
        {
            Console.WriteLine();
            Console.WriteLine($"Event raised\n{furniture} moved to \n{furniture.Place}");
            Console.WriteLine();
        }

        public static void FillApartmentsWithFurniture(List<Apartment> database)
        {
            foreach (var apartment in database)
            {
                var rooms = apartment.GetRooms();
                foreach (var room in rooms)
                {
                    TryAddFurnitureToRoom(room, new Bed());
                    TryAddFurnitureToRoom(room, new Table());
                    TryAddFurnitureToRoom(room, new Chair());
                    TryAddFurnitureToRoom(room, new Chair());
                    TryAddFurnitureToRoom(room, new Chair());
                }
            }
        }

        public static void AddFurnitureToRoom(List<Apartment> database)
        {
            if (database.Count == 0)
            {
                return;
            }

            var room = GetRoom(database);
            var furnitureType = ReadUserNumber($"Enter furniture type (0 - 3)\nBed - 0, Table - 1, Chair - 2: ", 0, 2);
            var furnitureTypes = new Dictionary<int, Func<int, Furniture>>
            {
                { 0, type => new Bed() },
                { 1, type => new Table() },
                { 2, type => new Chair() },
            };
            var createFurniture = furnitureTypes[furnitureType];
            var furniture = createFurniture(furnitureType);
            TryAddFurnitureToRoom(room, furniture);
        }

        public static Room GetRoom(List<Apartment> database)
        {
            var apartmentIndex = ReadUserNumber($"Enter apartment index (0 - {database.Count - 1}): ", 0, database.Count - 1);
            var apartment = database[apartmentIndex];
            var rooms = apartment.GetRooms();
            var roomIndex = ReadUserNumber($"Enter room index (0 - {rooms.Count - 1}): ", 0, rooms.Count - 1);
            var room = rooms[roomIndex];
            return room;
        }

        public static void MoveAllFurnitureTo(Place place, List<Apartment> database)
        {
            foreach (var apartment in database)
            {
                var rooms = apartment.GetRooms().Order();
                foreach (var room in rooms)
                {
                    foreach (var furniture in room.GetFurniture())
                    {
                        MoveFurniture(furniture, place);
                    }
                }
            }
        }

        public static void MoveFurniture(IFurniture furniture, Place place)
        {
            furniture.Move(place);
        }

        public static void UseAllFurniture(List<Apartment> database)
        {
            foreach (var apartment in database)
            {
                var rooms = apartment.GetRooms().Order();
                foreach (var room in rooms)
                {
                    foreach (var furniture in room.GetFurniture())
                    {
                        var result = UseFurniture(furniture);
                        Console.WriteLine(result);
                    }
                }
            }
        }

        public static string UseFurniture(IUsableFurniture usable)
        {
            return usable.Use();
        }

        public static void Show(List<Apartment> database)
        {
            foreach (var apartment in database)
            {
                Console.WriteLine(apartment);
            }
        }

        public static void TryAddFurnitureToRoom(Room room, Furniture furniture)
        {
            try
            {
                room.AddFurniture(furniture);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void RemoveFurniture(List<Apartment> database)
        {
            if (database.Count == 0)
            {
                return;
            }

            var apartmentIndex = ReadUserNumber($"Enter apartment index (0 - {database.Count - 1}): ", 0, database.Count - 1);
            var apartment = database[apartmentIndex];
            var rooms = apartment.GetRooms();
            var roomIndex = ReadUserNumber($"Enter room index (0 - {rooms.Count - 1}): ", 0, rooms.Count - 1);
            var room = rooms[roomIndex];
            var furnitures = room.GetFurniture();
            if (furnitures.Count > 0)
            {
                var furnitureIndex = ReadUserNumber($"Enter furniture index (0 - {furnitures.Count - 1}): ", 0, furnitures.Count - 1);
                var furniture = furnitures[furnitureIndex];
                room.RemoveFurniture(furniture);
                Console.WriteLine($"{furniture} removed");
            }
        }

        public static void RemoveApartment(List<Apartment> database)
        {
            if (database.Count == 0)
            {
                return;
            }

            var apartmentIndex = ReadUserNumber($"Enter apartment index (0 - {database.Count - 1}): ", 0, database.Count - 1);
            database.RemoveAt(apartmentIndex);
            Console.WriteLine($"Apartment at {apartmentIndex} removed");
        }

        public static void MoveFurniture(List<Apartment> database)
        {
            if (database.Count == 0)
            {
                return;
            }

            var room = GetRoom(database);
            var furnitures = room.GetFurniture();
            var furnitureIndex = ReadUserNumber($"Enter furniture index (0 - {furnitures.Count - 1}): ", 0, furnitures.Count - 1);
            var furniture = furnitures[furnitureIndex];
            var newPlace = ReadUserNumber($"Current place - {furniture.Place}, move to (0 - 4)\n{Place.North} - {(int)Place.North},{Place.South} - {(int)Place.South},{Place.East} - {(int)Place.East},{Place.West} - {(int)Place.West}: ", 0, 4);
            MoveFurniture(furniture, (Place)newPlace);
            Console.WriteLine(room);
        }

        public static void ShowAllFurniture(List<Apartment> database)
        {
            foreach (var apartment in database)
            {
                var allFurniture = apartment.GetAllFurniture();
                foreach (var item in allFurniture)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static int ReadUserNumber(string message, int from, int to)
        {
            while (true)
            {
                Console.Write(message);
                var value = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Value is empty");
                }
                else if (int.TryParse(value, out int number))
                {
                    if (number < from || number > to)
                    {
                        Console.WriteLine("Value is out of range");
                    }
                    else
                    {
                        return number;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format");
                }
            }
        }
    }
}
