public class ShapeTile
{
    public CubeCoordinate Position { get; }
    public ShapeTileStrength Strength { get; }

    public ShapeTile(CubeCoordinate position, ShapeTileStrength strength){
        Position = position;
        Strength = strength;
    }
}

public enum ShapeTileStrength
{
    Primary,
    SplitPrime,
    Secondary,
    Tertiary
}
