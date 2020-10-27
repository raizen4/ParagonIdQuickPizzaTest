using System;
using System.Linq;

namespace ParagonIdTest
{
    public static class Helpers
    {

        public static string RandomString()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string FormatTimeToBake(int durationToBakeInSeconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(durationToBakeInSeconds);

            return time.ToString(@"mm\:ss");
        }
    }
}
