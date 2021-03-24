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

        public void Run()
        {
            currentGame.StartGame(currentOptions);
            Console.ReadKey();
        }
    }
}
