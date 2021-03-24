using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public enum MoveDirection { Up, Down, Left, Right}
    public class Snake
    {
        public MoveDirection Direction { get; set; }
        public int Length { get; set; }
        public int Score { get; set; }
        public List<ItemLocations> SnakeLocations { get; set; } = new List<ItemLocations>();

        public Snake()
        {
            ItemLocations snake = new ItemLocations(2, 2, "Snake", '$');
            Direction = MoveDirection.Right;
            Length = 1;
            Score = 0;
            SnakeLocations.Add(snake);

        }
    }
}
