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
        public GameOptions currentOptions = new GameOptions(GameBoardSize.small, GameDifficulty.easy);



        public void RunApplication()
        {
            bool isRunning = true;
            HighScore.Score = 50;
            while (isRunning)
            {
                Console.WindowWidth = 60;
                Console.WriteLine("Welcome to the Insatiably Hungry Snake Game! \n" +
                    $"1. Play on board size {currentOptions.BoardSize} at difficulty level {currentOptions.Difficulty}. \n" +
                    "2. Choose Board Size \n" +
                    "3. Set Game Difficulty \n" +
                    "4. Instructions \n" +
                    "5. Show High Score \n" +
                    "6. Rules \n" +
                    "7. Authors \n" +
                    "8. Exit Game");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        currentGame.StartGame(currentOptions);
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Choose Game Board Size:");
                        Console.WriteLine("1. Small \n" +
                            "2. Medium \n" +
                            "3. Large");
                        string userChoice = Console.ReadLine();
                        switch (userChoice)
                        {
                            case "1":
                                currentOptions.BoardSize = GameBoardSize.small;
                                break;
                            case "2":
                                currentOptions.BoardSize = GameBoardSize.medium;
                                break;
                            case "3":
                                currentOptions.BoardSize = GameBoardSize.large;
                                break;
                            default:
                                break;
                        };
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Choose Game Difficulty:");
                        Console.WriteLine("1. Easy \n" +
                            "2. Medium \n" +
                            "3. Hard");
                        string userOption = Console.ReadLine();                        
                        switch (userOption)
                        {
                            case "1":
                                currentOptions.Difficulty = GameDifficulty.easy;
                                break;
                            case "2":
                                currentOptions.Difficulty = GameDifficulty.medium;
                                break;
                            case "3":
                                currentOptions.Difficulty = GameDifficulty.hard;
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("INSTRUCTIONS: \n" +
                            "\n" +
                            "You will play the intolerably-hungry Blake the Snake. \n" +
                            "\n" +
                            "Consuming food will help Blake grow; it will also \n" +
                            "increase your score. \n" +
                            "\n" +
                            "Use your keyboard arrow keys to move Blake up, down, \n" +
                            "left, and right. \n" +
                            "\n" +
                            "GAME ENDING: \n" +
                            "\n" +
                            "If the snake hits the side of the board or runs into \n" +
                            "himself, the game ends. \n" +
                            "\n");
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine($"Sessions Corrent Highscore: {HighScore.Score} \n" +
                            "\n");
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("\n" + "RULES: \n" +
                            "\n" +
                            "You will play the intolerably-hungry Blake the Snake. \n" +
                            "Consuming food will help Blake grow; it will also \n" +
                            "increase your score. \n" +
                            "Use your keyboard arrow keys to move Blake up, down, \n" +
                            "left, and right. \n" +
                            "\n" +
                            "SCORING: \n" +
                            "\n" +
                            "Some food is more common than others, so its value \n" +
                            "differs: \n" +
                            "@ Apples are very common, so they are worth 10 points.\n" +
                            "* Cotton candy is less common, with a worth of 15 \n" +
                            "points.\n" +
                            "¥ People are rare, with a value of 25 points.\n" +
                            "~ Bacon: almost as good as chocolate. 50 points.\n" +
                            "\n" +
                            "GAME ENDING: \n" +
                            "\n" +
                            "If the snake hits the side of the board, the game ends. \n" +
                            "And if Blake takes a nibble of himself (runs into \n" +
                            "himself), the game also ends... for so many reasons.\n");
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("\n" + "AUTHORS: \n" +
                            "\n" +
                            "Jeff Deacon & Rochelle Deulley \n" +
                            "\n" +
                            "Contact for more world-changing applications... \n" +
                            "including a device that eliminates garbage with \n" +
                            "zero net emissions. \n" +
                            "Patent pending.\n" +
                            "\n");
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "8":
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
