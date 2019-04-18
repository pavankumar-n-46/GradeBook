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
        private string _name;

        public event GradeBookNameChangeDelegate NameChanged;

        public GradeBook()
        {
            gradeList = new List<float>();
            _name = "Empty";
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (_name != value)
                    {
                        GradeBookNameChangeDelegateEventArgs args = new GradeBookNameChangeDelegateEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;
                        NameChanged(this, args);
                    }
                    _name = value;
                }
            }
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
