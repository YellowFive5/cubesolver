namespace Core;

public interface IFiguresGenerator
{
    List<Figure> GenerateFiguresSet();
    Figure GenerateFigureById(int id);
}