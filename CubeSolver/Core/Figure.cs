namespace Core;

public enum Axis
{
    X,
    Y,
    Z
}

public enum Angle
{
    _90cvp,
    _180cvp,
    _270cvp,
    _90ccvn,
    _180ccvn,
    _270ccvn
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

    public void Rotate(Axis rotationAxis, Angle rotationAngle)
    {
    }
}