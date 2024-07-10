using FigureLib.Common;
using FigureLib.Operations.Interfaces;

namespace FigureLib.Operations.Figures;

/// <summary>
///     Triangle model
/// </summary>
public class Triangle : IFigureOperations
{
    /// <summary>
    ///     Side A
    /// </summary>
    private double A { get; }

    /// <summary>
    ///     Side B
    /// </summary>
    private double B { get; }

    /// <summary>
    ///     Side C
    /// </summary>
    private double C { get; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Triangle" /> class.
    /// </summary>
    public Triangle(double a, double b, double c)
    {
        ValidateSide(a, b, c);
        ValidateImpossibleSides(a, b, c);

        A = a;
        B = b;
        C = c;
    }

    ///<inheritdoc/>
    public double GetArea()
    {
        var checkingRectangularData = CheckSquareForRectangular();

        if (checkingRectangularData.IsRectangular)
            return checkingRectangularData.SideA * checkingRectangularData.SideB / 2;

        var half = (A + B + C) / 2;
        return Math.Sqrt(
            half
            * (half - A)
            * (half - B)
            * (half - C)
        );
    }

    /// <summary>
    ///     Checking square for rectangular
    /// </summary>
    /// <returns>Is rectangular(true/false), side "A", side "B"</returns>
    private (bool IsRectangular, double SideA, double SideB) CheckSquareForRectangular()
    {
        var powA = Math.Pow(A, 2);
        var powB = Math.Pow(B, 2);
        var powC = Math.Pow(C, 2);

        if (powC.Equals(powA + powB))
            return (true, A, B);

        if (powB.Equals(powA + powC))
            return (true, A, C);

        if (powA.Equals(powC + powB))
            return (true, C, B);

        return (false, default, default);
    }

    /// <summary>
    ///     Validate square side
    /// </summary>
    /// <param name="sides">Sides of square</param>
    /// <exception cref="ArgumentException">ArgumentException</exception>
    private void ValidateSide(params double[] sides)
    {
        if (sides.Any(s => s <= 0)) 
            throw new ArgumentException(CommonResources.sides_triangle_cannot_be_less_than_or_equal_zero);
    }

    /// <summary>
    ///     Validate impossible sides
    /// </summary>
    /// <param name="a">Sides а</param>
    /// <param name="b">Sides b</param>
    /// <param name="c">Sides с</param>
    /// <exception cref="ArgumentException">ArgumentException</exception>
    private void ValidateImpossibleSides(double a, double b, double c)
    {
        var maxSide = Math.Max(a, Math.Max(b, c));
        var perimeter = a + b + c;

        if (perimeter - maxSide <= maxSide)
            throw new ArgumentException(CommonResources.largest_triangle_side_shall_be_less_sum_of_two_sides);
    }

}