#region Usings

using Core;

#endregion

var generator = new FiguresGenerator();
// var figuresSet = generator.GenerateFiguresSet();

var field = new Field();

var figure1 = generator.GenerateFigureById(9);
field.TryFit(figure1, -1, 0, 0);
var figure2 = generator.GenerateFigureById(2);
figure2.Rotate(Axis.X, Angle._90ccvn);
field.TryFit(figure2, -1, 1, 0);

// field.PrintMap();

// end
// Console.ReadKey();
Console.WriteLine("Exit");