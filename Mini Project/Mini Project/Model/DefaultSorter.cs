﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Model
{
    internal class DefaultSorter : ISorter
    {
        public int[] Sort(int[] nums) {
            Array.Sort(nums);
            return nums;
        }
    }
}
