#region Usings

using Core;

#endregion

var generator = new FiguresGenerator();
// var figuresSet = generator.GenerateFiguresSet();

var field = new Field();

field.Fit(generator.GenerateFigureById(1));

// end
// Console.ReadKey();
Console.WriteLine("Exit");