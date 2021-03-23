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
        GameOptions currentOptions = new GameOptions();

        public void Run()
        {
            currentGame.DrawBoard(currentOptions);
            Console.ReadKey();
        }
    }
}
