﻿#region Usings

using Core;
using FluentAssertions;

#endregion

namespace Tests.FiguresGenerator;

public class WhenGeneratingFigures : FiguresGeneratorTestBase
{
    public override void Setup()
    {
        base.Setup();
    }

    [Test]
    public void NumberOfFiguresInSetIs13()
    {
        var figures = FiguresGenerator.GenerateFiguresSet();

        figures.Count.Should().Be(13);
    }

    [Test]
    public void NumberOfFiguresColorsIsCorrect()
    {
        var figures = FiguresGenerator.GenerateFiguresSet();

        figures.Count(f => f.Color is Color.Blue).Should().Be(4);
        figures.Count(f => f.Color is Color.White).Should().Be(5);
        figures.Count(f => f.Color is Color.Yellow).Should().Be(4);
    }

    [Test]
    public void NumberOfFiguresDimensionsIsCorrect()
    {
        var figures = FiguresGenerator.GenerateFiguresSet();

        figures.Count(f => f.Dimension == 1).Should().Be(3);
        figures.Count(f => f.Dimension == 2).Should().Be(10);
    }

    [Test]
    public void TotalNumberOfCubesInSetIs64()
    {
        var figures = FiguresGenerator.GenerateFiguresSet();

        figures.Sum(f => f.InitialMap3x3.Sum(m => m.ColumnSums().Sum()))
               .Should()
               .Be(64);
    }

    [TestCase(1, Color.Blue, 2, 5, 2, 3, 2)]
    [TestCase(2, Color.Blue, 2, 5, 2, 3, 2)]
    [TestCase(3, Color.Blue, 1, 5, 1, 3, 3)]
    [TestCase(4, Color.Blue, 2, 5, 2, 3, 2)]
    [TestCase(5, Color.White, 2, 5, 2, 3, 2)]
    [TestCase(6, Color.White, 2, 4, 2, 2, 2)]
    [TestCase(7, Color.White, 2, 5, 2, 3, 2)]
    [TestCase(8, Color.White, 2, 5, 2, 3, 2)]
    [TestCase(9, Color.White, 1, 5, 1, 3, 3)]
    [TestCase(10, Color.Yellow, 2, 5, 2, 3, 2)]
    [TestCase(11, Color.Yellow, 2, 5, 2, 3, 2)]
    [TestCase(12, Color.Yellow, 2, 5, 2, 3, 2)]
    [TestCase(13, Color.Yellow, 1, 5, 1, 3, 3)]
    public void FigureGeneratesCorrectlyById(int id,
                                             Color color,
                                             int dimension,
                                             int cubes,
                                             int maxHigh,
                                             int maxWidth,
                                             int maxDepth
    )
    {
        var figure = FiguresGenerator.GenerateFigureById(id);

        figure.Id.Should().Be(id);
        figure.Color.Should().Be(color);
        figure.Dimension.Should().Be(dimension);
        figure.Cubes.Should().Be(cubes);
        figure.MaxHigh.Should().Be(maxHigh);
        figure.MaxWidth.Should().Be(maxWidth);
        figure.MaxDepth.Should().Be(maxDepth);
        switch (id)
        {
            case 1:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 0, 1, 1 }, { 1, 1, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 2:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 3:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 4:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 0, 1, 1 }, { 1, 1, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 5:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 6:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 1, 1, 0 }, { 1, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 1, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 7:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 1, 1, 1 }, { 0, 1, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 8:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 1 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 9:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 10:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 0, 1, 0 }, { 1, 1, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 11:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 12:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            case 13:
                figure.InitialMap3x3.Should().Equal(Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 0, 1, 0 } }),
                                                    Matrix(new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));
                break;
            default:
                Assert.Fail();
                break;
        }

        figure.ActualMap3x3.Should().Equal(figure.InitialMap3x3);
    }

    [Test]
    public void ExceptionThrowsWhenFigureIdIsIncorrect()
    {
        Action act = () => { FiguresGenerator.GenerateFigureById(42); };

        act.Should().Throw<Exception>();
    }
}