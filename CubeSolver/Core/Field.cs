#region Usings

using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Core;

public class Field
{
    public Matrix<double>[] Map { get; } = EmptyMap();

    public List<Figure> Fitted { get; set; } = new();

    public bool TryFit(Figure figure, int y, int x, int z)
    {
        
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            var emptyLayer4X4 = EmptyLayer();

            if (figureLayer.value.ColumnSums().Sum() == 0) // figure layer empty
            {
                continue;
            }
            
            // out of bounds check
            var layerIndex = figureLayer.i + y;
            if (layerIndex < 0 || layerIndex >= Map.Length)
            {
                return false;
            }
            
            // figures intersects check
            emptyLayer4X4.SetSubMatrix(z, x, figureLayer.value);
            emptyLayer4X4 += Map[layerIndex];
            if (emptyLayer4X4.Exists(v => v > 1))
            {
                return false;
            }
        }
        
        // Empty holes check
        // todo realization needed
        var tempMap = EmptyMap();
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            var emptyLayer4X4 = EmptyLayer();

            if (figureLayer.value.ColumnSums().Sum() == 0) // figure layer empty
            {
                continue;
            }

            emptyLayer4X4.SetSubMatrix(z, x, figureLayer.value);
            tempMap[figureLayer.i + y] += emptyLayer4X4.Clone();
        }


        // all checks ok - fit
        foreach (var figureLayer in figure.ActualMap3x3.Select((value, i) => new { i, value }))
        {
            var emptyLayer4X4 = EmptyLayer();

            if (figureLayer.value.ColumnSums().Sum() == 0) // figure layer empty
            {
                continue;
            }

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

    private static Matrix<double> EmptyLayer()
    {
        return Matrix<double>.Build.Dense(4, 4, 0);
    }

    private static Matrix<double>[] EmptyMap()
    {
        return [EmptyLayer(), EmptyLayer(), EmptyLayer(), EmptyLayer()];
    }
}