#region Usings

using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Core;

public class Field
{
    public Matrix<double>[] FittingMap { get; } = EmptyMap4X4X4();
    private Matrix<double>[] FullMap { get; } = EmptyMap8X8X8();

    public List<Figure> Fitted { get; } = new();

    public bool TryFit(Figure figure, int y, int x, int z)
    {
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            var figureFittedLayer8X8 = EmptyLayer8X8();
            figureFittedLayer8X8.SetSubMatrix(z + 2, x + 2, figureLayer.value);
            var figureFittedLayer4X4 = MatrixCut8To4(figureFittedLayer8X8);

            // out of bounds check
            if (figureFittedLayer4X4.ColumnSums().Sum() < figureLayer.value.ColumnSums().Sum())
            {
                return false;
            }

            // figures intersects check
            figureFittedLayer8X8 += FullMap[figureLayer.i + y + 2];
            figureFittedLayer4X4 = MatrixCut8To4(figureFittedLayer8X8);

            if (figureFittedLayer4X4.Exists(v => v > 1))
            {
                return false;
            }
        }

        // Empty holes check
        var tempMap = EmptyMap4X4X4();
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            // todo realization needed
        }

        // all checks ok - fit
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            var figureFittedLayer8X8 = EmptyLayer8X8();
            figureFittedLayer8X8.SetSubMatrix(z + 2, x + 2, figureLayer.value);
            FullMap[figureLayer.i + y + 2] += figureFittedLayer8X8.Clone();
            var figureFittedLayer4X4 = MatrixCut8To4(figureFittedLayer8X8);
            FittingMap[figureLayer.i + y] += figureFittedLayer4X4.Clone();
        }

        Fitted.Add(figure);
        return true;
    }

    public void PrintMap()
    {
        Console.WriteLine($"Figures fitted:{Fitted.Count}");
        foreach (var layer in FittingMap)
        {
            Console.WriteLine(layer.ToString());
        }
    }

    private static Matrix<double> EmptyLayer4X4()
    {
        return Matrix<double>.Build.Dense(4, 4, 0);
    }

    private static Matrix<double> EmptyLayer8X8()
    {
        return Matrix<double>.Build.Dense(8, 8, 0);
    }

    private static Matrix<double>[] EmptyMap4X4X4()
    {
        return [EmptyLayer4X4(), EmptyLayer4X4(), EmptyLayer4X4(), EmptyLayer4X4()];
    }

    private static Matrix<double>[] EmptyMap8X8X8()
    {
        return [EmptyLayer8X8(), EmptyLayer8X8(), EmptyLayer8X8(), EmptyLayer8X8(), EmptyLayer8X8(), EmptyLayer8X8(), EmptyLayer8X8(), EmptyLayer8X8()];
    }

    private static Matrix<double> MatrixCut8To4(Matrix<double> matrix)
    {
        Console.WriteLine(matrix);
        var copy = matrix.Clone()
                         .RemoveRow(6)
                         .RemoveRow(6)
                         .RemoveColumn(6)
                         .RemoveColumn(6)
                         .RemoveRow(0)
                         .RemoveRow(0)
                         .RemoveColumn(0)
                         .RemoveColumn(0);
        Console.WriteLine(copy);
        return copy;
    }
}