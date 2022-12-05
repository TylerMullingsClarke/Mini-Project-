using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Model
{
    public class DefaultSorter : ISorter
    {
        public string SortName { get; } = "Default/Quick Sort";

        public int[] Sort(int[] nums) {
            Array.Sort(nums);
            return nums;
        }
    }
}
