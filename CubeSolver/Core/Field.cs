#region Usings

using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Core;

public class Field
{
    private Matrix<double>[] Map { get; } =
    [
        Matrix<double>.Build.Dense(4, 4, 0),
        Matrix<double>.Build.Dense(4, 4, 0),
        Matrix<double>.Build.Dense(4, 4, 0),
        Matrix<double>.Build.Dense(4, 4, 0),
    ];


    public void Fit(Figure figure)
    {
        var emptyLayer4X4 = Matrix<double>.Build.Dense(4, 4, 0);

        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            emptyLayer4X4.SetSubMatrix(0, 0, figureLayer.value);
            Map[figureLayer.i] = emptyLayer4X4.Clone();
            emptyLayer4X4 = Matrix<double>.Build.Dense(4, 4, 0);
        }
    }

    public void PrintMap()
    {
        foreach (var layer in Map)
        {
            Console.WriteLine(layer.ToString());
        }
    }
}