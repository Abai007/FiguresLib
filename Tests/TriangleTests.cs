namespace Tests;

public class TriangleTests
{
    /// <summary>
    /// Проверка на отрицатательные значения сторон при создании треугольника
    /// </summary>
    [Fact]
    public void CreateTriangle_FailOnWrong()
    {
        //Arrange
        var a = 3;
        var b = 5;
        var c = -3;
        
        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
        Assert.Throws<ArgumentException>(() => new Triangle(b, c, a));
        Assert.Throws<ArgumentException>(() => new Triangle(c, b, a));
    }

    /// <summary>
    /// Проверка на сторон на условие "сумма любых двух сторон должна быть больше третьей"
    /// </summary>
    [Fact]
    public void ImpossibleSideCreateTriangle_FailOnWrong()
    {
        //Arrange
        var a = 5;
        var b = 1;
        var c = 3;

        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    /// <summary>
    /// Проверка на правильность расчета рассчета площади треугольника
    /// </summary>
    [Fact]
    public void CalculateAreaTriangle_Success()
    {
        //Arrange
        var a = 3;
        var b = 6;
        var c = 7;

        var expectedArea = 8.94427190999916;

        //Act
        var triangle = new Triangle(a, b, c);
        var area = triangle.GetArea();

        //Assert
        Assert.Equal(expectedArea, area);
    }

    /// <summary>
    /// Проверка на правильность расчета рассчета площади прямоугольного треугольника
    /// </summary>
    [Fact]
    public void CalculateAreaOfRectangularTriangle_Success()
    {
        //Arrange
        var a = 6;
        var b = 8;
        var c = 10;

        var expectedArea = 24;

        //Act
        var triangle = new Triangle(a, b, c);
        var area = triangle.GetArea();

        //Assert
        Assert.Equal(expectedArea, area);
    }
}

