using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Board
    {
        private string[,] field;

        public Board(int x, int y)
        {
            field = new string[x, y];

        }

        public void InitializeBoard() {
            this.setField();
        }

        public void DrawBoard()
        {            
            for (int x = 0; x < this.field.GetLength(0); x++)
            {
                Console.Write("\n");

                for (int y = 0; y < this.field.GetLength(1); y++)
                {
                    if (x == 0 || y == 0 || (x > 0 && y == this.field.GetLength(1) - 1) || x == this.field.GetLength(0) - 1)
                    {
                        this.field[x, y] = "::";

                    }

                    Console.Write(this.field[x, y]);
                }
            }

        }

        public void setField() {

             for (int x = 0; x < this.field.GetLength(0); x++)
            {
                for (int y = 0; y < this.field.GetLength(1); y++)
                {
                    this.field[x,y] = "  ";
                }
            }

        }

        public int[] getFieldLength() {

            return [this.field.GetLength(0), this.field.GetLength(1)];

        }

        public void Draw(int x, int y, string item) {

            this.field[x,y] = item;

            this.DrawBoard();

        }

        public void Erase(int x, int y) {

         this.field[x,y] = "  ";

        }

    }
}