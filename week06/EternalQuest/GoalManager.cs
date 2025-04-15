
public class GoalManager
{
    private List<Goal> _goals; 
    private int _score;     

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    private int CalculateLevel()
    {
        return (_score / 1000) + 1;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Current Level: {CalculateLevel()}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            string goalTypePrefix = "";
            if (_goals[i] is SimpleGoal) goalTypePrefix = "[Simple] ";
            else if (_goals[i] is EternalGoal) goalTypePrefix = "[Eternal] ";
            else if (_goals[i] is ChecklistGoal) goalTypePrefix = "[Checklist] ";

            Console.WriteLine($"{i + 1}. {goalTypePrefix}{_goals[i].GetDetailsString()}");
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
         if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record events for.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }


    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");

        int points;
        while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number for points.");
            Console.Write("What is the amount of points associated with this goal? ");
        }

        Goal newGoal = null;

        switch (typeChoice)
        {
            case "1": 
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2": 
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3": 
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target;
                 while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number for the target count.");
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                }

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus;
                 while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0) 
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number for the bonus.");
                     Console.Write("What is the bonus for accomplishing it that many times? ");
                }
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                return; 
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"Goal '{name}' created successfully!");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames(); 
         if (_goals.Count == 0)
        {
            return; 
        }

        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1]; 

            if (selectedGoal.IsComplete() && !(selectedGoal is EternalGoal))
            {
                 Console.WriteLine($"Goal '{selectedGoal.GetName()}' is already complete. No points awarded.");
                 return;
            }


            int pointsEarned = selectedGoal.RecordEvent();

            if (pointsEarned > 0) 
            {
                 _score += pointsEarned; 
                 Console.WriteLine($"\nYou now have {_score} points.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals and score saved successfully to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"Error: File '{filename}' not found. No goals loaded.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear(); 

            if (lines.Length > 0)
            {
                if (!int.TryParse(lines[0], out _score))
                {
                    Console.WriteLine("Error: Invalid score format in file. Score reset to 0.");
                    _score = 0;
                }


                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] parts = line.Split(':'); 

                    if (parts.Length != 2)
                    {
                         Console.WriteLine($"Warning: Invalid format on line {i+1}. Skipping.");
                         continue;
                    }

                    string goalType = parts[0];
                    string goalData = parts[1];
                    string[] dataParts = goalData.Split(','); 

                    Goal loadedGoal = null;

                    try 
                    {
                        switch (goalType)
                        {
                            case "SimpleGoal":
                                if (dataParts.Length == 4)
                                {
                                    string sName = dataParts[0];
                                    string sDesc = dataParts[1];
                                    int sPoints = int.Parse(dataParts[2]);
                                    bool sComplete = bool.Parse(dataParts[3]);
                                    loadedGoal = new SimpleGoal(sName, sDesc, sPoints, sComplete);
                                } else throw new FormatException("Incorrect number of parts for SimpleGoal");
                                break;

                            case "EternalGoal":
                                 if (dataParts.Length == 3)
                                {
                                    string eName = dataParts[0];
                                    string eDesc = dataParts[1];
                                    int ePoints = int.Parse(dataParts[2]);
                                    loadedGoal = new EternalGoal(eName, eDesc, ePoints);
                                } else throw new FormatException("Incorrect number of parts for EternalGoal");
                                break;

                            case "ChecklistGoal":
                                 if (dataParts.Length == 6)
                                {
                                    string cName = dataParts[0];
                                    string cDesc = dataParts[1];
                                    int cPoints = int.Parse(dataParts[2]);
                                    int cBonus = int.Parse(dataParts[3]);
                                    int cTarget = int.Parse(dataParts[4]);
                                    int cCompleted = int.Parse(dataParts[5]);
                                    loadedGoal = new ChecklistGoal(cName, cDesc, cPoints, cBonus, cTarget, cCompleted);
                                } else throw new FormatException("Incorrect number of parts for ChecklistGoal");
                                break;
                            default:
                                Console.WriteLine($"Warning: Unknown goal type '{goalType}' found in file. Skipping line {i+1}.");
                                break;
                        }
                    }
                    catch (Exception goalEx) 
                    {
                         Console.WriteLine($"Error parsing goal on line {i+1}: {goalEx.Message}. Skipping.");
                         loadedGoal = null; 
                    }


                    if (loadedGoal != null)
                    {
                        _goals.Add(loadedGoal);
                    }
                }
                 Console.WriteLine($"Goals and score loaded successfully from {filename}");
            }
            else
            {
                 Console.WriteLine($"File '{filename}' is empty. No goals loaded, score reset to 0.");
                 _score = 0; 
            }

        }
        catch (Exception ex) 
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
            _goals.Clear();
            _score = 0;
        }
    }
}
