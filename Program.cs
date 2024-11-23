namespace SnakeGame;

class Program
{
    static void Main(string[] args)
    {

        Boolean gameIsOn = true;

        Board board = new Board(20, 20);
        Snake snake = new Snake(board);
        Fruit fruit = new Fruit(board, snake);

        board.InitializeBoard();
        snake.Draw();
        fruit.Draw();

        while (gameIsOn)
        {

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    Console.Clear();
                    snake.MoveRight();
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    snake.MoveLeft();
                    break;
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    snake.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    Console.Clear();
                    snake.MoveDown();
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("Exiting...");
                    gameIsOn = false;
                    return;

                default:
                    Console.WriteLine("\nNot an arrow key.");
                    break;
            }

        }

    }
}
