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

        public void DisplayArray() {
            foreach (var item in ArrayToSort) {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public void DisplayArraySorted() {
            var sortedArr = Sorter.Sort(ArrayToSort);
            foreach (var item in sortedArr) {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
