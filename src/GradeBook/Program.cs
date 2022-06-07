// See https://aka.ms/new-console-template for more information
namespace GradeBook
{
  class Program {
    static void Main(string[] args) {
      var book = new Book("Gson's grade book");
      while(true) {
        Console.WriteLine("Enter Grade or 'q' to quit:");
        var input = Console.ReadLine();
        if (input == "q") {
          break;
        }
        try {
          var inputGrade = double.Parse(input);
          book.AddGrade(inputGrade);
        } catch (ArgumentException ex) {
          Console.WriteLine(ex.Message);
        } catch (FormatException ex) {
          Console.WriteLine(ex.Message);
        } finally {
          Console.WriteLine("**");
        }
      } 
      var stats = book.GetStatistics();
      Console.WriteLine($"The highest grade is {stats.High}");
      Console.WriteLine($"The lowest grade is {stats.Low}");
      Console.WriteLine($"The average grade is {stats.Average:N1}");
      Console.WriteLine($"The letter grade is {stats.Letter}");
    }
  }
}