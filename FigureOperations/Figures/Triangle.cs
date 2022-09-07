namespace FigureOperations.Figures;

/// <summary>
/// Класс треугольника
/// </summary>
public class Triangle : IFigureOperations
{
    /// <summary>
    /// Стророна A
    /// </summary>
    private double A { get; }

    /// <summary>
    /// Стророна B
    /// </summary>
    public double B { get; init; }

    /// <summary>
    /// Стророна C
    /// </summary>
    public double C { get; init; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="a">сторона "A"</param>
    /// <param name="b">сторона "B"</param>
    /// <param name="c">сторона "C"</param>
    /// <exception cref="ArgumentException">ArgumentException</exception>
    public Triangle(double a, double b, double c)
    {
        ValidateSide(a, b, c);
        ValidateImpossibleSide(a, b, c);

        A = a;
        B = b;
        C = c;
    }

    ///<inheritdoc/>
    public double GetArea()
    {
        (var isRectangular, double a, double b) = CheckSquareForRectangular();

        if (isRectangular)
            return (a * b) / 2;

        var half = (A + B + C) / 2;
        var square = Math.Sqrt(
            half
            * (half - A)
            * (half - B)
            * (half - C)
        );

        return square;
    }

    /// <summary>
    /// Проверка на прямоугольный треугольник
    /// </summary>
    /// <returns>прямоугольный(true/false),катет "A", катет "B"</returns>
    private (bool, double, double) CheckSquareForRectangular()
    {
        double powA = Math.Pow(A, 2);
        double powB = Math.Pow(B, 2);
        double powC = Math.Pow(C, 2);

        if (powC.Equals(powA + powB))
            return (true, A, B);

        if (powB.Equals(powA + powC))
            return (true, A, C);

        if (powA.Equals(powC + powB))
            return (true, C, B);

        return (false, default, default);
    }

    /// <summary>
    /// Валидация стороны треугольника
    /// </summary>
    /// <param name="sides">Стороны</param>
    /// <exception cref="ArgumentException">ArgumentException</exception>
    private void ValidateSide(params double[] sides)
    {
        if (sides.Any(s => s <= FigureConstants.MinValue)) 
            throw new ArgumentException($"Стороны треугольника не могут быть меньше '{FigureConstants.MinValue}'");
    }

    /// <summary>
    /// Валидация на условие 'Cумма любых двух сторон должна быть больше третьей'
    /// </summary>
    /// <param name="a">сторона а</param>
    /// <param name="b">сторона b</param>
    /// <param name="c">сторона с</param>
    /// <exception cref="ArgumentException">ArgumentException</exception>
    private void ValidateImpossibleSide(double a, double b, double c)
    {
        var maxSide = Math.Max(a, Math.Max(b, c));
        var perimeter = a + b + c;

        if ((perimeter - maxSide) <= maxSide)
            throw new ArgumentException("Наибольшая сторона треугольника должна быть меньше суммы двух сторон");
    }

}