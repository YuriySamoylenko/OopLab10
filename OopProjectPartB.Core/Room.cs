using static OopProjectPartC.Core.Furniture;

namespace OopProjectPartC.Core
{
    public abstract class Room : BaseEntity, IComparable<Room>
    {
        private string Name => this.GetType().Name;

        private FurnitureMovedHandler furnitureMovedHandler;

        public delegate void FurnitureAddRemoveHandler(Furniture furniture, Room room);

        public event FurnitureAddRemoveHandler? FurnitureAdded;
        public event FurnitureAddRemoveHandler? FurnitureRemoved;

        protected IList<Furniture> Furniture { get; } = new List<Furniture>();

        public float Area { get; }

        public Room(float area, FurnitureMovedHandler furnitureMovedHandler)
        {
            this.Area = area;
            this.furnitureMovedHandler = furnitureMovedHandler;
        }

        public IList<Furniture> GetFurniture()
        {
            return this.Furniture;
        }

        public virtual void AddFurniture(Furniture furniture)
        {
            furniture.FurnitureMoved += furnitureMovedHandler;
            this.Furniture.Add(furniture);
            this.FurnitureAdded?.Invoke(furniture, this);
        }

        public virtual void RemoveFurniture(Furniture furniture)
        {
            this.Furniture.Remove(furniture);
            furniture.FurnitureMoved -= furnitureMovedHandler;
            this.FurnitureRemoved?.Invoke(furniture, this);
        }

        public override string ToString()
        {
            var result = $"{this.Name} {this.Id}\n";
            foreach (var item in this.Furniture.Order())
            {
                result += $"\t\t {item}\n";
            }

            return result;
        }

        public int CompareTo(Room? other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }
    }
}
