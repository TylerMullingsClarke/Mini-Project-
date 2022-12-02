using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Model
{
    public class MergeSorter : ISorter
    {
        public int[] Sort(int[] nums) {
            //Basecase: An array of length 1 is sorted
            if (nums.Length == 1) { return nums; }
            int splitIndex = (nums.Length / 2)-1;
            //Splits array and sorts them
            int[] arrLeft = Sort(nums[0..splitIndex]);
            int[] arrRight = Sort(nums[(splitIndex+1)..nums.Length]); 
            //Merges the sorted array
            int[] rtnArr = new int[arrLeft.Length + arrRight.Length];
            int i = 0; int j = 0;
            for (int k = 0; k < rtnArr.Length; k++)
            {
                if (
                    j >= arrRight.Length //adds from arrLeft immediately if j is out of bounds
                    || (
                        i < arrLeft.Length //adds from arrRight immediately if i is out of bounds
                        && arrLeft[i] < arrRight[j] //then compares arr1 and arrRight if they are both in bounds
                    )
                )
                {
                    rtnArr[k] = arrLeft[i++];
                }
                else
                {
                    rtnArr[k] = arrRight[j++];
                }
            }
            return rtnArr;
        }
    }
}
