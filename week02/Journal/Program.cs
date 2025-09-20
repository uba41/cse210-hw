using System;

class Program
{
    static string[] prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    static Random random = new Random();

    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            // EX = Think of other problems that keep people from writing in their journal and address one of those.
            // EX = At program start, check if the latest journal entry is today. If not, prompt a reminder.
            if (journal.HasEntries() && journal.LastEntryDate() != DateTime.Now.ToShortDateString())
            {
                Console.WriteLine("📝 You haven’t written in your journal today. Want to add an entry?");
            }
            
            Console.WriteLine("\nPlease select one of the following choice: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. load");
            Console.WriteLine("5. Exit");
            Console.WriteLine("6. Save journal to JSON");
            Console.WriteLine("7. Load journal from JSON");
            Console.WriteLine("8. Search entries by keyword");
            Console.WriteLine("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    SaveJournal(journal);
                    break;

                case "4":
                    LoadJournal(journal);
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                
                // EX = Think of other problems that keep people from writing in their journal and address one of those.
                // Ex= Let the user find past entries easily
                case "8":
                    Console.Write("Enter a keyword to search: ");
                    string keyword = Console.ReadLine().ToLower();

                    foreach (Entry entry in journal.SearchByKeyword(keyword))
                    {
                        Console.WriteLine(entry);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        int index = random.Next(prompts.Length);
        string prompt = prompts[index];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Console.Write("How are you feeling today (Happy, Sad, Stressed, Excited, etc)? ");
        string mood= Console.ReadLine();

        Entry newEntry = new Entry(prompt, response, date, mood);
        journal.AddEntry(newEntry);

        Console.WriteLine("Entry added.");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}