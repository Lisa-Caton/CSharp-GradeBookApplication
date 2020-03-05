namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new System.InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            else
            {
                return 'F';
            }
        }
    }
}