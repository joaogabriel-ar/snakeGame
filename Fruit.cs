using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Fruit
    {
        public int x;
        public int y;
        private Board board;

        public Fruit(Board board, Snake snake) {

            this.board = board;

            int []fieldLimits = board.getFieldLength();

            int []positions = this.generatePosition(fieldLimits[0], fieldLimits[1]);

            Boolean isInSnakePosition = false;

            for (int i = 0; i < snake.position.GetLength(0); i++)
            {
                isInSnakePosition = positions[0] == snake.position[i,0] && positions[1] == snake.position[i,1];
            }

            while(isInSnakePosition) {

                positions = this.generatePosition(positions[0], positions[1]);
            }

            this.x = positions[0];
            this.y = positions[1];
        }

        private int[] generatePosition(int delimiterX, int delimiterY) {

            Random random = new Random();

            int x = random.Next(1,delimiterX - 1);
            int y = random.Next(1,delimiterY - 1);

            return [x,y];

        }

        public void Draw() {

            this.board.Draw(this.x, this.y, "• ");

        }

    }
}