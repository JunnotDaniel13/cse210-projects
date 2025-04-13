public class ReflectingActivity : Activity
{
    private static Random _randomGenerator = new Random();
    private readonly List<string> _masterPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private readonly List<string> _masterQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<string> _sessionPrompts;
    private List<string> _sessionQuestions;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description =
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _sessionPrompts = new List<string>(_masterPrompts);
        _sessionQuestions = new List<string>(_masterQuestions);
    }

    public string GetRandomPrompt()
    {
        if (_sessionPrompts.Count == 0)
        {
            Console.WriteLine("(Replenishing prompts for this session...)");
            _sessionPrompts.AddRange(_masterPrompts);
        }
        int index = _randomGenerator.Next(_sessionPrompts.Count);
        string prompt = _sessionPrompts[index];
        _sessionPrompts.RemoveAt(index);
        return prompt;
    }

    public string GetRandomQuestion()
    {
        if (_sessionQuestions.Count == 0)
        {
            Console.WriteLine("(Replenishing questions for this session...)");
            _sessionQuestions.AddRange(_masterQuestions);
        }
        int index = _randomGenerator.Next(_sessionQuestions.Count);
        string question = _sessionQuestions[index];
        _sessionQuestions.RemoveAt(index);
        return question;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        Console.WriteLine(
            "Now ponder on each of the following questions as they relate to this experience."
        );
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(10);
            Console.WriteLine();
        }
    }

    public override void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }
}
