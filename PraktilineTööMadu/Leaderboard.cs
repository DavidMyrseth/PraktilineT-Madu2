using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktilineTööMadu
{
    public class Leaderboard
    {
        // Method to save player's name, score, and time to a file
        public static void SaveScore(string playerName, int score, TimeSpan elapsedTime)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\..\Text.txt", true))
                {
                    string timeFormatted = $"{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
                    sw.WriteLine($"||Player Name:{playerName}||Points:{score}||Time:{timeFormatted}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving the file: {ex.Message}");
            }
        }

        // Display saved scores
        public static void DisplayScores()
        {
            string file = @"..\..\..\Text.txt";
            Console.WriteLine("\nPlayers and their scores:");

            if (File.Exists(file))
            {
                string[] scores = File.ReadAllLines(file);
                foreach (string score in scores)
                {
                    Console.WriteLine(score);
                }
            }
            else
            {
                Console.WriteLine("No results yet.");
            }
        }
    }
}
