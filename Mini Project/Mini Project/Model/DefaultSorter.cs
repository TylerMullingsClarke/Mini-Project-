using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Model
{
    internal class DefaultSorter : ISorter
    {
        public string SortName { get; } = "Default Sort";

        public int[] Sort(int[] nums) {
            // This method apparently chooses different sorting algorithms
            // depending on the size of the array.
            Array.Sort(nums);
            return nums;
        }
    }
}
