using Mini_Project.Controller;
using Mini_Project.Model;
using Mini_Project.Utilities;
using System.Text;

namespace Mini_Project.View
{
    public class SorterView
    {
        private static string _newline = Environment.NewLine;

        public static void Main(string[] args) {
            int length = GetUserArrayLengthChoice();
            var userSelection = GetUserAlgorithmChoice();

            var sorter = SelectSorter(userSelection);
            var controller = new SorterController(sorter, length);

            DisplayResult(controller);
        }

        private static int GetUserArrayLengthChoice() {
            bool userEnteredInvalidInput = false;
            while (true) {
                var numLinesToClear = userEnteredInvalidInput ? 2 : 1;  // Need to clear 2 lines rather than 1 ('invalid input' line)
                Console.Write("Input a length: ");
                var lengthInput = Console.ReadLine();
                var success = int.TryParse(lengthInput, out var length);
                if (!success) {
                    ConsoleHelpers.ClearPreviousConsoleLines(numLinesToClear);
                    ConsoleHelpers.WriteLineInColour("Invalid input.", ConsoleColor.Red);
                    userEnteredInvalidInput = true;
                    continue;
                }
                ConsoleHelpers.ClearPreviousConsoleLines(numLinesToClear);
                return length;  // breaks out of loop on successful int input
            }
        }

        private static int GetUserAlgorithmChoice() {
            Console.CursorVisible = false;  // Hide the console cursor while the user uses arrow keys to select            
            var curUserSelection = 0;    // Start user on first available choice

            // Keep looping through until the user presses enter
            ConsoleKeyInfo? keyInfo = null;
            while (!keyInfo.HasValue || keyInfo.Value.Key != ConsoleKey.Enter) {
                Console.WriteLine(MakeChoicesString(curUserSelection, out int numLines));
                keyInfo = Console.ReadKey(true);   // 'true' here means not to display the key pressed

                // curUserSelection stays between 0 and 2
                if (keyInfo.Value.Key == ConsoleKey.DownArrow) {
                    curUserSelection = (curUserSelection + 1) % 3;
                }

                else if (keyInfo.Value.Key == ConsoleKey.UpArrow) {
                    curUserSelection = (curUserSelection - 1) >= 0 ? (curUserSelection - 1) % 3 : 2;
                }

                ConsoleHelpers.ClearPreviousConsoleLines(numLines + 1);  // 1 extra necessary due to user input (I think)
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
        private static string MakeChoicesString(int currentSelection, out int numLines) {
            const char PointerChar = '*';
            string[] stringArr = new string[] {
                $"Choose a sort algorithm:{_newline}",
                "Bubble Sort",
                "Merge Sort",
                "Default Sort"
             };
            numLines = stringArr.Length + 1;  // + 1 for the newline
            var sb = new StringBuilder();
            for (int i = 0; i < stringArr.Length; i++) {
                if (i == currentSelection + 1) {
                    sb.Append(stringArr[i]);
                    sb.Append($" {PointerChar}{_newline}");
                }
                else {
                    sb.AppendLine(stringArr[i]);
                }
            }
            return sb.ToString();
        }

        private static void DisplayResult(SorterController controller) {
            // Display sort name
            Console.WriteLine($"{_newline}---{_newline}{_newline}{controller.Sorter.SortName}");
            Console.WriteLine($"{_newline}---{_newline}");  // spacer

            // Display unsorted array
            ConsoleHelpers.WriteLineInColour("Unsorted:", ConsoleColor.Yellow);
            controller.DisplayArray();

            Console.WriteLine($"{_newline}---{_newline}");  // spacer

            // Display sorted array and time
            ConsoleHelpers.WriteLineInColour("Sorted:", ConsoleColor.Green);
            controller.DisplayArraySorted();
        }
    }
}






