class Program
{
    static void Main(string[] args)
    {
        // Create a sample scripture
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, text);

        // Main program loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide 3 random words each time
            scripture.HideRandomWords(3);

            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }
    }
}