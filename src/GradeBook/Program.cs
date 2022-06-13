// See https://aka.ms/new-console-template for more information
namespace GradeBook
{
  class Program {
    static void Main(string[] args)
    {
      IBook book = new DiskBook("Gson's grade book");
      book.GradeAdded += OnGradeAdded;

      EnterGrades(book);
      var stats = book.GetStatistics();
      Console.WriteLine($"The gradebook Name is {book.Name}");
      Console.WriteLine($"The highest grade is {stats.High}");
      Console.WriteLine($"The lowest grade is {stats.Low}");
      Console.WriteLine($"The average grade is {stats.Average:N1}");
      Console.WriteLine($"The letter grade is {stats.Letter}");
    }

    private static void EnterGrades(IBook book)
    {
      while (true)
      {
        Console.WriteLine("Enter Grade or 'q' to quit:");
        var input = Console.ReadLine();
        if (input == "q")
        {
          break;
        }
        try
        {
          if (input != null) {
            var inputGrade = double.Parse(input);
            book.AddGrade(inputGrade);
          }
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          Console.WriteLine("**");
        }
      }
    }

    static void OnGradeAdded(object sender, EventArgs e) {
      Console.WriteLine("A grade is Added");
    }
  }
}