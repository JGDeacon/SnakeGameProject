using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class ProgramUI
    {
        GameBoard currentGame = new GameBoard();
        HighScoreRepo highScoreRepo = new HighScoreRepo();
        public GameOptions currentOptions = new GameOptions(GameBoardSize.small, GameDifficulty.easy);

        string userName = "";
        string userHighScore = "";

        public void RunApplication()
        {
            bool isRunning = true;
            highScoreRepo.SeedScores();
            while (isRunning)
            {
                Console.WindowWidth = 
                Console.WriteLine("Welcome to the Insatiably Hungry Snake Game! \n" +
                    $"1. Play on board size {currentOptions.BoardSize} at difficulty level {currentOptions.Difficulty}. \n" +
                    "2. Choose Board Size \n" +
                    "3. Set Game Difficulty \n" +
                    "4. Show High Scores \n" +
                    "5. Rules \n" +
                    "6. Authors \n" +
                    "7. Exit Game");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        currentGame.StartGame(currentOptions);
                        break;
                    case "2":
                        Console.WriteLine("1. Small \n" +
                            "2. Medium \n" +
                            "3. Large");
                        string userChoice = Console.ReadLine();
                        switch (userChoice)
                        {
                            case "1":
                                currentOptions.BoardSize = GameBoardSize.small;
                                Console.Clear();
                                break;
                            case "2":
                                currentOptions.BoardSize = GameBoardSize.medium;
                                Console.Clear();
                                break;
                            case "3":
                                currentOptions.BoardSize = GameBoardSize.large;
                                Console.Clear();
                                break;
                            default:
                                break;
                        };
                        break;
                    case "3":
                        Console.WriteLine("1. Easy \n" +
                            "2. Medium \n" +
                            "3. Hard");
                        string userOption = Console.ReadLine();
                        switch (userOption)
                        {
                            case "1":
                                currentOptions.Difficulty = GameDifficulty.easy;
                                Console.Clear();
                                break;
                            case "2":
                                currentOptions.Difficulty = GameDifficulty.medium;
                                Console.Clear();
                                break;
                            case "3":
                                currentOptions.Difficulty = GameDifficulty.hard;
                                Console.Clear();
                                break;
                            default:
                                break;
                        }
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Top 
                        List<HighScore> topFive = HighScoreRepo.GetListOfHighScores();
                        foreach (HighScore item in topFive)
                        {

                            Console.WriteLine($"Name: {item.DisplayName} Score: {item.DisplayScore}");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        Console.WriteLine("\n" + "RULES: \n" +
                            "\n" +
                            "You will play the intolerably-hungry Blake the Snake. \n" +
                            "Consuming food will help Blake grow; it will also increase your score. \n" +
                            "Use your keyboard arrow keys to move Blake up, down, left, and right. \n" +
                            "\n" +
                            "SCORING: \n" +
                            "\n" +
                            "Some food is more common than others, so its value differs: \n" +
                            "@ Apples are very common, so they are worth 10 points.\n" +
                            "* Cotton candy is less common, with a worth of 15 points.\n" +
                            "¥ People are rare, with a value of 25 points.\n" +
                            "~ Bacon: almost as good as chocolate. 50 points.\n" +
                            "\n" +
                            "GAME ENDING: \n" +
                            "\n" +
                            "If the snake hits the side of the board, the game ends. \n" +
                            "And if Blake takes a nibble of himself (runs into himself), the game also ends... for so many reasons.\n");
                        Console.WriteLine("Press any key to return to the main menu........");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.WriteLine("\n" + "AUTHORS: \n" +
                            "\n" +
                            "Jeff Deacon & Rochelle Deulley \n" +
                            "\n" +
                            "Contact for more world-changing applications... including a device that eliminates garbage with zero net emissions. \n" + "Patent pending.\n" +
                            "\n");
                        Console.WriteLine("Press any key to return to the main menu........");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":
                        isRunning = false;
                        break;
                }
            }
        }
        public void Run()
        {
            currentGame.StartGame(currentOptions);
            Console.ReadKey();
        }
    }
}
