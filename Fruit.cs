using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame
{
    public class Fruit
    {
        public int x;
        public int y;
        private Board board;
        private Snake snake;

        public Fruit(Board board) {

            this.board = board;

        }

        private int[] GeneratePosition(int delimiterX, int delimiterY) {

            Random random = new Random();

            int x = random.Next(1,delimiterX);
            int y = random.Next(1,delimiterY);

            return [x,y];

        }

        private void SetPosition(List<int[]> snakeCoords)
        {
            int[] fieldLimits = board.GetFieldLength();
            int[] positions;

            do
            {
                positions = this.GeneratePosition(fieldLimits[0], fieldLimits[1]);
            }
            while (snakeCoords.Any(snake => snake[0] == positions[0] && snake[1] == positions[1]));

            this.x = positions[0];
            this.y = positions[1];
        }

        public void Draw(List<int[]> snakeCoords) {

            this.SetPosition(snakeCoords);
            this.board.Draw(new List<int[]> { new int[] { this.x, this.y } }, "*");
            
        }

    }
}