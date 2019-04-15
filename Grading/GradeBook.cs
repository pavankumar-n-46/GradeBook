using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grading
{
    public class GradeBook
    {
        private List<float> gradeList;
        public GradeBook()
        {
            gradeList = new List<float>();
        }

        public void addGrade(float grade)
        {
            gradeList.Add(grade);
        }

        public GradeStats computeGrade()
        {
            GradeStats stats = new GradeStats();
            float sum = 0;
            foreach(float grade in gradeList)
            {
                sum += grade;
                stats.highestGrade = Math.Max(grade, stats.highestGrade);
                stats.lowestGrade = Math.Min(grade, stats.lowestGrade);
            }
            stats.averageValue = sum / gradeList.Count;
            return stats;
        }
    }
}
