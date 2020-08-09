using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace JExtensions.UnitTest.TaskTests
{
    public class WaitForNTests
    {
        System.Threading.Tasks.Task[] tasks = new System.Threading.Tasks.Task[5];

        public WaitForNTests()
        {
            for (int ctr = 0; ctr <= 4; ctr++)
            {
                int factor = ctr;
                tasks[ctr] = System.Threading.Tasks.Task.Run(() => Thread.Sleep(factor * 250 + 50));
            }
        }

        [Theory]
        [MemberData(nameof(WaitForFirstN_ValidScenarioTestData))]
        public void WaitForFirstN_ValidScenario(int numberOfTasks,int[] expectedResults)
        {
            var completedTaskList = tasks.WaitForFirstN(3);
            Assert.Equal(new int[] { 0, 1, 2 }, completedTaskList);
        }

        public static IEnumerable<object[]> WaitForFirstN_ValidScenarioTestData => new[]
        {
            new object[] {3,new[]{0,1,2}}
        };


        [Theory]
        [MemberData(nameof(WaitForFirstN_NumberOfTasksHigherThanTasksTestData)]
        public void WaitForFirstN_OutOfRangeCount_ThrowException(int numberOfTasks)
        {
            Assert.Throws<ArgumentNullException>(() => tasks.WaitForFirstN(numberOfTasks));
        }

        public static IEnumerable<object[]> WaitForFirstN_NumberOfTasksHigherThanTasksTestData => new[]
        {
            new object[]{10}
        };
    }
}
