#region Usings

using Core;

#endregion

var figuresSet = new FiguresGenerator().GenerateFiguresSet();
var field = new Field();

field.Fit(figuresSet.ElementAt(2));

// end
// Console.ReadKey();
Console.WriteLine("Exit");