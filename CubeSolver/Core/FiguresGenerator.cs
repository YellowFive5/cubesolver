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
        switch (id)
        {
            case 1:
                return new Figure
                       {
                           Id = id,
                           Color = Color.Blue,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 0, 1, 1 }, { 1, 1, 0 } },
                                     { { 0, 1, 0 }, { 0, 0, 0 } }
                                 }
                       };
            case 2:
                return new Figure
                       {
                           Id = id,
                           Color = Color.Blue,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 1, 1, 1 }, { 0, 0, 1 } },
                                     { { 0, 0, 1 }, { 0, 0, 0 } }
                                 }
                       };
            case 3:
                return new Figure
                       {
                           Id = id,
                           Color = Color.Blue,
                           Dimension = 1,
                           Cubes = 5,
                           MaxHigh = 1,
                           MaxWidth = 3,
                           MaxDepth = 3,
                           Map = new int[1, 3, 3]
                                 {
                                     { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } }
                                 }
                       };
            case 4:
                return new Figure
                       {
                           Id = id,
                           Color = Color.Blue,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 0, 1, 1 }, { 1, 1, 0 } },
                                     { { 0, 0, 1 }, { 0, 0, 0 } }
                                 }
                       };
            case 5:
                return new Figure
                       {
                           Id = id,
                           Color = Color.White,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 1, 1, 1 }, { 1, 0, 0 } },
                                     { { 0, 0, 1 }, { 0, 0, 0 } }
                                 }
                       };
            case 6:
                return new Figure
                       {
                           Id = id,
                           Color = Color.White,
                           Dimension = 2,
                           Cubes = 4,
                           MaxHigh = 2,
                           MaxWidth = 2,
                           MaxDepth = 2,
                           Map = new int[2, 2, 2]
                                 {
                                     { { 1, 1 }, { 1, 0 } },
                                     { { 0, 0 }, { 1, 0 } }
                                 }
                       };
            case 7:
                return new Figure
                       {
                           Id = id,
                           Color = Color.White,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 1, 1, 1 }, { 0, 1, 0 } },
                                     { { 0, 1, 0 }, { 0, 0, 0 } }
                                 }
                       };
            case 8:
                return new Figure
                       {
                           Id = id,
                           Color = Color.White,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 1, 1, 1 }, { 0, 0, 1 } },
                                     { { 0, 0, 0 }, { 0, 0, 1 } }
                                 }
                       };
            case 9:
                return new Figure
                       {
                           Id = id,
                           Color = Color.White,
                           Dimension = 1,
                           Cubes = 5,
                           MaxHigh = 1,
                           MaxWidth = 3,
                           MaxDepth = 3,
                           Map = new int[1, 3, 3]
                                 {
                                     { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } }
                                 }
                       };
            case 10:
                return new Figure
                       {
                           Id = id,
                           Color = Color.Yellow,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 0, 1, 0 }, { 1, 1, 0 } },
                                     { { 0, 1, 1 }, { 0, 0, 0 } }
                                 }
                       };
            case 11:
                return new Figure
                       {
                           Id = id,
                           Color = Color.Yellow,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 1, 1, 1 }, { 1, 0, 0 } },
                                     { { 0, 1, 0 }, { 0, 0, 0 } }
                                 }
                       };
            case 12:
                return new Figure
                       {
                           Id = id,
                           Color = Color.Yellow,
                           Dimension = 2,
                           Cubes = 5,
                           MaxHigh = 2,
                           MaxWidth = 3,
                           MaxDepth = 2,
                           Map = new int[2, 2, 3]
                                 {
                                     { { 0, 1, 0 }, { 1, 1, 1 } },
                                     { { 0, 1, 0 }, { 0, 0, 0 } }
                                 }
                       };
            case 13:
                return new Figure
                       {
                           Id = id,
                           Color = Color.Yellow,
                           Dimension = 1,
                           Cubes = 5,
                           MaxHigh = 1,
                           MaxWidth = 3,
                           MaxDepth = 3,
                           Map = new int[1, 3, 3]
                                 {
                                     { { 0, 0, 1 }, { 1, 1, 1 }, { 0, 1, 0 } }
                                 }
                       };
            default:
                return new Figure();
        }
    }
}