
using System.Diagnostics;
using System.Text;

namespace Gaten.Net.Data.Diagnostics
{
    public class PerformanceChecker
    {
        /// <summary>
        /// Set of methods to be performed
        /// Methods should have no input and no output
        /// </summary>
        private readonly List<Action> actions;

        /// <summary>
        /// Number of times to perform each method
        /// </summary>
        public int CountOfPerform { get; set; }

        /// <summary>
        /// Just constructor
        /// </summary>
        public PerformanceChecker()
        {
            actions = new List<Action>();
            CountOfPerform = 1;
        }

        /// <summary>
        /// Compare method a and method b
        /// </summary>
        /// <param name="a">Method A</param>
        /// <param name="b">Method B</param>
        /// <param name="countOfPerform">Number of times to perform each method, default value is 1</param>
        public PerformanceChecker(Action a, Action b, int countOfPerform = 1)
        {
            actions = new List<Action>
            {
                a,
                b
            };

            CountOfPerform = countOfPerform;
        }

        /// <summary>
        /// Add additional method
        /// </summary>
        /// <param name="action">Method</param>
        public void AddAction(Action action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// Perform the method and return the time taken in seconds
        /// </summary>
        /// <returns></returns>
        public List<double> Perform()
        {
            var elapsedTimes = new List<double>();

            var stopwatch = new Stopwatch();
            foreach (Action action in actions)
            {
                stopwatch.Restart();
                for (int i = 0; i < CountOfPerform; i++)
                {
                    action();
                }
                stopwatch.Stop();

                elapsedTimes.Add((double)stopwatch.ElapsedTicks / 10_000_000);
            }

            return elapsedTimes;
        }

        /// <summary>
        /// Perform the method and return result by string
        /// </summary>
        /// <returns></returns>
        public string PerformResult()
        {
            var elapsedTimes = Perform();

            var builder = new StringBuilder();
            builder.AppendLine("================================");
            for (int i = 0; i < actions.Count; i++)
            {
                builder.Append(actions[i].Method.Name);
                builder.Append(" : ");
                builder.Append(elapsedTimes[i]);
                builder.AppendLine("sec");
            }
            builder.AppendLine("================================");

            return builder.ToString();
        }
    }
}
