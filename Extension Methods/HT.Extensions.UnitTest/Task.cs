using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
namespace JExtensions.UnitTest
{
    [TestClass]
    public class Task
    {
        System.Threading.Tasks.Task[] tasks = new System.Threading.Tasks.Task[5];

        [TestInitialize]
        public void Init()
        {
            for (int ctr = 0; ctr <= 4; ctr++)
            {
                int factor = ctr;
                tasks[ctr] = System.Threading.Tasks.Task.Run(() => Thread.Sleep(factor * 250 + 50));
            }
        }

        [TestMethod]
        public void WaitForFirstN_ValidResult_EqualsExpected()
        {
            var completedTaskList = tasks.WaitForFirstN(3);
            CollectionAssert.AreEqual(new int[] { 0, 1, 2 }, completedTaskList);
        }

        [TestMethod]
        public void WaitForFirstN_InValidResult_NotEqualsExpected()
        {
            var completedTaskList = tasks.WaitForFirstN(3);
            CollectionAssert.AreNotEqual(new int[] { 2, 4, 5 }, completedTaskList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WaitForFirstN_OutOfRangeCount_ThrowException()
        {
            var completedTaskList = tasks.WaitForFirstN(10);
        }
    }
}
