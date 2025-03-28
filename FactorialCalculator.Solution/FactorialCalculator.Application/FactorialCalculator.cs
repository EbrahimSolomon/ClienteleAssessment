using System;
using System.Numerics;

public class FactorialCalculator
{
    private static readonly object _consoleLock = new object();

    public static BigInteger ComputeFactorial(int number)
    {
        if (number < 0)
            throw new ArgumentException("Number must be non-negative.");

        BigInteger result = 1;
        for (int i = 2; i <= number; i++)
            result *= i;

        return result;
    }

    public static void ComputeAndPrint(int number)
    {
        BigInteger factorial = ComputeFactorial(number);
        lock (_consoleLock)
        {
            Console.WriteLine($"Factorial of {number} is {factorial}");
        }
    }
}
