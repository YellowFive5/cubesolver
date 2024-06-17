#region Usings

using Core;
using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Tests;

public class TestBase
{
    protected IFiguresGenerator FiguresGenerator { get; set; }

    [SetUp]
    public virtual void Setup()
    {
        FiguresGenerator = new Core.FiguresGenerator();
    }

    protected Matrix<double> Matrix(double[,] arr)
    {
        return Matrix<double>.Build.DenseOfArray(arr);
    }
}