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

    public List<Figure> Fitted { get; set; } = new List<Figure>();

    public bool TryFit(Figure figure, int y, int x, int z)
    {
        var emptyLayer4X4 = Matrix<double>.Build.Dense(4, 4, 0);

        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            emptyLayer4X4.SetSubMatrix(z, x, figureLayer.value);
            emptyLayer4X4 += Map[figureLayer.i + y];
            if (emptyLayer4X4.Exists(v => v > 1)) // figures intersects
            {
                return false;
            }

            emptyLayer4X4 = Matrix<double>.Build.Dense(4, 4, 0);
        }

        // ok fill
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            emptyLayer4X4.SetSubMatrix(z, x, figureLayer.value);
            Map[figureLayer.i + y] += emptyLayer4X4.Clone();
        }

        Fitted.Add(figure);
        return true;
    }

    public void PrintMap()
    {
        Console.WriteLine($"Figures fitted:{Fitted.Count}");
        foreach (var layer in Map)
        {
            Console.WriteLine(layer.ToString());
        }
    }
}