using Mini_Project.Controller;
using Mini_Project.Model;

namespace Mini_Project.Utilities
{
    public static class SorterTimer
    {
        public static void TimeAllSorts(int[] arr) {
            var sorters = GetAllSorters();
            Console.WriteLine();  // Add a space before
            foreach (var sorter in sorters) {
                var time = sorter.TimeIt(arr);
                Console.WriteLine($"{sorter.SortName} took {time}ms");
            }
        }

        private static List<AbsSorter> GetAllSorters() {
            var sorterList = new List<AbsSorter>();
            int cur = 0;
            while (true) {
                try {
                    var sorter = SorterController.SelectSorter(cur);
                    if (sorter is null)
                        break;
                    sorterList.Add(sorter);
                    cur++;
                }
                catch (ArgumentException) {
                    break;
                }
            }
            return sorterList;
        }
    }
}