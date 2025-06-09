using System.Collections.Generic;
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();            
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);    
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }    
        return items;
    }
    public override void Run()
    {
        DisplayStartingMessage();            
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();    
        List<string> items = GetListFromUser();    
        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");    
        DisplayEndingMessage();
    }
}