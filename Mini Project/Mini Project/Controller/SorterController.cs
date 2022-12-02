using Mini_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Controller
{
    public class SorterController
    {
        public int[] ArrayToSort { get; set; }
        public ISorter Sorter { get; set; }

        public SorterController(ISorter sorter, int[] arrayToSort) {
            Sorter = sorter;
            ArrayToSort = arrayToSort;
        }

        public int[] GenerateRandomArray(int length) {
            var arr = new int[length];
            var rand = new Random();
            for (int i = 0; i < length; i++) {
                arr[i] = rand.Next(0, 1000);
            }
            return arr;
        }
    }
}
