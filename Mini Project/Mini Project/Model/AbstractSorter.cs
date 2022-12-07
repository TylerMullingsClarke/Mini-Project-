using System.Diagnostics;

namespace Mini_Project.Model
{
    public abstract class AbsSorter
    {
        public abstract string SortName { get; }

        public abstract int[] Sort(int[] nums);

        public virtual double TimeIt(int[] nums) {
            int[] copy = new int[nums.Length];
            nums.CopyTo(copy, 0);
            var sw = new Stopwatch();
            sw.Start();
            Sort(copy);
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }
    }
}