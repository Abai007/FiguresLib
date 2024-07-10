using FigureLib.Common;
using FigureLib.Operations.Interfaces;

namespace FigureLib.Operations.Figures;

/// <summary>
///     Circle model
/// </summary>
public class Circle : IFigureOperations
{
    /// <summary>
    ///     Radius of circle
    /// </summary>
    private double Radius { get; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Circle" /> class.
    /// </summary>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException(CommonResources.circle_radius_cannot_be_lower_than_zero);
        
        Radius = radius;
    }

    ///<inheritdoc/>
    public double GetArea() => Math.PI * Math.Pow(Radius, 2d);
}