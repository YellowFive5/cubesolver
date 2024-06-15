#region Usings

using MatrixDotNet;
using MatrixDotNet.Extensions;

#endregion

namespace Core;

public class Field
{
    private int[,,] Map { get; set; } =
        {
            { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
            { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
            { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
            { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } },
        };

    private List<Tuple<Figure, int[]>> Figures { get; set; } = [];

    public void Fit(Figure figure)
    {
        Matrix<int> matrix1 = new Matrix<int>(4, 4, 2);
        Matrix<int> matrix2 = new Matrix<int>(4, 4, 3);
        matrix1[0,0] *= 0;
        
        matrix1.Pretty();
        matrix2.Pretty();

        matrix1 += matrix2;

        matrix1.Pretty();
    }
}