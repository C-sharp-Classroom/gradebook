using Xunit;
namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
        // arrange
        var book = new Book("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);
        // act
        var result = book.GetStatistics();
        // assert
        Assert.Equal(85.6, result.Average, 1);
        Assert.Equal(90.5, result.High, 1);
        Assert.Equal(77.3, result.Low, 1);
    }

    [Fact]
    public void BookGradeShowBeInRange() {
        // arrange
        var book = new Book("");
        var ex = Assert.Throws<Exception>(
            () => {
                // act
                book.AddGrade(105);
            }
        );
        // assert
        Assert.Equal("Invalid Value" ,ex.Message);
    }
}