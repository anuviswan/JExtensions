using System;

namespace JExtensions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Applies the specified Action on the instance of <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">Any Type</typeparam>
        /// <param name="source">Any instance of T</param>
        /// <param name="action">Action to be applied on instance of <paramref name="source"/></param>
        /// <returns>Instance of <paramref name="source"/> with Action specified by <paramref name="action"/> applied</returns>
        public static T Apply<T>(this T source,Action<T> action)
        {
            action(source);
            return source;
        }

        /// <summary>
        /// Applies the specified Action on the instance of <paramref name="source"/>
        /// </summary>
        /// <typeparam name="T">Any Type</typeparam>
        /// <param name="source">Any instance of T</param>
        /// <param name="actions">Action(s) to be applied on instance of <paramref name="source"/></param>
        /// <returns>Instance of <paramref name="source"/> with Actions specified by <paramref name="actions"/> applied</returns>
        public static T Apply<T>(this T source,params Action<T>[] actions)
        {
            foreach (var action in actions)
            {
                source.Apply(action);
            }
            return source;
        }
    }
}
