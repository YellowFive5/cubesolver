#region Usings

using Core;

#endregion

var generator = new FiguresGenerator();
// var figuresSet = generator.GenerateFiguresSet();

var field = new Field();

field.TryFit(generator.GenerateFigureById(2), 0, 0, 0);
field.TryFit(generator.GenerateFigureById(3), 0, 0, 0);

field.PrintMap();

// end
// Console.ReadKey();
Console.WriteLine("Exit");