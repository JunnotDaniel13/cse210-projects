using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string playAgain = "no";

        do
        {
            int magicNumber = randomGenerator.Next(1, 100);
            Console.WriteLine($"{magicNumber}");

            int guess = -1;
            int attempt = 0;

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempt++;

                if (guess < magicNumber) 
                {
                    Console.WriteLine("Higher");
                } else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                } else {
                    Console.WriteLine($"You guessed it! It took you {attempt} attempts");
                }
            } while (guess != magicNumber);
            
            

            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();

        } while (playAgain == "yes");

    }
}