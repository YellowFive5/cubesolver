﻿#region Usings

using Core;

#endregion


for (var i = 0; i < 20; i++)
{
    var solver = new Solver();
    Task.Factory.StartNew(() => solver.Solve(SolveStrategy.StuckFromStart));
}

Console.ReadKey();
Console.WriteLine("Exit");