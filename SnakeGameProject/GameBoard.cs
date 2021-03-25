using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeGameProject
{
    public class GameBoard
    {
        //Generate Item Locations
        List<ItemLocations> gameItems = new List<ItemLocations>();
        private readonly SnakeRepo snakeRepo = new SnakeRepo();
        int score = 0;
        int highScore = 0; //<- needs to pull from the High Score list and display on the game board #############################
        int gameSpeed = 0;
        public void StartGame(GameOptions gameOptions)
        {
            switch (gameOptions.Difficulty)
            {
                case GameDifficulty.easy:
                    gameSpeed = 600;
                    break;
                case GameDifficulty.medium:
                    gameSpeed = 450;
                    break;
                case GameDifficulty.hard:
                    gameSpeed = 300;
                    break;
                default:
                    gameSpeed = 600;
                    break;
            }

            while (gameItems.Count < 3)
            {
                gameItems.Add(AddGameItems(gameOptions));
                RemoveNullItems();
            }
            snakeRepo.CreateSnake();
            DrawBoard(gameOptions);
        }

        //We may want to investigate setting the window size.

        //DrawBoard is the turn mechanism for the game.
        public void DrawBoard(GameOptions gameOptions)
        {
            bool dead = false;
            while (dead == false)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"     Score: {score}     High Score: xxxxx");
                DrawBoardTop(gameOptions.BoardWidth);
                DrawBoardLine(gameOptions.BoardWidth, gameOptions.BoardHeight);
                DrawBoardBottom(gameOptions.BoardWidth);
                if (Console.KeyAvailable) //This is true if a key has been pressed. This prevents the game for waiting for a key stroke.
                {
                    var changeDirection = Console.ReadKey(true).Key;
                    switch (changeDirection)
                    {
                        case ConsoleKey.LeftArrow:
                            snakeRepo.GetSnake(0).Direction = MoveDirection.Left;
                            break;
                        case ConsoleKey.UpArrow:
                            snakeRepo.GetSnake(0).Direction = MoveDirection.Up;
                            break;
                        case ConsoleKey.RightArrow:
                            snakeRepo.GetSnake(0).Direction = MoveDirection.Right;
                            break;
                        case ConsoleKey.DownArrow:
                            snakeRepo.GetSnake(0).Direction = MoveDirection.Down;
                            break;
                    }
                }
                snakeRepo.AddSnake(snakeRepo.CreateNewHead(snakeRepo.GetSnake(0))); //Creates a new snake object and ADDs it at index 0 to the _gameSnake List, so its the first object in the list.
                snakeRepo.RemoveSnake(); //Removes the highest index snake object from the _gameSnake list

                dead = CheckCollision(snakeRepo.GetSnake(0), gameOptions); // Checks for snake collision and death
                //Remove Fruit, add a new random fruit, and increase score by fruit value.
                bool EatFruit = CheckForFruit(snakeRepo.GetSnake(0), gameOptions);
                if (EatFruit)
                {
                    ItemLocations itemToRemove = GetItem(snakeRepo.GetSnake(0).XAxis, snakeRepo.GetSnake(0).YAxis);
                    gameItems.Remove(itemToRemove);
                    while (gameItems.Count < 3)
                    {
                        gameItems.Add(AddGameItems(gameOptions));
                        RemoveNullItems();
                    }

                    snakeRepo.AddSnake(snakeRepo.CreateNewHead(snakeRepo.GetSnake(0)));
                }

                Thread.Sleep(gameSpeed); // <- Needs to be set with the difficulty paramater #################################
                Console.Clear();
            }
            Console.WriteLine("You DEAD!"); // Needs to implement Rochelles menu and replace lines 86 & 87

            Console.WriteLine("Congratulations! You've achieved a high score. Please enter your name:");
            var UserNameInput = Console.ReadLine();
            string userScore = HighScore.ShowPlayerScore(UserNameInput, score);
            Console.WriteLine("??");
            Console.WriteLine($"{userScore}");
            Console.ReadLine();
        }

        //Draw Game Board Methods
        private void DrawBoardTop(int boardWidth)
        {
            string top = "     ┌";
            for (int i = 0; i < boardWidth; i++)
            {
                top = top + "-";
            }
            top = top + "┐";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(top);

        }
        private void DrawBoardLine(int boardWidth, int boardHeight)
        {
            string row = "     ";
            for (int y = 1; y <= boardHeight; y++)
            {
                row = row + "|";

                for (int x = 1; x <= boardWidth; x++)
                {
                    bool isSnake = CheckForSnake(x, y);
                    bool isFruit = CheckForFruit(x, y);
                    if (isSnake)
                    {
                        row = row + GetSnakeIcon(x, y);
                    }
                    else if (isFruit)
                    {
                        row = row + GetFruitSymbol(x, y);
                    }
                    else
                    {
                        row = row + " ";
                    }
                }
                row = row + "|";
                Console.WriteLine(row);
                row = "     ";
            }
        }
        private void DrawBoardBottom(int boardWidth)
        {
            string bottom = "     └";
            for (int i = 0; i < boardWidth; i++)
            {
                bottom = bottom + "-";
            }
            bottom = bottom + "┘";
            Console.WriteLine(bottom);
        }
        private char GetSnakeIcon(int x, int y)
        {
            List<Snake> snakeParts = snakeRepo.GetWholeSnake();
            foreach (Snake snake in snakeParts)
            {
                if (x == snake.XAxis && y == snake.YAxis)
                {

                    return snake.SnakeIcon;
                }
            }
            return '$';
        }
        private char GetFruitSymbol(int x, int y)
        {

            foreach (ItemLocations item in gameItems)
            {
                if (x == item.XAxis && y == item.YAxis)
                {

                    return item.ItemIcon;
                }
            }
            return ' ';
        }
        private bool CheckForSnake(int x, int y)
        {
            bool result = false;
            List<Snake> snakeParts = snakeRepo.GetWholeSnake();
            foreach (Snake snake in snakeParts)
            {
                if (x == snake.XAxis && y == snake.YAxis)
                {

                    result = true;
                }
            }
            return result;
        }
        private bool CheckForFruit(int x, int y)
        {
            bool result = false;
            foreach (ItemLocations item in gameItems)
            {
                if (x == item.XAxis && y == item.YAxis)
                {

                    result = true;
                }
            }
            return result;
        } //There are two CheckForFruit Methods. <- Bool is used for drawing the Game Board

        //Add/Remove Food Item Methods
        private ItemLocations AddGameItems(GameOptions gameOptions)
        {
            ItemLocations item;
            Food food;
            Random rndItem = new Random();
            int itemID = rndItem.Next(1, 101);
            if (itemID > 90)
            {
                food = new Food(FoodName.Bacon);
            }
            else if (itemID > 70 && itemID < 91)
            {
                food = new Food(FoodName.Person);
            }
            else if (itemID > 50 && itemID < 71)
            {
                food = new Food(FoodName.CottonCandy);
            }
            else
            {
                food = new Food(FoodName.Apple);
            }


            Random rndX = new Random();
            Random rndY = new Random();
            int xAxis = rndX.Next(1, gameOptions.BoardWidth + 1);//gameOptions.BoardWidth + 1 is the correct random code
            int yAxis = rndY.Next(1, gameOptions.BoardHeight + 1); //gameOptions.BoardHeight + 1 is the correct random code
            if (gameItems.Count == 0)
            {
                ItemLocations firstItem = new ItemLocations(xAxis, yAxis, food.FoodType.ToString(), food.FoodCharacter, food.PointValue);
                return firstItem;
            }
            else
            {
                foreach (ItemLocations itemLocation in gameItems)
                {
                    if (xAxis == itemLocation.XAxis && yAxis == itemLocation.YAxis)
                    {
                        Console.WriteLine($"X: {xAxis}, Y: {yAxis}");
                        break;
                    }
                    else
                    {
                        item = new ItemLocations(xAxis, yAxis, food.FoodType.ToString(), food.FoodCharacter, food.PointValue);
                        return item;
                    }
                }
            }
            return null;


        }
        private void RemoveNullItems()
        {
            List<ItemLocations> nullItems = new List<ItemLocations>();
            foreach (ItemLocations item in gameItems)
            {
                if (item == null)
                {
                    nullItems.Add(item);
                }
            }
            foreach (ItemLocations deleteItem in nullItems)
            {
                gameItems.Remove(deleteItem);
            }

        }
        private ItemLocations GetItem(int xAxis, int yAxis)
        {
            foreach (ItemLocations item in gameItems)
            {
                if (item.XAxis == xAxis && item.YAxis == yAxis)
                {
                    return item;
                }
            }
            return null;
        }

        //Scoring/Collision Methods
        private bool CheckForFruit(Snake snake, GameOptions gameOptions)
        {
            foreach (ItemLocations item in gameItems)
            {
                if (item.XAxis == snake.XAxis && item.YAxis == snake.YAxis)
                {
                    score = score + item.PointValue;

                    return true;
                }
            }
            return false;
        } //There are two CheckForFruit Methods. <- Bool is used for scoring and removing fruit from the Game Board
        private bool CheckCollision(Snake snake, GameOptions gameOptions)
        {
            if (snake.XAxis <= 0 || snake.XAxis >= gameOptions.BoardWidth + 1)
            {
                return true;
            }
            if (snake.YAxis <= 0 || snake.YAxis >= gameOptions.BoardHeight + 1)
            {
                return true;
            }
            List<Snake> snakeParts = snakeRepo.GetWholeSnake();
            for (int i = 1; i < snakeParts.Count; i++)
            {
                if (snakeRepo.GetSnake(i).XAxis == snake.XAxis && snakeRepo.GetSnake(i).YAxis == snake.YAxis)
                {
                    return true;
                }
            }

            return false;

        } //Hit a wall or the snake and you die

        //Default Constructor
        public GameBoard()
        {

        }

    }
}