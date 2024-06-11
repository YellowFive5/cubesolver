#region Usings

using Core;
using FluentAssertions;

#endregion

namespace Tests.FiguresGenerator;

public class WhenGeneratingFigures : FiguresGeneratorTestBase
{
    [Test]
    public void NumberOfFiguresInSetIs13()
    {
        var generator = new Core.FiguresGenerator();

        var figures = generator.GenerateFiguresSet();

        figures.Count.Should().Be(13);
    }

    [Test]
    public void NumberOfFiguresColorsIsCorrect()
    {
        var generator = new Core.FiguresGenerator();

        var figures = generator.GenerateFiguresSet();

        figures.Count(f => f.Color is Color.Blue).Should().Be(4);
        figures.Count(f => f.Color is Color.White).Should().Be(5);
        figures.Count(f => f.Color is Color.Yellow).Should().Be(4);
    }

    [Test]
    public void NumberOfFiguresDimensionsIsCorrect()
    {
        var generator = new Core.FiguresGenerator();

        var figures = generator.GenerateFiguresSet();

        figures.Count(f => f.Dimension == 1).Should().Be(3);
        figures.Count(f => f.Dimension == 2).Should().Be(10);
    }

    [Test]
    public void TotalNumberOfCubesInSetIs64()
    {
        var generator = new Core.FiguresGenerator();

        var figures = generator.GenerateFiguresSet();

        Assert.Fail(); // todo realization needed
    }
}