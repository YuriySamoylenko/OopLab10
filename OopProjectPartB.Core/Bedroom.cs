using static OopProjectPartC.Core.Furniture;

namespace OopProjectPartC.Core
{
    public class Bedroom : Room
    {
        public Bedroom(float area, FurnitureMovedHandler furnitureMovedHandler) : base(area, furnitureMovedHandler)
        {
        }
    }
}
