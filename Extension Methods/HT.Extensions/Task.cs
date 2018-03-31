using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT.Extensions
{
    public static class Task
    {
        /// <summary>
        /// Wait for First 'N' Tasks to be completed
        /// </summary>
        /// <param name="tasks">Array of Tasks</param>
        /// <param name="numberOfTasks">Number of tasks to wait for completion</param>
        /// <returns>Indices of tasks completed from original array </returns>
        public static int[] WaitForFirstN(this System.Threading.Tasks.Task[] tasks,int numberOfTasks)
        {
            
            if (numberOfTasks > tasks.Length) throw new ArgumentOutOfRangeException();

            var _taskDictionary = Enumerable.Range(0, tasks.Length).ToDictionary(x => tasks[x]);
            List<int> completedTaskIndices = new List<int>();

            while (completedTaskIndices.Count < numberOfTasks)
            {
                var index = System.Threading.Tasks.Task.WaitAny(tasks);
                completedTaskIndices.Add(_taskDictionary[tasks[index]]);
                tasks = tasks.Where(x => x.Id != tasks[index].Id).ToArray();
            }
            return completedTaskIndices.ToArray<int>();
        }
    }
}
