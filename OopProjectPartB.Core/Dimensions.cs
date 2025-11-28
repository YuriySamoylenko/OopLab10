namespace OopProjectPartC.Core
{
    public record struct Dimensions(float Width, float Height)
    {
        public override string ToString() => $"{Width:F2} × {Height:F2} m";
    }
}
