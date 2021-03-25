using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class HighScore
    {
        public static string Name { get; set; }
        public static int Score { get; set; }
        public int Rank { get; set; }
        public string DisplayName { get; set; }
        public int DisplayScore { get; set; }

        //public HighScore()
        //{

        //}



        public HighScore(int score, string name)
        {
            Name = name;
            Score = score;
            DisplayName = name;
            DisplayScore = score;
        }

        public static Dictionary<string, int> UserHighScores { get; set; } = new Dictionary<string, int>();

        //call this method upon player death
        // -----Beginning of test code!!-----
        public int GetRank(List<HighScore> highScores, HighScore score)
        {
            int setIndex = 0;
            foreach (HighScore item in highScores)
            {
                if (score.DisplayScore>item.DisplayScore)
                {
                    return setIndex;
                }
                setIndex++;
            }
            return setIndex;
        }
        
        public static int nameCount { get; set; }
        public static string ShowPlayerScore(string name, int score)
        {

            string user = "";
            foreach (var playerName in UserHighScores)
            {
                if (playerName.Key == null)
                {
                    nameCount++;
                    UserHighScores.Add(name, score);
                    return user += $"{name} {score}";
                }
                else if (playerName.Key != name)
                {
                    nameCount++;
                    UserHighScores.Add(name, score);
                    return user += $"{name} {score}";
                }
                else
                {
                    nameCount++;
                    UserHighScores.Add(name + $"{nameCount}", score);
                    return user += $"{name} {score}";
                }
            }
            return user;
        }

        public static void SeedScores()
        {
            UserHighScores.Add("AAA", 10);
            UserHighScores.Add("BBB", 10);
            UserHighScores.Add("CCC", 10);
            UserHighScores.Add("DDD", 10);
            UserHighScores.Add("EEE", 10);
            


        }


        //public static void ShowPlayerResults(Dictionary<string, int> highScoreResults)
        //{

        //}
        //public static void DoingSomething()
        //{
        //    foreach (var player in UserHighScores.Values)
        //    {
        //        Console.WriteLine(player);
        //    }
        //}
    }
}