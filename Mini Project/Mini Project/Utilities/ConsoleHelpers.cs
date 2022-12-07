using System.Text;

namespace Mini_Project.Utilities
{
    internal static class ConsoleHelpers
    {
        internal static void ClearPreviousConsoleLines(int amountFromBottom) {
            var sb = new StringBuilder();
            for (int i = 0; i < amountFromBottom; i++) {
                sb.AppendLine(new string(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, Console.CursorTop - (amountFromBottom));
            Console.Write(sb.ToString());
            if (Console.CursorTop > 0) {
                Console.SetCursorPosition(0, Console.CursorTop - amountFromBottom);
            }
        }

        internal static void WriteLineInColour(string text, ConsoleColor colour) {
            Console.ForegroundColor = colour;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}