// 代码生成时间: 2025-10-02 02:39:25
 * This class follows C# best practices for maintainability and extensibility.
 */

using System;

namespace MathUtilityNamespace
{
    /// <summary>
    /// A class containing various mathematical operation methods.
    /// </summary>
    public static class MathUtility
    {
        /// <summary>
        /// Adds two numbers and returns the result.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The sum of a and b.</returns>
        public static double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts two numbers and returns the result.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The difference of a and b.</returns>
        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers and returns the result.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The product of a and b.</returns>
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides two numbers and returns the result.
        /// </summary>
        /// <param name="a">The numerator.</param>
        /// <param name="b">The denominator.</param>
        /// <returns>The quotient of a divided by b.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the denominator is zero.</exception>
        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }

        /// <summary>
        /// Calculates the square root of a number.
        /// </summary>
        /// <param name="a">The number to find the square root of.</param>
        /// <returns>The square root of a.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the number is negative.</exception>
        public static double SquareRoot(double a)
        {
            if (a < 0)
                throw new ArgumentOutOfRangeException(nameof(a), "Cannot calculate the square root of a negative number.");
            return Math.Sqrt(a);
        }

        // Additional mathematical operations can be added here following the same pattern.
    }
}
