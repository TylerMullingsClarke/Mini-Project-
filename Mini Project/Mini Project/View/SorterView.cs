using Mini_Project.Controller;
using Mini_Project.Model;
using Mini_Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.View
{
    public class SorterView
    {
        public static void Main(string[] args) {
            Console.Write("Input a length: ");
            var lengthInput = Console.ReadLine();
            var success = int.TryParse(lengthInput, out var length);

            int[] array;
            if (success) {
                array = ArrayGenerator.NewRandom(length);
            }
            else {
                throw new ArgumentException();
            }
            var choice = GetUserAlgorithmChoice();
            var sorter = SelectSorter(choice);
            var controller = new SorterController(sorter, array);

            Console.WriteLine("\n---\n");
            Console.WriteLine("Unsorted:");
            controller.DisplayArray();
            Console.WriteLine("\n---\n");
            Console.WriteLine("Sorted:");
            controller.DisplayArraySorted();
        }

        public static int GetUserAlgorithmChoice() {
            Console.WriteLine("Choose a sort algorithm:");
            Console.WriteLine("1) Bubble Sort");
            Console.WriteLine("2) Merge Sort");
            Console.WriteLine("3) Default/Quick Sort");
            var choice = Console.ReadLine();
            var success = int.TryParse(choice, out var num);
            if (success) {
                return num;
            }
            else {
                throw new ArgumentException();
            }
        }

        public static ISorter SelectSorter(int input) {
            ISorter sorter = input switch {
                1 => new BubbleSorter(),
                2 => new MergeSorter(),
                3 => new DefaultSorter(),
                _ => throw new ArgumentException()
            };
            return sorter;
        }
    }
}

