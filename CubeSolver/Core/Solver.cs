#region Usings

using MathNet.Numerics.LinearAlgebra;

#endregion

namespace Core;

public class Solver
{
    private Field Field { get; }
    private FiguresGenerator FiguresGenerator { get; }

    private Queue<Figure> FiguresSet { get; }

    private Stack<Figure> FiguresFitHistory { get; } = new();
    private Stack<Matrix<double>[]> FullMapHistory { get; } = new();
    private Stack<Matrix<double>[]> FittingMapHistory { get; } = new();

    public Solver()
    {
        Field = new Field();
        FiguresGenerator = new FiguresGenerator();
        FiguresSet = new Queue<Figure>(FiguresGenerator.GenerateFiguresSet());
    }

    public void Solve()
    {
        var figureIteration = 0;
        while (FiguresSet.Any())
        {
            figureIteration++;
            var nextFigure = FiguresSet.Dequeue();
            Console.WriteLine($"Iteration: {figureIteration} " +
                              $"Figure number:{13 - FiguresSet.Count} " +
                              $"Figure:{nextFigure.Id}");

            bool fitted = false;
            for (int y = -2; y <= 3 && !fitted; y++)
            {
                for (int x = -2; x <= 3 && !fitted; x++)
                {
                    for (int z = -2; z <= 3 && !fitted; z++)
                    {
                        foreach (Axis axis in Enum.GetValues(typeof(Axis)))
                        {
                            foreach (Angle angle in Enum.GetValues(typeof(Angle)))
                            {
                                if (fitted)
                                {
                                    break;
                                }

                                nextFigure.Rotate(axis, angle);
                                fitted = Field.TryFit(nextFigure, y, x, z);
                                if (fitted) // try fit rotated
                                {
                                    FiguresFitHistory.Push(nextFigure);
                                    FullMapHistory.Push(Field.FullMap.ToArray());
                                    FittingMapHistory.Push(Field.FittingMap.ToArray());
                                    break;
                                }

                                nextFigure.Rotate(axis,
                                                  (int)angle < 4
                                                      ? (Angle)((int)angle + 3)
                                                      : (Angle)((int)angle - 3)); // reverse rotate
                            }
                        }
                    }
                }
            }

            if (!fitted)
            {
                FiguresSet.Enqueue(nextFigure);
                FiguresSet.Enqueue(FiguresFitHistory.Pop());
                Field.FittingMap = FittingMapHistory.Pop();
                Field.FullMap = FullMapHistory.Pop();
                Field.Fitted.RemoveAt(Field.Fitted.Count - 1);
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