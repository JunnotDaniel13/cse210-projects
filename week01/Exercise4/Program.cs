using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;
        int sum = 0;
        double average = 0;
        int max = 0;
        int min = 0;

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine()); 
            if (number != 0) 
            {
                numbers.Add(number);
            }

            sum += number; 
            average = ((float)sum) / numbers.Count;

            if (number > max) 
            {
                max = number;
            } 

            if (number < min) 
            {
                min = number;
            } 

        } while (number != 0);     

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");
        

        numbers.Sort();
        Console.WriteLine("Sorted numbers:");
        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}