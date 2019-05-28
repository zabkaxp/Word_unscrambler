using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_unscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;
            do {
                Console.WriteLine("F for file, M for manual");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper()) {
                    case "F":
                        Console.WriteLine("enter file name with srambled words");
                        ExecuteScrambledWordsInFile();
                        break;
                    case "M":
                        Console.WriteLine("enter scrambled wrds");
                        ExecuteScrambledWordsManuallyEntered();
                        break;
                    default:
                        Console.WriteLine("not recognized");
                        break;
                }

                var shouldContinue = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue?");
                    shouldContinue = Console.ReadLine() ?? string.Empty;
                }

                while (!shouldContinue.Equals("Y", StringComparison.OrdinalIgnoreCase) && !shouldContinue.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueWordUnscramble = shouldContinue.Equals("Y", StringComparison.OrdinalIgnoreCase);
            } while (continueWordUnscramble);
        }

        private static void ExecuteScrambledWordsManuallyEntered()
        {

        }

        private static void ExecuteScrambledWordsInFile()
        {
        
        }
    }
}
