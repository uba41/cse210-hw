using System;
using System.Collections.Generic;
using ScriptureHider;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding"),
            new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be and men are that they might have joy"),
        };

        Random rand = new Random();
        Scripture scripture = scriptureLibrary[rand.Next(scriptureLibrary.Count)];
        
        
        //Think of other challenges that people find when trying to memorize a scripture. Find a way to have your program help with these challenges.
        //Difficulty Mode (easy/medium/hard) and Fill-in-the-Blank Mode with Scoring
        Console.Write("Choose difficulty (easy, medium, hard): ");
        string difficulty = Console.ReadLine().Trim().ToLower();
        
        int hideCount = difficulty switch
        {
            "easy" => 1,
            "medium" => 3,
            "hard" => 5,
            _ => 3
        };

        int score = 0;


        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);
            Console.WriteLine();

            //User guesses for hidden words
            foreach (Word word in scripture.GetWords())
            {
                if (word.IsHidden())
                {
                    Console.Write($"Guess the word ({word.Display().Length} letters): ");
                    string guess = Console.ReadLine().Trim();

                    if (guess.Equals(word.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("✅ Correct!");
                        word.Reveal();
                        score++;
                    }

                    else
                    {
                    Console.WriteLine($"❌ Incorrect. The word was: {word.Text}");
                    }
                }
            }

            Console.WriteLine();
            if (scripture.isCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture);
                Console.WriteLine($"\n🎉 All words have been guessed or revealed!");
                Console.WriteLine($"🏅 Final Score: {score} correct guesses");
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;
            
            scripture.HideRandomWords();

            if (scripture.isCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture);
                Console.WriteLine("\nAll words are hidden. Goodbye!");
                break;
            }
        }
    }
}