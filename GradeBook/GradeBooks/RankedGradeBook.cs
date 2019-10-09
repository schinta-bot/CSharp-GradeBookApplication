using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading atleast required 5 students");
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

    }
}



//Ranked-grading grades students not based on their individual performance, but rather their performance compared 
// to their peers.This means the 20% of the students with the highest grade of a class get an A, the next highest 20% get a B, etc.
// There are many ways to calculate this. I'd recommend figuring out how many students it takes to drop a letter grade (20% of the total number of students) X, 
//put all the average grades in order, then figure out where the input grade would fit in the series of grades. 
//Every X students with higher grades than the input grade knocks the letter grade down until you reach F.

//using a for loop and count how many different grades were higher/lower than the current grade we have input and 
//figure out where you have fall in the top 20% based on the input

    //how to compare performance to their peers

    //if i score the higest score out of group of 5 i get an A