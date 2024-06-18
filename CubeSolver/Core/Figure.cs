#region Usings

using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Core;

public enum Axis
{
    X,
    Y,
    Z
}

public enum Angle
{
    _90cvp = 1,
    _180cvp,
    _270cvp,
    _90ccvn,
    _180ccvn,
    _270ccvn = 6,
    _0
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
    public Matrix<double>[] InitialMap3x3 { get; init; }
    public Matrix<double>[] ActualMap3x3 { get; set; }

    public void Rotate(Axis rotationAxis, Angle rotationAngle)
    {
        switch (rotationAngle)
        {
            case Angle._90cvp:
            case Angle._90ccvn:
                double[][,] tempMapCopy = [ActualMap3x3[0].ToArray(), ActualMap3x3[1].ToArray(), ActualMap3x3[2].ToArray()];
                double[][,] tempRotatedOutput = [Matrix<double>.Build.Dense(3, 3, 0).ToArray(), Matrix<double>.Build.Dense(3, 3, 0).ToArray(), Matrix<double>.Build.Dense(3, 3, 0).ToArray()];
                for (var k = 0; k < 3; k++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        for (var i = 0; i < 3; i++)
                        {
                            var swap = rotationAxis switch
                            {
                                Axis.X => rotationAngle is Angle._90cvp
                                              ? (Action)(() => tempRotatedOutput[j][i, k] = tempMapCopy[2 - i][j, k])
                                              : (Action)(() => tempRotatedOutput[i][j, k] = tempMapCopy[j][2 - i, k]),
                                Axis.Y => rotationAngle is Angle._90cvp
                                              ? (Action)(() => tempRotatedOutput[j][k, i] = tempMapCopy[j][2 - i, k])
                                              : (Action)(() => tempRotatedOutput[j][k, i] = tempMapCopy[j][i, 2 - k]),
                                Axis.Z => rotationAngle is Angle._90cvp
                                              ? (Action)(() => tempRotatedOutput[j][k, i] = tempMapCopy[2 - i][k, j])
                                              : (Action)(() => tempRotatedOutput[j][k, i] = tempMapCopy[i][k, 2 - j]),
                                _ => throw new ArgumentOutOfRangeException(nameof(rotationAxis), rotationAxis, null)
                            };
                            swap.Invoke();
                        }
                    }
                }

                ActualMap3x3 = [Matrix<double>.Build.DenseOfArray(tempRotatedOutput[0]), Matrix<double>.Build.DenseOfArray(tempRotatedOutput[1]), Matrix<double>.Build.DenseOfArray(tempRotatedOutput[2])];
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
            case Angle._0:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rotationAngle), rotationAngle, null);
        }
    }
}