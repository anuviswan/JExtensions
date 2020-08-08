using System;
using System.Threading;
using Xunit;

namespace JExtensions.UnitTest
{
    public class Task
    {
        System.Threading.Tasks.Task[] tasks = new System.Threading.Tasks.Task[5];

        //[TestInitialize]
        public void Init()
        {
            for (int ctr = 0; ctr <= 4; ctr++)
            {
                int factor = ctr;
                tasks[ctr] = System.Threading.Tasks.Task.Run(() => Thread.Sleep(factor * 250 + 50));
            }
        }

        [Fact]
        public void WaitForFirstN_ValidResult_EqualsExpected()
        {
            var completedTaskList = tasks.WaitForFirstN(3);
            Assert.Equal(new int[] { 0, 1, 2 }, completedTaskList);
        }

        [Fact]
        public void WaitForFirstN_InValidResult_NotEqualsExpected()
        {
            var completedTaskList = tasks.WaitForFirstN(3);
            Assert.NotEqual(new int[] { 2, 4, 5 }, completedTaskList);
        }

        [Fact]
        public void WaitForFirstN_OutOfRangeCount_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(()=> tasks.WaitForFirstN(10));
        }
    }
}
