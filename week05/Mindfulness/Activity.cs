public abstract class Activity
{
    protected string _name; 
    protected string _description; 
    protected int _duration; 
    
    protected Activity() { }
    
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity."); 
        Console.WriteLine();
        Console.WriteLine(_description); 
        Console.WriteLine();

        bool validInput = false;
        while (!validInput)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine(
            $"You have completed another {_duration} seconds of the {_name} Activity."
        );
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>
        {
            "|",
            "/",
            "-",
            "\\"
        };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
        Console.Write(" ");
        Console.Write("\b");
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            string backspaces = new string('\b', i.ToString().Length);
            string spaces = new string(' ', i.ToString().Length);
            Console.Write($"{backspaces}{spaces}{backspaces}");
        }
        Console.Write(" ");
        Console.Write("\b");
    }
    

    
    public abstract void Run();
}
