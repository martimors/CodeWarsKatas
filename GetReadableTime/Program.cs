using System;

namespace GetReadableTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TimeFormat.GetReadableTime(359999));
        }
    }
    public static class TimeFormat
    {
        public static string GetReadableTime(int seconds)
        {
            var offset = new TimeSpan(0, 0, seconds);
            return $"{(int)offset.TotalHours:00}:{offset.Minutes:00}:{offset.Seconds:00}";
        }
    }
}
