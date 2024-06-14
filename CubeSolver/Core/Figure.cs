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
        switch (rotationAngle)
        {
            case Angle._90cvp:
            case Angle._90ccvn:
                var tempMapCopy = ActualMap3x3.Clone() as int[,,];
                for (var k = 0; k < 3; k++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        for (var i = 0; i < 3; i++)
                        {
                            var swap = rotationAxis switch
                            {
                                Axis.X => rotationAngle is Angle._90cvp
                                              ? (Action)(() => ActualMap3x3[j, i, k] = tempMapCopy[2 - i, j, k])
                                              : (Action)(() => ActualMap3x3[i, j, k] = tempMapCopy[j, 2 - i, k]),
                                Axis.Y => rotationAngle is Angle._90cvp
                                              ? (Action)(() => ActualMap3x3[j, k, i] = tempMapCopy[j, 2 - i, k])
                                              : (Action)(() => ActualMap3x3[j, k, i] = tempMapCopy[j, i, 2 - k]),
                                Axis.Z => rotationAngle is Angle._90cvp
                                              ? (Action)(() => ActualMap3x3[j, k, i] = tempMapCopy[2 - i, k, j])
                                              : (Action)(() => ActualMap3x3[j, k, i] = tempMapCopy[i, k, 2 - j]),
                                _ => throw new ArgumentOutOfRangeException(nameof(rotationAxis), rotationAxis, null)
                            };
                            swap.Invoke();
                        }
                    }
                }

                break;
            case Angle._180cvp:
                Rotate(rotationAxis, Angle._90cvp);
                Rotate(rotationAxis, Angle._90cvp);
                break;
            case Angle._270cvp:
                Rotate(rotationAxis, Angle._90cvp);
                Rotate(rotationAxis, Angle._90cvp);
                Rotate(rotationAxis, Angle._90cvp);
                break;
            case Angle._180ccvn:
                Rotate(rotationAxis, Angle._90ccvn);
                Rotate(rotationAxis, Angle._90ccvn);
                break;
            case Angle._270ccvn:
                Rotate(rotationAxis, Angle._90ccvn);
                Rotate(rotationAxis, Angle._90ccvn);
                Rotate(rotationAxis, Angle._90ccvn);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
        }
    }
}