using Mini_Project.Controller;
using Mini_Project.Utilities;
using System.Text;

namespace Mini_Project.View
{
    public class SorterView
    {
        private static string _newline = Environment.NewLine;
        private const int NumAlgorithms = 5;
        private SorterController? _controller;

        public void MainLoop() {
            bool running = true;
            while (running) {
                int length = GetUserArrayLengthChoice();
                var timeAllSelection = GetUserTimeAllChoice();
                if (timeAllSelection) { 
                    SorterTimer.TimeAllSorts(ArrayGenerator.NewRandom(length));
                    running = ContinueChoice();
                    continue;
                }
                var userSelection = GetUserAlgorithmChoice();

                var sorter = SorterController.SelectSorter(userSelection);
                _controller = new SorterController(sorter, length);

                DisplayResult(_controller);
                running = ContinueChoice();
            }
        }

        private static bool GetUserTimeAllChoice() {
            while (true) { 
                Console.Write("Do you want to time all sorts? (y/n) ");
                var choice = Console.ReadLine();
                Console.Clear();
                if (choice is null) {
                    return false;
                }
                if (choice.ToUpper() is "Y"){
                    return true;
                }
                if (choice.ToUpper() is "N") {
                    return false;
                }
                Console.WriteLine("Please provide a valid input before you are smited by Lord Phil");
            }
        }

        //Determines whether the user wants to continue suing the program
        private static bool ContinueChoice() {
            while (true) {
                Console.WriteLine();
                Console.WriteLine("Would you like to sort an array again? (Y/N)");
                string choice = Console.ReadLine();
                Console.Clear();
                if (choice.ToUpper() == "Y") {
                    return true;
                }
                else if (choice.ToUpper() == "N") {
                    return false;
                }
                Console.WriteLine("Please provide a valid input before you are smited by Lord Phil");
            }
        }

        private static int GetUserArrayLengthChoice() {
            bool userEnteredInvalidInput = false;
            while (true) {
                var numLinesToClear = userEnteredInvalidInput ? 2 : 1;  // Need to clear 2 lines rather than 1 ('invalid input' line)
                Console.Write("Input a length (> 0): ");
                var lengthInput = Console.ReadLine();
                var success = int.TryParse(lengthInput, out var length);
                // Consider 0 an invalid input
                if (!success || length is <= 0) {
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
                    curUserSelection = (curUserSelection + 1) % NumAlgorithms;
                }
                else if (keyInfo.Value.Key == ConsoleKey.UpArrow) {
                    curUserSelection = (curUserSelection - 1) >= 0 ? (curUserSelection - 1) % NumAlgorithms : NumAlgorithms;
                }

                ConsoleHelpers.ClearPreviousConsoleLines(numLines + 1);  // 1 extra necessary due to user input (I think)
            }
            Console.CursorVisible = true;
            return curUserSelection;
        }

        // currentSelection must be between 0 and 4 (inclusive)
        private static string MakeChoicesString(int currentSelection, out int numLines) {
            const char PointerChar = '*';
            string[] stringArr = new string[] {
                $"Choose a sort algorithm:{_newline}",
                "Bubble Sort",
                "Merge Sort",
                "Selection Sort",
                "Insertion Sort",
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