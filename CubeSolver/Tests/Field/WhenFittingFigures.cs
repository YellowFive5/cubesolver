#region Usings

using FluentAssertions;

#endregion

namespace Tests.Field;

public class WhenFittingFigures : FieldTestBase
{
    protected Core.Field Field { get; set; }

    public override void Setup()
    {
        base.Setup();
        Field = new Core.Field();
    }

    [TestCase(0, 0, 0)]
    [TestCase(0, 0, 1)]
    [TestCase(0, 1, 0)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 0, 0)]
    [TestCase(1, 0, 1)]
    [TestCase(1, 1, 0)]
    [TestCase(1, 1, 1)]
    public void FigureFittedCorrectly(int y, int x, int z)
    {
        var figure = FiguresGenerator.GenerateFigureById(2);

        var result = Field.TryFit(figure, y, x, z);

        result.Should().BeTrue();
        Field.Fitted.Should().Contain(figure);

        switch (y)
        {
            case 0:
                switch (x)
                {
                    case 0:
                        switch (z)
                        {
                            case 0:
                                Field.FittingMap.Should().Equal(Matrix(new double[,] { { 1, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
                                break;
                            case 1:
                                Field.FittingMap.Should().Equal(Matrix(new double[,] { { 0, 0, 0, 0 }, { 1, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
                                break;
                        }

                        break;
                    case 1:
                        switch (z)
                        {
                            case 0:
                                Field.FittingMap.Should().Equal(Matrix(new double[,] { { 0, 1, 1, 1 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
                                break;
                            case 1:
                                Field.FittingMap.Should().Equal(Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 1, 1, 1 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
                                break;
                        }

                        break;
                }

                break;
            case 1:
                switch (x)
                {
                    case 0:
                        switch (z)
                        {
                            case 0:
                                Field.FittingMap.Should().Equal(Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 1, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
                                break;
                            case 1:
                                Field.FittingMap.Should().Equal(Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 1, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
                                break;
                        }

                        break;
                    case 1:
                        switch (z)
                        {
                            case 0:
                                Field.FittingMap.Should().Equal(Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 1, 1, 1 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
                                break;
                            case 1:
                                Field.FittingMap.Should().Equal(Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 1, 1, 1 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                                                Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
                                break;
                        }

                        break;
                }

                break;
        }
    }

    [TestCase(3, 9, true)]
    [TestCase(7, 1, false)]
    public void SecondFigureFitWhenIntersects(int figureId1,
                                              int figureId2,
                                              bool expected)
    {
        var figure1 = FiguresGenerator.GenerateFigureById(figureId1);
        var figure2 = FiguresGenerator.GenerateFigureById(figureId2);

        Field.TryFit(figure1, 0, 0, 0).Should().BeTrue();
        Field.Fitted.Should().Contain(figure1);
        var secondFigureFitted = Field.TryFit(figure2, 1, 0, 0);

        if (expected)
        {
            secondFigureFitted.Should().BeTrue();
            Field.Fitted.Should().Contain(figure2);
            Field.FittingMap.Should().Equal(Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                            Matrix(new double[,] { { 0, 1, 0, 0 }, { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 } }),
                                            Matrix(new double[,] { { 1, 0, 0, 0 }, { 1, 1, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 0 } }),
                                            Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
        }
        else
        {
            secondFigureFitted.Should().BeFalse();
            Field.Fitted.Should().NotContain(figure2);
            Field.FittingMap.Should().Equal(Matrix(new double[,] { { 1, 1, 1, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                            Matrix(new double[,] { { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                            Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }),
                                            Matrix(new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } }));
        }
    }

    [Ignore("temp")]
    [Test]
    public void FigureNotFittedWhenEmptyHoleRemained()
    {
        var figure1 = FiguresGenerator.GenerateFigureById(9);
        var figure2 = FiguresGenerator.GenerateFigureById(4);
        Field.TryFit(figure1, -1, 0, 1);

        var secondFigureFitted = Field.TryFit(figure2, 1, 0, 1);

        secondFigureFitted.Should().BeFalse();
        Field.Fitted.Should().NotContain(figure2);
    }

    [TestCase(0, 0, 0, true)]
    [TestCase(-1, 0, 0, false)]
    [TestCase(1, 0, 0, true)]
    [TestCase(2, 0, 0, true)]
    [TestCase(3, 0, 0, false)]
    [TestCase(0, -1, 0, false)]
    [TestCase(0, 1, 0, true)]
    [TestCase(0, 2, 0, true)]
    [TestCase(0, 3, 0, false)]
    [TestCase(0, 0, -1, false)]
    [TestCase(0, 0, 1, true)]
    [TestCase(0, 0, 2, true)]
    [TestCase(0, 0, 3, false)]
    public void FigureNotFitsWhenOutOfBounds(int y, int x, int z, bool expected)
    {
        var figure1 = FiguresGenerator.GenerateFigureById(4);

        Field.TryFit(figure1, y, x, z).Should().Be(expected);

        var contains = Field.Fitted.Contains(figure1);
        contains.Should().Be(expected);
    }
}