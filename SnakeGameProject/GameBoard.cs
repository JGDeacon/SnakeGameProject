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
        //List<ItemLocations> snake = new List<ItemLocations>();
        private readonly SnakeRepo snakeRepo = new SnakeRepo();
        int score = 0;
        public void StartGame(GameOptions gameOptions)
        {
            
            while (gameItems.Count < 3)
            {
                gameItems.Add(AddGameItems(gameOptions));
                RemoveNullItems();
            }
            //ItemLocations appleOne = new ItemLocations(4, 5, "Apple", '@');
            //ItemLocations appleTwo = new ItemLocations(14, 9, "Apple", '@');
            //ItemLocations appleThree = new ItemLocations(7, 13, "Apple", '@');
            //gameItems.Add(appleOne);
            //gameItems.Add(appleTwo);
            //gameItems.Add(appleThree);
            ItemLocations newSnake = new ItemLocations(1, 1, "Snake", '§');
            snakeRepo.CreateSnake();
            DrawBoard(gameOptions);
        }



        //We may want to investigate setting the window size.
        public void DrawBoard(GameOptions gameOptions)
        {
            
            bool dead = false;
            while (dead == false)
            {
                //Console.ReadLine();
                Console.WriteLine($"Score: {score}");
                DrawBoardTop(gameOptions.BoardWidth);
                DrawBoardLine(gameOptions.BoardWidth, gameOptions.BoardHeight);
                DrawBoardBottom(gameOptions.BoardWidth);
                if (Console.KeyAvailable)
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
                //snakeRepo.SnakeMove(snakeRepo.GetWholeSnake());
                snakeRepo.AddSnake(snakeRepo.CreateNewHead(snakeRepo.GetSnake(0)));
                snakeRepo.RemoveSnake();

                //snakeRepo.RemoveTail();
                dead = CheckCollision(snakeRepo.GetSnake(0), gameOptions);
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
                Thread.Sleep(300);
                Console.Clear();
            }
            Console.WriteLine("You DEAD!");
            Console.ReadLine();
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

        private void DrawBoardTop(int boardWidth)
        {
            string top = "┌";
            for (int i = 0; i < boardWidth; i++)
            {
                top = top + "-";
            }
            top = top + "┐";
            Console.WriteLine(top);

        }

        private void DrawBoardLine(int boardWidth, int boardHeight)
        {
            string row = "";
            for (int y = 1; y <= boardHeight; y++)
            {
                row = row + "|";

                for (int x = 1; x <= boardWidth; x++)
                {
                    bool isSnake = CheckForSnake(x,y);
                    bool isFruit = CheckForFruit(x,y);
                    if (isSnake)
                    {
                        row = row + GetSnakeIcon(x,y); 
                    }
                    else if (isFruit)
                    {
                        row = row + GetFruitSymbol(x,y); 
                    }
                    else
                    {
                        row = row + " ";
                    }
                }
                row = row + "|";
                Console.WriteLine(row);
                row = "";
            }
        }
        private void DrawBoardBottom(int boardWidth)
        {
            string bottom = "└";
            for (int i = 0; i < boardWidth; i++)
            {
                bottom = bottom + "-";
            }
            bottom = bottom + "┘";
            Console.WriteLine(bottom);
        }

        //private ItemLocations AddSnake()
        //{
        //    ItemLocations snakeHead = new ItemLocations(2, 2, "Snake", '$');
        //    return snakeHead;
        //}
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
                ItemLocations firstItem = new ItemLocations(xAxis, yAxis, food.FoodType.ToString(), food.FoodCharacter, food.PointValue) ;
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
        }
        private bool CheckCollision(Snake snake,GameOptions gameOptions)
        {
            if (snake.XAxis == 0 || snake.XAxis ==gameOptions.BoardWidth+1)
            {
                return true;
            }
            if (snake.YAxis == 0 || snake.YAxis == gameOptions.BoardHeight+1)
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

        public GameBoard()
        {

        }

    }
}
