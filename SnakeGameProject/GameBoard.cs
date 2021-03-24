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

        //We may want to investigate setting the window size.
        public void DrawBoard(GameOptions gameOptions)
        {
            while (gameItems.Count < 3)
            {

                gameItems.Add(AddGameItems(gameOptions));
            }
            foreach (ItemLocations item in gameItems) //testing only lines 21-24
            {
                Console.WriteLine($" X: {item.XAxis}, Y: {item.YAxis}, Name: {item.ItemName}, Item Icon: {item.ItemIcon}");
            }
            //Console.ReadLine();
            DrawBoardTop(gameOptions.BoardWidth);
            DrawBoardLine(gameOptions.BoardWidth, gameOptions.BoardHeight);
            DrawBoardBottom(gameOptions.BoardWidth);
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
            for (int y = 0; y < boardHeight; y++)
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
            return false;
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
