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
        static void Main()
        {
            //just a speaker 
            //var speaker = new SpeechSynthesizer();
            //speaker.Speak("Welcome to grade book program!");

            //get the grade Book!
            var gradeBook = new GradeBook();
            gradeBook.NameChanged += OnNameChanged;
            gradeBook.Name = "new GradeBook";

            Console.WriteLine("enter number of grades, if done type \"Done\"");
            bool enterAtLeastOneNumber = false;
            do
            {
                string inputValue = Console.ReadLine();
                if (inputValue == "Done" && enterAtLeastOneNumber)
                {
                    break;
                }
                try
                {
                    var grade = float.Parse(inputValue);
                    gradeBook.addGrade(grade);
                    enterAtLeastOneNumber = true;
                }
                catch (FormatException)
                {   if(inputValue == "Done")
                    {
                        Console.WriteLine("Enter atleast one number");
                    }
                    else
                    {
                        Console.WriteLine($"input:\"{inputValue}\" is not a number");
                    } 
                }
            } while (true);
            GradeStats stats = gradeBook.computeGrade();
            Console.WriteLine("Average: "+stats.averageValue);
            Console.WriteLine("Highest: "+stats.highestGrade);
            Console.WriteLine("Lowest: " + stats.lowestGrade+"\n\n\nPress any key to exit");
            Console.ReadLine();
        }

        static void OnNameChanged(object sender, GradeBookNameChangeDelegateEventArgs args)
        {
            Console.WriteLine($"grade book name changed from {args.ExistingName} to {args.NewName}");
        }
    }
}
