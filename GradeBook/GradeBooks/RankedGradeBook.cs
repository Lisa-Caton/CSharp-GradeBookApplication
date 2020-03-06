using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }

        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }
            
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            //"Students.Count * 0.2" gives you 20% of the total amount of students
            //Math.Ceiling rounds this up to the nearest whole number (gives students a slight edge if u get decimal #, their grade will be rounded up.)
            //Finally, we're casting that to an integer bc later we will use it as an index (which only accepts integers).
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            //order by average
            //select only the average and not all grade
            //then made it into a list

            if (grades[threshold - 1] <= averageGrade)
            //how many students before we go down a letter grade, then minus 1, bc index start at zero
            //if the value of that is equal or less than the average grade - we know we have an 'A'.
                return 'A';
            else if (grades[(threshold  * 2) -1] <= averageGrade)
            //"threshold *2" - that way its twice what we need to drop a letter grade
            //then determine, if that value, is equal or less than the average grade parameter - we know we have an 'B'.
                return 'B';
            else if (grades[(threshold * 3)-1] <= averageGrade)
                return 'C';
            else if (grades[(threshold * 4) -1] <= averageGrade)
                return 'D';
            else
            {
                return 'F';
            }
        }
    }
}