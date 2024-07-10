using FigureLib.Operations.Figures;

namespace FigureLib.Tests;

/// <summary>
///     FigureLib.Tests for circle operations
/// </summary>
public class CircleTests
{
    [Fact]
    public void CreateCircle_FailOnWrong()
    {
        //Arrange
        var radius = -1;

        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    [Fact]
    public void CalculateAreaCircle_Success()
    {
        //Arrange
        var radius = 3;
        var expectedArea = 28.274333882308138;

        //Act
        var circle = new Circle(radius);
        var area = circle.GetArea();

        //Assert
        Assert.Equal(expectedArea, area);
    }
}