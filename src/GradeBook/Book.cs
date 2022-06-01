namespace GradeBook
{
    class Book
    {
        public Book(string name) {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade) {
            grades.Add(grade);
        }
        public void ShowStatistics() {
            var averageGrade = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(var grade in this.grades) {
                averageGrade += grade;
                highGrade = Math.Max(highGrade, grade);
                lowGrade = Math.Min(lowGrade, grade);
            }
            averageGrade /= this.grades.Count;
            Console.WriteLine($"The highest grade is {highGrade}");
            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The average grade is {averageGrade:N1}");
        }
        private List<double> grades;
        private string name;
    }
}