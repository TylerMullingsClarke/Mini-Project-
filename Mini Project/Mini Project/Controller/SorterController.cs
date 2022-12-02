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
    }
}
