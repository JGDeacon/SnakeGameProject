using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public enum GameBoardSize { small, medium, large }
    public enum GameDifficulty { easy, medium, hard }
    public class GameOptions
    {
        //Properties
        public GameBoardSize BoardSize { get; set; }

        public GameDifficulty Difficulty { get; set; }
        public int BoardWidth 
        { 
            get
            { 
                return GetBoardWidth(BoardSize); 
            } 
        }      
        
        public int BoardHeight 
        {
            get
            {
                return GetBoardHeight(BoardSize);
            } 
        }
        //Methods
        private int GetBoardHeight(GameBoardSize gameBoardSize)
        {
            int value = 0;
            switch (gameBoardSize)
            {
                case GameBoardSize.small:
                    value = 18;
                    return value;
                case GameBoardSize.medium:
                    value = 21;
                    return value;
                case GameBoardSize.large:
                    value = 25;
                    return value;
                default:
                    value = 18;
                    return value;
            }
        }

        

        public int GetBoardWidth(GameBoardSize gameBoardSize) 
        {
            int value = 0;
            switch (gameBoardSize)
            {                
                case GameBoardSize.small:
                    value = 30;
                    return value;
                case GameBoardSize.medium:
                    value = 40;
                    return value;
                case GameBoardSize.large:
                    value = 50;
                    return value;
                default:
                    value = 30;
                    return value;
            }


        }
        public GameOptions()
        {

        }
        public GameOptions(GameBoardSize boardSize, GameDifficulty difficulty)
        {
            BoardSize = boardSize;
            Difficulty = difficulty;
            
        }

    }   
}
