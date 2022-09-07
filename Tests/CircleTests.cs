namespace Tests;

public class CircleTests
{
    /// <summary>
    /// Проверка на отрицатательные значения радиуса при создании круга
    /// </summary>
    [Fact]
    public void CreateCircle_FailOnWrong()
    {
        //Arrange
        var radius = -1;

        //Act
        //Assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    /// <summary>
    /// Проверка на правильность расчета рассчета площади круга
    /// </summary>
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