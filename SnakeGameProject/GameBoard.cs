using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class GameBoard
    {
        //Generate Item Locations
        List<ItemLocations> gameItems = new List<ItemLocations>();
        List<ItemLocations> snake = new List<ItemLocations>();
        public void StartGame(GameOptions gameOptions)
        {

            //while (gameItems.Count < 3)
            //{
            //    gameItems.Add(AddGameItems(gameOptions));
            //}
            ItemLocations newSnake = new ItemLocations(2,2,"Snake",'$');
            snake.Add(newSnake);
            DrawBoard(gameOptions);
        }

        

        //We may want to investigate setting the window size.
        public void DrawBoard(GameOptions gameOptions)
        {
            for (int i = 0; i < 10; i++)
            {
                //Console.ReadLine();
                DrawBoardTop(gameOptions.BoardWidth);
                DrawBoardLine(gameOptions.BoardWidth, gameOptions.BoardHeight);
                DrawBoardBottom(gameOptions.BoardWidth);
                var move = Console.ReadKey(true).Key;
                switch (move)
                {

                    case ConsoleKey.LeftArrow:
                        snake[0].XAxis = snake[0].XAxis - 1;
                        break;
                    case ConsoleKey.UpArrow:
                        snake[0].YAxis = snake[0].YAxis - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        snake[0].XAxis = snake[0].XAxis + 1;
                        break;
                    case ConsoleKey.DownArrow:
                        snake[0].YAxis = snake[0].YAxis + 1;
                        break;

                }
            }
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
                    bool isSnake = CheckForSnake(x, y);
                    bool isFruit = CheckForFruit(x, y);
                    if (isSnake)
                    {
                        row = row + "$"; //Charecter needs to be passed in like a variable
                    }
                    else if (isFruit)
                    {
                        row = row + "@"; //Charecter needs to be passed in like a variable
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

        private ItemLocations AddSnake()
        {
            ItemLocations snakeHead = new ItemLocations(2, 2, "Snake", '$');
            return snakeHead;
        }
        private ItemLocations AddGameItems(GameOptions gameOptions)
        {
            ItemLocations item;
            Random rndX = new Random();
            Random rndY = new Random();
            int xAxis = rndX.Next(1, gameOptions.BoardWidth + 1);//gameOptions.BoardWidth + 1 is the correct random code
            int yAxis = rndY.Next(1, gameOptions.BoardHeight + 1); //gameOptions.BoardHeight + 1 is the correct random code
            if (gameItems.Count == 0)
            {
                ItemLocations firstItem = new ItemLocations(xAxis, yAxis, "Apple", '@');
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
                        item = new ItemLocations(xAxis, yAxis, "Apple", '@');
                        return item;
                    }
                }
                return null;
            }
            

        }
        private bool CheckForSnake(int x, int y)
        {
            bool result = false;
            foreach (ItemLocations item in snake)
            {
                if (x == item.XAxis && y == item.YAxis)
                {

                    result = true;
                }
            }
            return result;
        }

        private bool CheckForFruit(int x, int y)
        {
            bool result=false;
            foreach (ItemLocations item in gameItems)
            {
                if (x == item.XAxis && y == item.YAxis)
                {

                    result = true;
                }
            }
            return result;
        }


        public GameBoard()
        {

        }

    }
}
