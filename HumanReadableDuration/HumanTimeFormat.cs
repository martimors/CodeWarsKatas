using System;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections.Generic;

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
            var secondFactors = cumulativeProduct(factors);
            var units = new List<KeyValuePair<string, int>>() {
                new KeyValuePair<string, int>("year", 0),
                new KeyValuePair<string, int>("day", 0),
                new KeyValuePair<string, int>("hour", 0),
                new KeyValuePair<string, int>("minute", 0),
                new KeyValuePair<string, int>("second", 0),
            };
            int remainder; int result;


            for (int i = factors.Length - 1; i >= 0; i--)
            {
                // Divide and see how many are left
                result = seconds / secondFactors[i];
                remainder = seconds % secondFactors[i];
                units[i].Value = result;
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

    }
}