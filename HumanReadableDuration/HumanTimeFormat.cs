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
            var units = new string[] { "second", "minute", "hour", "day", "year" };
            var calculatedUnits = new List<KeyValuePair<string, int>>();
            int remainder; int result;


            for (int i = factors.Length - 1; i >= 0; i--)
            {
                // Divide and see how many are left
                result = seconds / secondFactors[i];
                remainder = seconds % secondFactors[i];
                if (result > 0)
                {
                    calculatedUnits.Add(new KeyValuePair<string, int>(units[i], result));
                }
                seconds -= (seconds - remainder);
            }

            return toHumanReadable(calculatedUnits);
        }

        private static string toHumanReadable(List<KeyValuePair<string, int>> unitValues)
        {
            var sb = new StringBuilder();
            if (unitValues.Count == 1) return toFormattedString(unitValues[0]);

            for (int i = 0; i < unitValues.Count; i++)
            {
                if (i < unitValues.Count - 1)
                {
                    sb.Append(toFormattedString(unitValues[i]));
                }
                else
                {
                    sb.Append("and " + toFormattedString(unitValues[i]));
                }
                if (i < unitValues.Count - 2) sb.Append(", "); else sb.Append(" ");
            }
            return sb.ToString().Trim();
        }

        private static string toFormattedString(KeyValuePair<string, int> unitValue)
        {
            string unit = unitValue.Value > 1 ? unitValue.Key + "s" : unitValue.Key;
            return $"{unitValue.Value} {unit}";
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