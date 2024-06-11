#region Usings

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
}