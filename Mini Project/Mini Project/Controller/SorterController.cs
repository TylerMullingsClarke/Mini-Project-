using Mini_Project.Model;
using Mini_Project.Utilities;
using System.Diagnostics;

namespace Mini_Project.Controller
{
    public class SorterController
    {
        private int[] _array;
        public AbsSorter Sorter { get; private set; }

        public SorterController(AbsSorter sorter, int arrayLength) {
            Sorter = sorter;
            _array = ArrayGenerator.NewRandom(arrayLength);
        }

        public void DisplayArray() {
            foreach (var item in _array) {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public void DisplayArraySorted() {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sortedArr = Sorter.Sort(_array);
            stopwatch.Stop();
            foreach (var item in sortedArr) {
                Console.Write($"{item} ");
            }
            string newLines = $"{Environment.NewLine}{Environment.NewLine}";
            Console.WriteLine($"{newLines}Time taken to sort: {stopwatch.Elapsed.TotalMilliseconds}ms");
        }

        public static AbsSorter SelectSorter(int input) {
            AbsSorter sorter = input switch {
                0 => new BubbleSorter(),
                1 => new MergeSorter(),
                2 => new SelectionSorter(),
                3 => new InsertSort(),
                4 => new DefaultSorter(),
                _ => throw new ArgumentException()
            };
            return sorter;
        }
    }
}