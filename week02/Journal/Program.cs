using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        bool running = true;
        while (running)
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": // Write new entry
                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToString("MM/dd/yyyy");
                    newEntry._promptText = promptGenerator.GetRandomPrompt();
                    
                    Console.WriteLine($"Prompt: {newEntry._promptText}");
                    Console.Write("Your response: ");
                    newEntry._entryText = Console.ReadLine();
                    
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully!\n");
                    break;
                    
                case "2": // Display journal
                    Console.WriteLine("\nJournal Entries:");
                    journal.DisplayAll();
                    break;
                    
                case "3": // Save to file
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved successfully!\n");
                    break;
                    
                case "4": // Load from file
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded successfully!\n");
                    break;
                    
                case "5": // Exit
                    running = false;
                    break;
                    
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}