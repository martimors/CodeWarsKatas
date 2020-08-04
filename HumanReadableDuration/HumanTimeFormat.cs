using System;
using System.Linq;
using System.Text;


namespace HumanReadableDuration
{
    public class HumanTimeFormat
    {
        public static string formatDuration(int seconds)
        {
            if (seconds == 0) return "now";
            // 1 second / second
            // 60 seconds / minute
            // 60 * 60 seconds / hour
            // 60 * 60 * 24 seconds / day
            // 60 * 60 * 24 * 365 seconds / year
            var factors = new int[] { 1, 60, 60, 24, 365 };
            var output = new int[factors.Length];

            int remainder; int result;

            var secondFactors = cumulativeProduct(factors);

            for (int i = secondFactors.Length - 1; i >= 0; i--)
            {
                // Divide and see how many are left
                result = seconds / secondFactors[i];
                remainder = seconds % secondFactors[i];
                Console.WriteLine($"{seconds}∕{secondFactors[i]} = {result}");
                Console.WriteLine($"{seconds} % {secondFactors[i]} = {remainder}a");
                output[i] = result;
                seconds -= (seconds - remainder);
            }

            return arrayToHumanReadable(output);

        }

        private static int[] cumulativeProduct(int[] arrayIn)
        {
            var arrayOut = new int[arrayIn.Length];
            int product = 1;
            for (int i = 0; i < arrayIn.Length; i++)
            {
                product *= arrayIn[i];
                arrayOut[i] = product;
            }
            return arrayOut;
        }

        private static string arrayToHumanReadable(int[] arrayIn)
        {
            var units = new string[] { "year", "day", "hour", "minute", "second" };
            var stringOut = new StringBuilder();
            arrayIn = arrayIn.Reverse().ToArray();
            string tempUnit;


            for (int i = 0; i < arrayIn.Length; i++)
            {
                if (arrayIn[i] == 0) continue;

                tempUnit = arrayIn[i] > 1 ? units[i] + "s" : units[i];

                if (i < arrayIn.Length - 2)
                {
                    stringOut.Append((string)($"{arrayIn[i]}" + $" {tempUnit}, "));
                }
                else if (i < arrayIn.Length - 1)
                {
                    stringOut.Append((string)($"{arrayIn[i]}" + $" {tempUnit} "));
                }
                else
                {
                    stringOut.Append((string)($"and {arrayIn[i]}" + $" {tempUnit}"));
                }
            }
            return stringOut.ToString();
        }
    }
}