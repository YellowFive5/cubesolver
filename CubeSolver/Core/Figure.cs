namespace Core;

public enum Rotate
{
    X90,
    X180,
    X270,
    Y90,
    Y180,
    Y270,
    Z90,
    Z180,
    Z270,
}

public class Figure
{
    public int Id { get; init; }
    public Color Color { get; init; }
    public int Dimension { get; init; }
    public int Cubes { get; init; }
    public int MaxHigh { get; init; }
    public int MaxWidth { get; init; }
    public int MaxDepth { get; init; }
    public int[,,] InitialMap3x3 { get; init; }
    public int[,,] ActualMap3x3 { get; set; }
}