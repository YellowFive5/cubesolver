#region Usings

using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Core;

public class Field
{
    public Matrix<double>[] FittingMap { get; } = EmptyMapX4();
    private Matrix<double>[] FullMap { get; } = EmptyMapX8();

    public List<Figure> Fitted { get; } = new();

    public bool TryFit(Figure figure, int y, int x, int z)
    {
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            // out of full map bounds
            var figureFittedLayer8X8 = EmptyLayerX8();
            var zFullMapIndex = z + 2;
            var xFullMapIndex = x + 2;
            if (zFullMapIndex is < 0 or > 5 || xFullMapIndex is < 0 or > 5)
            {
                return false;
            }

            // out of fitting map bounds
            var fullMapLayerIndex = figureLayer.i + y + 2;
            figureFittedLayer8X8.SetSubMatrix(zFullMapIndex, xFullMapIndex, figureLayer.value);
            var figureFittedLayer4X4 = MatrixCut8To4(figureFittedLayer8X8);
            if (figureFittedLayer4X4.ColumnSums().Sum() < figureLayer.value.ColumnSums().Sum() // out of x or z bounds cutted with matrix cut
                ||
                (figureLayer.value.ColumnSums().Sum() > 0 && fullMapLayerIndex is < 2 or > 5)) // out of y bounds
            {
                return false;
            }

            // figures intersects check
            figureFittedLayer8X8 += FullMap[fullMapLayerIndex];
            figureFittedLayer4X4 = MatrixCut8To4(figureFittedLayer8X8);

            if (figureFittedLayer4X4.Exists(v => v > 1))
            {
                return false;
            }
        }

        // Empty holes check
        var tempMap = EmptyMapX4();
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            // todo realization needed
        }

        // all checks ok - fit da guy
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            var figureFittedLayer8X8 = EmptyLayerX8();
            figureFittedLayer8X8.SetSubMatrix(z + 2, x + 2, figureLayer.value);
            FullMap[figureLayer.i + y + 2] += figureFittedLayer8X8.Clone();
            var figureFittedLayer4X4 = MatrixCut8To4(figureFittedLayer8X8);
            if (figureLayer.value.ColumnSums().Sum() > 0) // empty side out of bounds ok
            {
                FittingMap[figureLayer.i + y] += figureFittedLayer4X4.Clone();
            }
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

    private static Matrix<double> EmptyLayerX4()
    {
        return Matrix<double>.Build.Dense(4, 4, 0);
    }

    private static Matrix<double> EmptyLayerX8()
    {
        return Matrix<double>.Build.Dense(8, 8, 0);
    }

    private static Matrix<double>[] EmptyMapX4()
    {
        return [EmptyLayerX4(), EmptyLayerX4(), EmptyLayerX4(), EmptyLayerX4()];
    }

    private static Matrix<double>[] EmptyMapX8()
    {
        return [EmptyLayerX8(), EmptyLayerX8(), EmptyLayerX8(), EmptyLayerX8(), EmptyLayerX8(), EmptyLayerX8(), EmptyLayerX8(), EmptyLayerX8()];
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