using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        public int [,] position;

        private Board board;
        public Snake(Board board) {

            this.board = board;

            Random random = new Random();
            
            int []fieldLimits = this.board.getFieldLength();

            int x = random.Next(1, fieldLimits[0] - 1);
            int y = random.Next(1, fieldLimits[1] - 1);

            this.position = new int[1,2] {{x,y}};
        }

        public void Draw()
        {

            for (int i = 0; i < this.position.GetLength(0); i++)
            {
                this.board.Draw(this.position[i, 0], this.position[i, 1], "==");
            }

        }

        public void MoveRight() {

            for (int i = 0; i < this.position.GetLength(0); i++)
            {
                this.board.Erase(this.position[i,0], this.position[i,1]);
                this.position[i,1] += 1;
            }

            this.Draw();

        }
        
        public void MoveLeft() {

            for (int i = 0; i < this.position.GetLength(0); i++)
            {
                this.board.Erase(this.position[i,0], this.position[i,1]);
                this.position[i,1] -= 1;
            }

            this.Draw();

        }
        public void MoveUp() {

            for (int i = 0; i < this.position.GetLength(0); i++)
            {
                this.board.Erase(this.position[i,0], this.position[i,1]);
                this.position[i,0] -= 1;
            }

            this.Draw();

        }
        public void MoveDown() {

            for (int i = 0; i < this.position.GetLength(0); i++)
            {
                this.board.Erase(this.position[i,0], this.position[i,1]);
                this.position[i,0] += 1;
            }

            this.Draw();
        }
        
    }
}