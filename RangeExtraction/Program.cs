using System;
using System.Collections.Generic;
using System.Linq;

namespace RangeExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RangeExtraction.Extract(new int[] { 1, 2, 4, 61, 62, 63, 100, 101, 102, 103 }));
        }
public class RangeExtraction
{
    public static string Extract(int[] args)
    {
        var isDash = new bool[args.Length];
        var o = new List<string>();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == LeftShift(args)[i] - 1 && args[i] == RightShift(args)[i] + 1)
            {
                isDash[i] = true;
            }
            else
            {
                if (i != 0)
                {
                    if (isDash[i - 1])
                    {
                        o.Add($"-{args[i]}");
                    }
                    else
                    {
                        o.Add("," + args[i].ToString());
                    }
                }
                else
                {
                    o.Add(args[i].ToString());
                }
            }
        }

        return string.Join("", o);
    }
    static int[] LeftShift(int[] array)
    {
        // all elements except for the first one... and at the end, the first one. to array.
        return array.Skip(1).Concat(array.Take(1)).ToArray();
    }

    static int[] RightShift(int[] array)
    {
        // the last element (because we're skipping all but one)... then all but the last one.
        return array.Skip(array.Length - 1).Concat(array.Take(array.Length - 1)).ToArray();
    }
}
    }
}
