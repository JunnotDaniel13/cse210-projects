using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());
        int gradeLastDigit = grade % 10;

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        } else if (grade >= 80)
        {
            letter = "B";
        } else if (grade >= 70)
        {
            letter = "C";
        } else if (grade >= 60)
        {
            letter = "D";
        } else 
        {
            letter = "F";
        }

        if (gradeLastDigit >= 7) 
        {
            if (letter != "A" && letter != "F") 
            {
                letter = letter + "+";
            }
        } else if (gradeLastDigit < 3) 
        {
            if (letter != "F") 
            {
                letter = letter + "-";
            }
        }

        Console.WriteLine($"Your grade is {grade}, it is a {letter}");

        if (grade >= 70) {
            Console.WriteLine("Congradulation!! You passed");
        } else
        {
            Console.WriteLine("Give your best next time!");
        }
    }
}