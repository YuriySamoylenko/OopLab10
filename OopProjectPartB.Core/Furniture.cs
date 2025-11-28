namespace OopProjectPartC.Core
{
    public abstract class Furniture : BaseEntity, IFurniture, IUsableFurniture, IComparable<Furniture>
    {
        private string Name => this.GetType().Name;
        public int NumberOfLegs { get; protected set; } = 4;

        public delegate void FurnitureMovedHandler(Furniture furniture);
        public event FurnitureMovedHandler? FurnitureMoved;

        public Place Place
        {
            get;
            protected set;
        }

        public void Move(Place place)
        {
            if (this.Place != place)
            {
                this.Place = place;
                this.FurnitureMoved?.Invoke(this);
            }
        }

        public abstract string Use();

        public override string ToString()
        {
            return $"{this.Name} {this.Place} {this.Id}";
        }

        public int CompareTo(Furniture? other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }
    }
}
