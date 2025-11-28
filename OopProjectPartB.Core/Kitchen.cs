using static OopProjectPartC.Core.Furniture;

namespace OopProjectPartC.Core
{
    public class Kitchen : Room
    {
        public Kitchen(float area, FurnitureMovedHandler furnitureMovedHandler) : base(area, furnitureMovedHandler)
        {
        }

        public override void AddFurniture(Furniture furniture)
        {
            if (furniture is Bed)
            {
                throw new ArgumentException($"You can't put {nameof(Bed)} to {nameof(Kitchen)}");
            }

            base.AddFurniture(furniture);
        }
    }
}
