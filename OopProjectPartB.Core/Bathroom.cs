using static OopProjectPartC.Core.Furniture;

namespace OopProjectPartC.Core
{
    public class Bathroom : Room
    {
        public Bathroom(float area, FurnitureMovedHandler furnitureMovedHandler) : base(area, furnitureMovedHandler)
        {
        }

        public override void AddFurniture(Furniture furniture)
        {
            if (furniture is Bed)
            {
                throw new ArgumentException($"You can't put {nameof(Bed)} to {nameof(Bathroom)}");
            }

            base.AddFurniture(furniture);
        }
    }
}
