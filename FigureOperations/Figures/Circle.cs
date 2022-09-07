namespace FigureOperations.Figures;

/// <summary>
/// Класс круга
/// </summary>
public class Circle : IFigureOperations
{
    /// <summary>
    /// Радиус круга
    /// </summary>
    private double Radius { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="radius">радиус</param>
    /// <exception cref="ArgumentException">ArgumentException</exception>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException($"Радиус круга не может быть ниже числа 0");
        Radius = radius;
    }

    ///<inheritdoc/>
    public double GetArea() => Math.PI * Math.Pow(Radius, 2d);
}