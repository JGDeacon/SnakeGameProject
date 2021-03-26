using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameProject
{
    public class SnakeRepo
    {
        protected readonly List<Snake> _gameSnake = new List<Snake>();
        public void CreateSnake()
        {
            Snake snake = new Snake();
            _gameSnake.Add(snake);
        }
        public void AddSnake(Snake snake)
        {
            _gameSnake.Insert(0, snake);
        }
        public void RemoveWholeSnake()
        {
            _gameSnake.RemoveRange(0, _gameSnake.Count);
        }
        public void RemoveSnake()
        {
            _gameSnake.Remove(GetSnake(_gameSnake.Count - 1));
        }

        public Snake CreateNewHead(Snake snake)
        {
            Snake newSnake = new Snake();
            switch (snake.Direction)
            {
                case MoveDirection.Up:
                    newSnake.Score = snake.Score;
                    newSnake.XAxis = snake.XAxis;
                    newSnake.YAxis = snake.YAxis - 1;
                    newSnake.SnakeIcon = snake.SnakeIcon;
                    newSnake.Direction = snake.Direction;
                    break;
                case MoveDirection.Down:
                    newSnake.Score = snake.Score;
                    newSnake.XAxis = snake.XAxis;
                    newSnake.YAxis = snake.YAxis + 1;
                    newSnake.SnakeIcon = snake.SnakeIcon;
                    newSnake.Direction = snake.Direction;
                    break;
                case MoveDirection.Left:
                    newSnake.Score = snake.Score;
                    newSnake.XAxis = snake.XAxis - 1;
                    newSnake.YAxis = snake.YAxis;
                    newSnake.SnakeIcon = snake.SnakeIcon;
                    newSnake.Direction = snake.Direction; 
                    break;
                case MoveDirection.Right:
                    newSnake.Score = snake.Score;
                    newSnake.XAxis = snake.XAxis + 1;
                    newSnake.YAxis = snake.YAxis;
                    newSnake.SnakeIcon = snake.SnakeIcon;
                    newSnake.Direction = snake.Direction;
                    break;
                default:
                    newSnake = new Snake();
                    newSnake.Direction = snake.Direction;
                    //snake.Direction = MoveDirection.None;
                    break;
            }
            return newSnake;

        }

        
        public Snake GetSnake(int x)
        {
            Snake snake = _gameSnake[x];
            return snake;
        }
        public List<Snake> GetWholeSnake()
        {
            return _gameSnake;
        }
    }
}
