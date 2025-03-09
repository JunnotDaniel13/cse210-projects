using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string username = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);

        DisplayResult(username, squaredNumber);
    }

    static void DisplayWelcome() 
    {
        Console.WriteLine("Welcome to the Program!");
    }
   
    static string PromptUserName() 
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
   
    static int PromptUserNumber() 
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number) 
    {
        return number * number;
    }

    static void DisplayResult(string username, int squaredNumber)
    {
        Console.WriteLine($"{username}, the square of your number is {squaredNumber}");
    }
}