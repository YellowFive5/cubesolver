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
        var tempMapCopy = ActualMap3x3.Clone() as int[,,];
        switch (rotationAngle)
        {
            case Angle._90cvp:
                switch (rotationAxis)
                {
                    case Axis.X:
                        for (var k = 0; k < 3; k++)
                        {
                            for (var j = 0; j < 3; j++)
                            {
                                for (var i = 0; i < 3; i++)
                                {
                                    ActualMap3x3[j, i, k] = tempMapCopy[2 - i, j, k];
                                }
                            }
                        }

                        break;
                    case Axis.Y:
                        for (var k = 0; k < 3; k++)
                        {
                            for (var j = 0; j < 3; j++)
                            {
                                for (var i = 0; i < 3; i++)
                                {
                                    ActualMap3x3[j, k, i] = tempMapCopy[j, 2 - i, k];
                                }
                            }
                        }

                        break;
                    case Axis.Z:
                        // todo realization
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAxis), rotationAxis, null);
                }

                break;
            case Angle._90ccvn:
                switch (rotationAxis)
                {
                    case Axis.X:
                        for (var k = 0; k < 3; k++)
                        {
                            for (var j = 0; j < 3; j++)
                            {
                                for (var i = 0; i < 3; i++)
                                {
                                    ActualMap3x3[i, j, k] = tempMapCopy[j, 2 - i, k];
                                }
                            }
                        }

                        break;
                    case Axis.Y:
                        for (var k = 0; k < 3; k++)
                        {
                            for (var j = 0; j < 3; j++)
                            {
                                for (var i = 0; i < 3; i++)
                                {
                                    ActualMap3x3[j, k, i] = tempMapCopy[j, i, 2 - k];
                                }
                            }
                        }

                        break;
                    case Axis.Z:
                        // todo realization
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rotationAxis), rotationAxis, null);
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