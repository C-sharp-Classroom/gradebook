namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NameObject {
        public NameObject(string name) {
            Name = name;
        }
        public string Name {
            get;
            set;
        }
    } 
    public interface IBook {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate ?GradeAdded;
    }
    public abstract class Book: NameObject, IBook {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        public abstract event GradeAddedDelegate ?GradeAdded;
    }

  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate? GradeAdded;

    public override void AddGrade(double grade)
    {
      // Create a File
      using (var writer = File.AppendText($"{Name}.txt")) {
        writer.WriteLine(grade);
        if (GradeAdded != null) {
            GradeAdded(this, new EventArgs());
        }
      }
    }

    public override Statistics GetStatistics()
    {
        var result = new Statistics();
        using(var reader = File.OpenText($"{Name}.txt")) {
            var inputGrade = reader.ReadLine();
            while(inputGrade != null) {
                double grade = double.Parse(inputGrade);
                result.Add(grade);
                inputGrade = reader.ReadLine();
            }
        }
        return result;
    }
  }
  public class InMemoryBook : Book
    {
        public InMemoryBook(string name): base(name) {
            grades = new List<double>();
            Name = name;
        }
        
        public void AddGrade(char letter) {
            switch(letter) {
                case 'A':
                        AddGrade(90);
                        break;
                case 'B':
                        AddGrade(80);
                        break;
                case 'C':
                        AddGrade(70);
                        break;
                default:
                        AddGrade(0);
                        break;            
            }
        }
        
        public override void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public override Statistics GetStatistics() {
            var result = new Statistics();
            for (var index = 0 ;index < grades.Count; index++) {
                result.Add(grades[index]);
            }
            return result;
        }
        private List<double> grades;
        
        public override event GradeAddedDelegate ?GradeAdded;
        // public string Name {
        //     get; 
        //     set;
        // }
        const string category = "Science";
    }
}