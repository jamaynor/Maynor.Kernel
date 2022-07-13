using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maynor.Kernel.Tests
{
    [TestClass]
    public class GuardClauseTests
    {

        [TestMethod]
        public void StackTrace_Gets_The_CallerName()
        {
            object o = null;

            try
            {
                Guard.Against.Null(o);
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message == "Value cannot be null. (Parameter 'StackTrace_Gets_The_CallerName failed because the argument was null.')");
            }
        }

        [TestMethod]
        public void StackTrace_Not_Too_Slow()
        {
            object o = null;
            var sw = new Stopwatch();

            long stackMilliseconds = 0;
            long messageMilliseconds = 0;
        

            try
            {
                sw.Start();
                Guard.Against.Null(o);
            }
            catch (ArgumentNullException ex)
            {
                sw.Stop();
                stackMilliseconds = sw.ElapsedMilliseconds;

                Assert.IsTrue(stackMilliseconds < 150);                
            }

            try
            {
                sw.Restart();                
                Guard.Against.Null(o,"Its much faster with the message.");
            }
            catch (ArgumentNullException ex)
            {
                sw.Stop();
                messageMilliseconds = sw.ElapsedMilliseconds;

                Assert.IsTrue(messageMilliseconds < 50);
            }

        }
    }
}
