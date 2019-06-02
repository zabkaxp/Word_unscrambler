using System;
using System.Collections.Generic;
using System.Linq;
using Word_unscrambler.Data;
using Word_unscrambler.NewFolder1;

namespace Word_unscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFileName = "wordlist.txt";

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
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsInFile()
        {
            var fileName = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(fileName);
            DisplayMatchedUnscrambledWords(scrambledWords)

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            if (matchedWords.Any()){
                foreach (var matchedWord in matchedWords) {
                    Console.WriteLine("Match found for {0}: {1}", matchedWord.ScrambledWord, matchedWord.Word);
                        }
            }
            else {
                Console.WriteLine("No matches");
            }    
        }
    }
}
