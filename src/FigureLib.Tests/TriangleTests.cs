using FigureLib.Operations.Figures;

namespace FigureLib.Tests;

/// <summary>
///     FigureLib.Tests for triangle operations
/// </summary>
public class TriangleTests
{
    [Fact]
    public void CreateTriangle_FailOnWrong()
    {
        //Arrange
        const int a = 3;
        const int b = 5;
        const int c = -3;
        
        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        Assert.Throws<ArgumentException>(() => new Triangle(b, c, a));
        Assert.Throws<ArgumentException>(() => new Triangle(c, b, a));
    }

    [Fact]
    public void ImpossibleSideCreateTriangle_FailOnWrong()
    {
        //Arrange
        const int a = 5;
        const int b = 1;
        const int c = 3;

        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Fact]
    public void CalculateAreaTriangle_Success()
    {
        //Arrange
        const int a = 3;
        const int b = 6;
        const int c = 7;

        var expectedArea = 8.94427190999916;

        //Act
        var triangle = new Triangle(a, b, c);
        var area = triangle.GetArea();

        //Assert
        Assert.Equal(expectedArea, area);
    }

    [Fact]
    public void CalculateAreaOfRectangularTriangle_Success()
    {
        //Arrange
        const int a = 6;
        const int b = 8;
        const int c = 10;

        var expectedArea = 24;

        //Act
        var triangle = new Triangle(a, b, c);
        var area = triangle.GetArea();

        //Assert
        Assert.Equal(expectedArea, area);
    }
}

