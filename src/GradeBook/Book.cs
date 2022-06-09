namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args); 
    public class Book
    {
        public Book(string name) {
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
        public void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public Statistics GetStatistics() {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            for (var index = 0 ;index < this.grades.Count; index++) {
                result.Average += grades[index];
                result.High = Math.Max(result.High, grades[index]);
                result.Low = Math.Min(result.Low, grades[index]);
            }
            result.Average /= this.grades.Count;
            switch(result.Average) {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }
        private List<double> grades;
        
        public event GradeAddedDelegate GradeAdded;
        public string Name {
            get; 
            set;
        }
        const string category = "Science";
    }
}