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
        Figure figure = null;
        switch (id)
        {
            case 1:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.Blue,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 0, 1, 1 }, { 1, 1, 0 }, { 0, 0, 0 } },
                                                 { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 2:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.Blue,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 0 } },
                                                 { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 3:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.Blue,
                             Dimension = 1,
                             Cubes = 5,
                             MaxHigh = 1,
                             MaxWidth = 3,
                             MaxDepth = 3,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 4:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.Blue,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 0, 1, 1 }, { 1, 1, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 5:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.White,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 6:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.White,
                             Dimension = 2,
                             Cubes = 4,
                             MaxHigh = 2,
                             MaxWidth = 2,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 1, 1, 0 }, { 1, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 1, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 7:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.White,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 1, 1, 1 }, { 0, 1, 0 }, { 0, 0, 0 } },
                                                 { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 8:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.White,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 1, 1, 1 }, { 0, 0, 1 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 1 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 9:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.White,
                             Dimension = 1,
                             Cubes = 5,
                             MaxHigh = 1,
                             MaxWidth = 3,
                             MaxDepth = 3,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 10:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.Yellow,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 0, 1, 0 }, { 1, 1, 0 }, { 0, 0, 0 } },
                                                 { { 0, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 11:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.Yellow,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 12:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.Yellow,
                             Dimension = 2,
                             Cubes = 5,
                             MaxHigh = 2,
                             MaxWidth = 3,
                             MaxDepth = 2,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 0, 0 } },
                                                 { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            case 13:
                figure = new Figure
                         {
                             Id = id,
                             Color = Color.Yellow,
                             Dimension = 1,
                             Cubes = 5,
                             MaxHigh = 1,
                             MaxWidth = 3,
                             MaxDepth = 3,
                             InitialMap3x3 = new[,,]
                                             {
                                                 { { 0, 0, 1 }, { 1, 1, 1 }, { 0, 1, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                                 { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } },
                                             }
                         };
                break;
            default:
                throw new Exception();
        }

        figure.ActualMap3x3 = figure.InitialMap3x3;
        return figure;
    }
}