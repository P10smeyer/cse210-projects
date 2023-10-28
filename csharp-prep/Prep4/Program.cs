using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        int number = -1;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        // Loop until the user enters 0 while adding each entered number into the numbers list.
        do{
        Console.Write("Enter Number: ");
        number = int.Parse(Console.ReadLine());
        numbers.Add(number);
        } while (number != 0);
        numbers.RemoveAt(numbers.Count - 1); // Removing the 0 from the list because it is used as the exit command.
        // Calculate and print the sum, average, largest number, smallest positive number, and a sorted list.
        int sum = numbers.Sum();
        double average = numbers.Average();
        int maxNumber = numbers.Max();
        numbers.Sort();
        List<int> positiveNumbers = new List<int>();
        foreach(int num in numbers)
        {
            if (num > 0)
            {
                positiveNumbers.Add(num);
            }
        }
        int smallestPositiveNumber = positiveNumbers.Min();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}