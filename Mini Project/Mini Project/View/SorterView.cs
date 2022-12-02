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
            if (!success) {
                throw new ArgumentException();
            }
            var userSelection = GetUserAlgorithmChoice();
            var sorter = SelectSorter(userSelection);
            var controller = new SorterController(sorter, length);
            DisplayResult(controller);
        }

        public static int GetUserAlgorithmChoice() {
            Console.CursorVisible = false;  // Hide the console cursor while the user uses arrow keys to select            
            var curUserSelection = 0;    // Start user on first available choice

            // Keep looping through until the user presses enter
            ConsoleKeyInfo? keyInfo = null;
            while (!keyInfo.HasValue || keyInfo.Value.Key != ConsoleKey.Enter) {
                Console.WriteLine(DisplayChoiceString(curUserSelection));
                keyInfo = Console.ReadKey(true);   // 'true' here means not to display the key pressed

                // curUserSelection stays between 0 and 2
                if (keyInfo.Value.Key == ConsoleKey.DownArrow) {
                    curUserSelection = (curUserSelection + 1) % 3;
                    ClearPreviousConsoleLines(6);
                }
                else if (keyInfo.Value.Key == ConsoleKey.UpArrow) {
                    curUserSelection = (curUserSelection - 1) >= 0 ? (curUserSelection - 1) % 3 : 2;
                    ClearPreviousConsoleLines(6);
                }
                else {
                    // For any other key presses that are not up and down (including enter when the choice is selected)                    
                    ClearPreviousConsoleLines(6);
                }
            }
            Console.CursorVisible = true;
            return curUserSelection;
        }

        public static ISorter SelectSorter(int input) {
            ISorter sorter = input switch {
                0 => new BubbleSorter(),
                1 => new MergeSorter(),
                2 => new DefaultSorter(),
                _ => throw new ArgumentException()
            };
            return sorter;
        }

        // currentSelection must be between 0 and 2 (inclusive) 
        private static string DisplayChoiceString(int currentSelection) {
            string[] stringArr = new string[] {
                "\nChoose a sort algorithm:\n",
                "Bubble Sort",
                "Merge Sort",
                "Default/Quick Sort"
             };
            var sb = new StringBuilder();
            for (int i = 0; i < stringArr.Length; i++) {
                if (i == currentSelection + 1) {
                    sb.Append(stringArr[i]);
                    sb.Append(" *\n");
                }
                else {
                    sb.AppendLine(stringArr[i]);
                }
            }
            return sb.ToString();
        }

        private static void ClearPreviousConsoleLines(int amountFromBottom) {
            var cursorTuple = Console.GetCursorPosition();
            var sb = new StringBuilder();
            for (int i = 0; i < amountFromBottom; i++) {
                sb.AppendLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, cursorTuple.Top - (amountFromBottom + 1));
            Console.Write(sb.ToString());
            if (Console.CursorTop > 0) {
                Console.SetCursorPosition(0, Console.CursorTop - amountFromBottom);
            }
        }

        private static void DisplayResult(SorterController controller) {
            Console.WriteLine($"\n---\n\n{controller.Sorter.SortName}");
            // Display unsorted array
            Console.WriteLine("\n---\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Unsorted:");
            Console.ResetColor();
            controller.DisplayArray();

            // Display sorted array and time
            Console.WriteLine("\n---\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sorted:");
            Console.ResetColor();
            controller.DisplayArraySorted();
        }
    }
}

