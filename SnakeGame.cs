using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class SnakeGame
    {
        public void Start()
        {
            Console.CursorVisible = false;
            Boolean gameIsOn = true;

            Board board = new Board(10, 10);
            Fruit fruit = new Fruit(board);
            Snake snake = new Snake(board, fruit);

            board.InitializeBoard();
            snake.Draw();
            fruit.Draw(snake.positions);

            ConsoleKey key = ConsoleKey.NoName;
            ConsoleKey prevKey = ConsoleKey.NoName;

            while (gameIsOn)
            {
                Console.SetCursorPosition(0, 0);

                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;

                }

                Boolean availableKeys = key == ConsoleKey.LeftArrow || key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow;

                if (availableKeys)
                {
                    prevKey = key;
                    snake.SetMovementKey(key);

                }
                else
                {
                    snake.SetMovementKey(prevKey);

                }

                Thread.Sleep(200);

            }
        }
    }
}
