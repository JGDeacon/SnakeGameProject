//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SnakeGameProject
//{
//    public class HighScoreRepo
//    {
//        protected readonly List<HighScore> _scoreBoard = new List<HighScore>();
//        public void List<HighScore> GetListOfHighScores()
//        {
//            List<HighScore> orderedList = new List<HighScore>();
//            foreach (HighScore item in _scoreBoard)
//            {

//            }
//            //string name = "";
//            //int score = 0;
//            //int setIndex = 0;
//            //List<HighScore> scoreList = new List<HighScore>();
//            //List<HighScore> orderedHighScoreList = new List<HighScore>();
//            //foreach (var item in HighScore.UserHighScores)
//            //{
//            //    name = item.Key;
//            //    score = item.Value;
//            //    HighScore playerScore = new HighScore(score, name);
//            //    if (scoreList.Count > 1)
//            //    {
//            //        scoreList.Add(playerScore);
//            //    }

//            //}

//            ////foreach (HighScore highScore in scoreList)
//            ////{
//            ////    setIndex = highScore.GetRank(scoreList, highScore.DisplayScore);
//            ////}

//            //return scoreList;

//        }
//    public void AddScore(string name, int score)
//        {
//            int setRank = 1;
//            HighScore highScore = new HighScore(score, name);
//            if (_scoreBoard.Count>0)
//            {
//                foreach (HighScore item in _scoreBoard)
//                {
//                    if (score > item.DisplayScore)
//                    {
//                        item.Rank = setRank;
//                    }
//                    setRank++;
//                }
//                _scoreBoard.Add(highScore);
//            }
//            else
//            {
//                highScore.Rank = setRank;
//                _scoreBoard.Add(highScore);
//            }
            
            
//        }
//        public void SeedScores()
//        {
//            AddScore("Rock", 50);
//            AddScore("Hogan", 70);
//            AddScore("Stone Cold Steve Austin", 60);
//        }
//    }

 
//}
