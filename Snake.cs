using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        public List<int[]> positions = new List<int[]>();

        private DirectionEnum direction = DirectionEnum.None;

        private Board board;
        private Fruit fruit;

        public Snake(Board board, Fruit fruit)
        {

            this.board = board;
            this.fruit = fruit;

            this.GenerateInitialPosition();

        }

        private void GenerateInitialPosition()
        {
            Random random = new Random();

            int[] fieldLimits = this.board.GetFieldLength();

            int x = random.Next(1, fieldLimits[0]);
            int y = random.Next(1, fieldLimits[1]);

            this.positions.Add([x, y]);
        }

        public void Draw()
        {

            if (this.positions.Count() == this.board.innerBoard)
            {
                Console.Clear();
                Console.WriteLine("You Won ! Press any key to start again !");
                ConsoleKey key = Console.ReadKey().Key;
                this.board.Start();
            }

            if (this.positions[0][0] == this.fruit.x && this.positions[0][1] == this.fruit.y)
            {
                this.AddSize();
                this.fruit.Draw(this.positions);

            }

            this.board.Draw(this.positions, "0");


        }

        private void MakeMove()
        {

            int[] aux = null;
            int[] aux2 = null;

            this.board.Erase(this.positions);

            for (int i = 0; i < this.positions.Count(); i++)
            {

                if (i == 0)
                {
                    aux = new int[] { this.positions[i][0], this.positions[i][1] };

                    if(this.direction == DirectionEnum.Left)
                    {
                        this.positions[i][1]--;

                    } else if(this.direction == DirectionEnum.Right)
                    {
                        this.positions[i][1]++;

                    }
                    else if (this.direction == DirectionEnum.Up)
                    {
                        this.positions[i][0]--;

                    }
                    else if (this.direction == DirectionEnum.Down)
                    {
                        this.positions[i][0]++;

                    }

                    continue;
                }

                aux2 = this.positions[i];
                this.positions[i] = aux;

                aux = aux2;

            }

            this.Draw();

        }

        public void SetMovementKey(ConsoleKey key)
        {

            switch (key)
            {
                case ConsoleKey.RightArrow:
                    if (this.direction == DirectionEnum.Left)
                    {
                        this.MakeMove();
                        break;
                    }
                    this.direction = DirectionEnum.Right;
                    this.MakeMove();
                    break;
                case ConsoleKey.LeftArrow:
                    if (this.direction == DirectionEnum.Right)
                    {
                        this.MakeMove();
                        break;
                    }
                    this.direction = DirectionEnum.Left;
                    this.MakeMove();
                    break;
                case ConsoleKey.UpArrow:
                    if (this.direction == DirectionEnum.Down)
                    {
                        this.MakeMove();
                        break;
                    }
                    this.direction = DirectionEnum.Up;
                    this.MakeMove();

                    break;
                case ConsoleKey.DownArrow:

                    if (this.direction == DirectionEnum.Up)
                    {
                        this.MakeMove();
                        break;
                    }

                    this.direction = DirectionEnum.Down;
                    this.MakeMove();
                    break;
                default:
                    break;
            }
        }

        private void AddSize()
        {
            int[] lastPosition = this.positions.Last();

            int[] newPosition = new int[] { lastPosition[0], lastPosition[1] };

            if (this.direction == DirectionEnum.Right)
            {
                newPosition[1] -= 1;
            }
            else if (this.direction == DirectionEnum.Left)
            {
                newPosition[1] += 1;
            }
            else if (this.direction == DirectionEnum.Up)
            {
                newPosition[0] += 1;
            }
            else if (this.direction == DirectionEnum.Down)
            {
                newPosition[0] -= 1;
            }

            this.positions.Add(newPosition);

        }

    }
}