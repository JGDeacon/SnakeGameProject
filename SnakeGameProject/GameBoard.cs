using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class GameBoard
    {
        public void DrawBoard(GameOptions gameOptions)
        {
            DrawBoardTop(gameOptions.BoardWidth);
            DrawBoardLine(gameOptions.BoardWidth, gameOptions.BoardHeight);
            //DrawBoardBottom(gameOptions.BoardWidth);
        }

        private void DrawBoardTop(int boardWidth)
        {
            string top = "┌";
            for (int i = 1; i < boardWidth; i++)
            {
                top = top + "-";
            }
            top = top + "┐";
            Console.WriteLine(top);

        }

        private void DrawBoardLine(int boardWidth, int boardHeight)
        {
            string row = "";
            for (int x = 0; x < boardWidth; x++)
            {
                    row = row + "|";
                
                for (int y = 1; y < boardHeight; y++)
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

        private bool CheckForSnake(int x, int y)
        {
            return false;
        }

        private bool CheckForFruit(int x, int y)
        {
            return false;
        }

        private void DrawBoardBottom(int boardWidth)
        {
            throw new NotImplementedException();
        }
        public GameBoard()
        {

        }

    }
}
