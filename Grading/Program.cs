using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grading
{
    class Program
    {
        static void Main(string[] args)
        {
            var speaker = new SpeechSynthesizer();
            speaker.Speak("Welcome to grade book program!");
            var gradeBook = new GradeBook();
            Console.WriteLine("enter number of grades, if done type \"Done\"");
            do
            {
                string inputValue = Console.ReadLine();
                if (inputValue == "Done")
                {
                    break;
                }
                gradeBook.addGrade(float.Parse(inputValue));
            } while (true);
            GradeStats stats = gradeBook.computeGrade();
            Console.WriteLine("Average: "+stats.averageValue);
            Console.WriteLine("Highest: "+stats.highestGrade);
            Console.WriteLine("Lowest: " + stats.lowestGrade+"\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
