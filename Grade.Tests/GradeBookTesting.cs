using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grading;

namespace Grade.Tests
{
    [TestClass]
    public class GradeBookTesting
    {
        GradeBook book;
        GradeStats stats;
        public GradeBookTesting()
        {
            book = new GradeBook();
            book.addGrade(91);
            book.addGrade(89.5f);
            book.addGrade(75);
            stats = book.computeGrade();
        }
     
        [TestMethod]
        public void computeHigestGrade()
        {
            Assert.AreEqual(91, stats.highestGrade);
        }
        
        [TestMethod]
        public void computeLowestGrade()
        {
            Assert.AreEqual(75, stats.lowestGrade);
        }

        [TestMethod]
        public void computeAverageGrade()
        {
            Assert.AreEqual(85.16f, stats.averageValue, 0.01);
        }
    }
}
