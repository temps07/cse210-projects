using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        LoadGoals();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Eternal Quest - Current Score: {_score}");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add New Goal");
            Console.WriteLine("3. Record Goal Progress");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": ViewGoals(); break;
                case "2": AddGoal(); break;
                case "3": RecordProgress(); break;
                case "4": SaveGoals(); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void ViewGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Add some!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()} - {_goals[i].GetProgress()}");
        }
    }

    private void AddGoal()
    {
        Console.WriteLine("\nAdd New Goal");
        Console.WriteLine("1. Simple Goal (one-time)");
        Console.WriteLine("2. Eternal Goal (repeating)");
        Console.WriteLine("3. Checklist Goal (multiple times)");
        Console.Write("Choose goal type: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Console.WriteLine("Goal added successfully!");
    }

    private void RecordProgress()
    {
        ViewGoals();
        if (_goals.Count == 0) return;

        Console.Write("Enter goal number to record: ");
        int goalNum = int.Parse(Console.ReadLine()) - 1;

        if (goalNum >= 0 && goalNum < _goals.Count)
        {
            _goals[goalNum].RecordProgress();
            _score += _goals[goalNum].GetPoints();
            Console.WriteLine("Progress recorded!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score); // Save score first
            foreach (Goal goal in _goals)
            {
                // Save each goal with its type and data
                if (goal is SimpleGoal simple)
                {
                    writer.WriteLine($"SimpleGoal|{simple.GetName()}|{simple.IsComplete()}");
                }
                else if (goal is EternalGoal eternal)
                {
                    writer.WriteLine($"EternalGoal|{eternal.GetName()}");
                }
                else if (goal is ChecklistGoal checklist)
                {
                    writer.WriteLine($"ChecklistGoal|{checklist.GetName()}|{checklist.IsComplete()}|{checklist.GetProgress()}");
                }
            }
        }
        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]); // First line is score
            
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];

                // Simplified loading - in a real app you'd save/load more details
                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(name, "", 100)); // Default values
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(name, "", 50)); // Default values
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(name, "", 10, 5, 100)); // Default values
                        break;
                }
            }
            Console.WriteLine("Goals loaded!");
        }
    }
} 