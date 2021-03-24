using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class SnakeRepo
    {

        public Snake CreateSnake()
        {
            Snake snake = new Snake();
            return snake;
        }
        public void SnakeMove(Snake snake)
        {
            foreach (ItemLocations snakeLocations in snake.SnakeLocations)
            {

                switch (snake.Direction)
                {
                    case MoveDirection.Up:
                        snakeLocations.YAxis = snakeLocations.YAxis - 1;
                        break;
                    case MoveDirection.Down:
                        snakeLocations.YAxis = snakeLocations.YAxis + 1;
                        break;
                    case MoveDirection.Left:
                        snakeLocations.XAxis = snakeLocations.XAxis - 1;
                        break;
                    case MoveDirection.Right:
                        snakeLocations.XAxis = snakeLocations.XAxis - 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
