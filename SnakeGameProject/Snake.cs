using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public enum MoveDirection { Up, Down, Left, Right, None }
    public class Snake
    {
        public MoveDirection Direction { get; set; }
       // public int Length { get; set; } The length will come from the list count
        public int Score { get; set; }
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public char SnakeIcon { get; set; }
        //public List<ItemLocations> SnakeLocations { get; set; } = new List<ItemLocations>();

        public Snake()
        {

            Direction = MoveDirection.Right;
            //Length = 1;
            Score = 0;
            XAxis = 2;
            YAxis = 2;
            SnakeIcon = '$';
        }
        public Snake(int x, int y)
        {
            XAxis = x;
            YAxis = y;
        }
    }
}
