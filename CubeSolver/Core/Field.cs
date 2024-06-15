#region Usings

using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Core;

public class Field
{
    private Matrix<double>[] Map { get; set; } =
    [
        Matrix<double>.Build.Dense(4, 4, 0),
        Matrix<double>.Build.Dense(4, 4, 0),
        Matrix<double>.Build.Dense(4, 4, 0),
        Matrix<double>.Build.Dense(4, 4, 0),
    ];


    public void Fit(Figure figure)
    {
        var matrix1 = Matrix<double>.Build.Dense(4, 4, 3);
        var matrix2 = Matrix<double>.Build.Dense(4, 4, 2);

        matrix1 += matrix2;

        Console.WriteLine(matrix1.ToString());
    }
}