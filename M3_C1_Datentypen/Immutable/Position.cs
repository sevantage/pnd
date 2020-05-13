using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutable
{
    public class Position
    {
        private readonly int x;
        private readonly int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Position Move(int deltaX, int deltaY)
        {
            return new Position(this.x + deltaX, this.y + deltaY);
        }
    }
}
