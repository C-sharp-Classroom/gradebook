namespace GradeBook
{
    public class Book
    {
        public Book(string name) {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
            } else {
                throw new Exception("Invalid Value");
                // Console.WriteLine("Invalid Value");
            }
        }
        public Statistics GetStatistics() {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach(var grade in this.grades) {
                result.Average += grade;
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);
            }
            result.Average /= this.grades.Count;
            return result;
        }
        private List<double> grades;
        public string Name;
    }
}