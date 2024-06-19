#region Usings

using MathNet.Numerics.LinearAlgebra;
using Console = Colorful.Console;

#endregion

namespace Core;

public class Solver
{
    private Field Field { get; }
    private FiguresGenerator FiguresGenerator { get; }

    private List<Figure> FiguresSet { get; }

    private Stack<Figure> FiguresFitHistory { get; } = new();
    private Stack<Matrix<double>[]> FittingMapHistory { get; } = new();
    private Stack<Matrix<double>[]> FullMapHistory { get; } = new();

    public Solver()
    {
        Field = new Field();
        FiguresGenerator = new FiguresGenerator();
        FiguresSet = new List<Figure>(FiguresGenerator.GenerateFiguresSet());
    }

    public void Solve()
    {
        var figureIteration = 0;
        var figureFitMapsEthalon = new List<int[]>();
        for (var y = -2; y <= 3; y++)
        {
            for (var x = -2; x <= 3; x++)
            {
                for (var z = -2; z <= 3; z++)
                {
                    foreach (Axis axis in Enum.GetValues(typeof(Axis)))
                    {
                        foreach (Angle angle in Enum.GetValues(typeof(Angle)))
                        {
                            figureFitMapsEthalon.Add([y, x, z, (int)axis, (int)angle]);
                        }
                    }
                }
            }
        }

        var figuresSetWorking = FiguresSet.ToList();
        while (figuresSetWorking.Any())
        {
            figureIteration++;
            var rndIndex = new Random().Next(0, figuresSetWorking.Count - 1);
            var nextFigure = figuresSetWorking.ElementAt(rndIndex);
            figuresSetWorking.RemoveAt(rndIndex);

            var figureNumber = 13 - figuresSetWorking.Count;

            if (figureIteration % 100000 == 0)
            {
                Console.WriteLine($"Iteration: {figureIteration}",
                                  System.Drawing.Color.Gray);
            }
            switch (figureNumber)
            {
                case 12:
                    Console.WriteLine($"Iteration: {figureIteration} " +
                                      $"Figures count:{figureNumber}",
                                      System.Drawing.Color.MediumVioletRed);
                    break;
                case 13:
                    Console.WriteLine($"Iteration: {figureIteration} " +
                                      $"Figures count:{figureNumber}",
                                      System.Drawing.Color.Yellow);
                    break;
            }

            var figureFitMaps = figureFitMapsEthalon.ToList();
            var fitted = false;
            while (!fitted && figureFitMaps.Any())
            {
                rndIndex = new Random().Next(0, figureFitMaps.Count - 1);
                var figureFitMap = figureFitMaps.ElementAt(rndIndex);
                figureFitMaps.RemoveAt(rndIndex);

                nextFigure.Rotate((Axis)figureFitMap[3], (Angle)figureFitMap[4]);
                fitted = Field.TryFit(nextFigure,
                                      figureFitMap[0],
                                      figureFitMap[1],
                                      figureFitMap[2]);
                nextFigure.Rotate((Axis)figureFitMap[3],
                                  figureFitMap[4] < 4
                                      ? (Angle)(figureFitMap[4] + 3)
                                      : (Angle)(figureFitMap[4] - 3)); // reverse rotate

                if (fitted)
                {
                    FiguresFitHistory.Push(nextFigure);
                    FittingMapHistory.Push(Field.FittingMap.ToArray());
                    FullMapHistory.Push(Field.FullMap.ToArray());
                }
            }

            if (!fitted) // not fitted after all rotates
            {
                figuresSetWorking = FiguresSet.ToList();

                FiguresFitHistory.Clear();
                FittingMapHistory.Clear();

                Field.FittingMap = Field.EmptyMapX4();
                Field.FullMap = Field.EmptyMapX8();
            }
        }

        PrintFinalResult();
    }

    public void PrintFinalResult()
    {
        while (FiguresFitHistory.Any() && FittingMapHistory.Any())
        {
            Console.WriteLine($"Figure: {FiguresFitHistory.Pop().Id}");
            foreach (var matrix in FittingMapHistory.Pop())
            {
                Console.WriteLine(matrix.ToString());
            }
        }
    }
}