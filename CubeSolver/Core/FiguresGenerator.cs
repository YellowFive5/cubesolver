namespace Core;

public class FiguresGenerator : IFiguresGenerator
{
    public List<Figure> GenerateFiguresSet()
    {
        var figures = new List<Figure>();
        for (var i = 1; i <= 13; i++)
        {
            figures.Add(GenerateFigureById(i));
        }

        return figures;
    }

    public Figure GenerateFigureById(int id)
    {
        return new Figure();
    }
}