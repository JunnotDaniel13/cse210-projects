using System;

class Program
{
    private static Dictionary<string, int> _activityLog =
        new Dictionary<string, int>();
    private const string LogFileName = "mindfulness_log.txt";

    static void Main(string[] args)
    {
        LoadLog();

        string userChoice = "";

        while (userChoice != "4") 
        {
            DisplayMenu();
            userChoice = Console.ReadLine();

            Activity currentActivity = null;
            string activityKey = "";

            switch (userChoice)
            {
                case "1":
                    currentActivity = new BreathingActivity();
                    activityKey = "Breathing";
                    break;
                case "2":
                    currentActivity = new ReflectingActivity();
                    activityKey = "Reflecting";
                    break;
                case "3":
                    currentActivity = new ListingActivity();
                    activityKey = "Listing";
                    break;
                case "4": 
                    DisplayLog();
                    SaveLog();
                    Console.WriteLine("\nCome back soon!\n");
                    break;
                default:
                    Console.WriteLine(
                        "\nInvalid choice. Please enter a number from 1 to 5."
                    );
                    Thread.Sleep(2000);
                    break;
            }

            if (currentActivity != null)
            {
                currentActivity.Run();
                LogActivityCompletion(activityKey);
            }
        }
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit"); 
        Console.Write("Select a choice from the menu: ");
    }

    static void LogActivityCompletion(string activityName)
    {
        if (_activityLog.ContainsKey(activityName))
        {
            _activityLog[activityName]++;
        }
        else
        {
            _activityLog[activityName] = 1;
        }
    }

    static void DisplayLog()
    {
        Console.WriteLine("\n--- Activity Log ---");
        if (_activityLog.Count == 0)
        {
            Console.WriteLine("No activities completed yet in the log.");
        }
        else
        {
            var sortedLog = _activityLog.OrderBy(kvp => kvp.Key);
            foreach (var kvp in sortedLog)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time(s)");
            }
        }
        Console.WriteLine("--------------------\n");
        Console.WriteLine("Press Enter to continue quitting...");
        Console.ReadLine();
    }

    static void SaveLog()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(LogFileName))
            {
                foreach (var kvp in _activityLog)
                {
                    writer.WriteLine($"{kvp.Key}:{kvp.Value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving log file: {ex.Message}");
        }
    }

    static void LoadLog()
    {
        _activityLog.Clear();
        if (!File.Exists(LogFileName))
        {
            Console.WriteLine("(Log file not found. Starting with a fresh log.)");
            Thread.Sleep(1500);
            return;
        }
        try
        {
            string[] lines = File.ReadAllLines(LogFileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                {
                    _activityLog[parts[0]] = count;
                }
                else
                {
                    Console.WriteLine($"Warning: Skipping invalid line in log file: {line}");
                }
            }
            Console.WriteLine("(Activity log loaded successfully.)");
            Thread.Sleep(1500);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading log file: {ex.Message}");
            _activityLog.Clear();
        }
    }
}