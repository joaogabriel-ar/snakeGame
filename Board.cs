using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Board : SnakeGame
    {
        private string[,] field;
        public int x;
        public int y;
        public int innerBoard;
        public Board(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.innerBoard = (this.x * this.y) - ((this.x * 2) + (this.y * 2) - 4);
            field = new string[x, y];

        }

        public void InitializeBoard() {
            this.SetField();
        }

        private void DrawBoard()
        {            
            for (int x = 0; x < this.field.GetLength(0); x++)
            {
                Console.Write("\n");

                for (int y = 0; y < this.field.GetLength(1); y++)
                {
                    if (x == 0 || y == 0 || (x > 0 && y == this.field.GetLength(1) - 1) || x == this.field.GetLength(0) - 1)
                    {
                        this.field[x, y] = "+";

                    }

                    Console.Write(this.field[x, y]);
                }
            }

        }

        public void SetField() {

             for (int x = 0; x < this.field.GetLength(0); x++)
            {
                for (int y = 0; y < this.field.GetLength(1); y++)
                {
                    this.field[x,y] = " ";
                }
            }

        }

        public int[] GetFieldLength() {

            return [this.field.GetLength(0) - 1, this.field.GetLength(1) - 1];

        }

        public void Draw(List<int[]> positions, string item) {
            
            Console.SetCursorPosition(0, 0);

            if (positions[0][0] >= this.field.GetLength(0) - 1 || positions[0][1] >= this.field.GetLength(1) - 1
                || positions[0][0] <= 0 || positions[0][1] <=0)
            {
                Console.Clear();
                Console.WriteLine("You lost ! Press any key to start again !");
                ConsoleKey key = Console.ReadKey().Key;
                this.Start();
            }

            int[] head = new int[] { positions[0][0], positions[0][1] };

            for (int i = 0; i < positions.Count(); i++)
            {
                if (i > 0 && head[0] == positions[i][0] && head[1] == positions[i][1])
                {
                    Console.Clear();
                    Console.WriteLine("You lost ! Press any key to start again !");
                    ConsoleKey key = Console.ReadKey().Key;
                    this.Start();
                }

                this.field[positions[i][0], positions[i][1]] = item;
            }

            this.DrawBoard();

        }

        public void Erase(List<int[]> positions) {

        foreach(var position in positions)

            this.field[position[0],position[1]] = " ";

        }

    }
}