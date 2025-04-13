public class ListingActivity : Activity
{
    private static Random _randomGenerator = new Random();
    private int _count;
    private readonly List<string> _masterPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private List<string> _sessionPrompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description =
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _sessionPrompts = new List<string>(_masterPrompts);
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

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        _count = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        List<string> itemsListed = new List<string>();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemsListed.Add(item);
                _count++;
            }
        }
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }
}
