using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render.Position {
    internal class Rect {
        Pos2 topLeft, topRight, bottomLeft, bottomRight;

        internal Rect() { }
        internal Rect(Pos2 pos1, Pos2 pos2) {
            if(pos2.X < pos1.X || pos2.Y < pos1.Y) {
                Pos2 temp = pos1;
                pos1 = pos2;
                pos2 = temp;
            }

            topLeft = pos1;
            bottomRight = pos2;
            topRight = new Pos2(pos2.X, pos1.Y);
            bottomLeft = new Pos2(pos1.X, pos2.Y);
        }

        internal int Top => topLeft.Y;
        internal int Bottom => bottomLeft.Y;
        internal int Left => topLeft.X;
        internal int Right => topRight.X;

        internal int Width => Right - Left;
        internal int Height => Bottom - Top;

        internal void MoveBy(Pos2 amount) { for (int i = 0; i <= 3; i++) this[i] += amount; }
        internal void MoveBy(int amountX, int amountY) => MoveBy(new Pos2(amountX, amountY));

        internal bool Intersects(Rect other) => ((Top >= other.Top && Top <= other.Bottom) || (Bottom <= other.Bottom && Bottom >= other.Top))
                                             && ((Left >= other.Left && Left <= other.Right) || (Right <= other.Right && Right >= other.Left));

        public Pos2 this[int index] {
            get {
                switch (index) {
                    case 0: return topLeft;
                    case 1: return topRight;
                    case 2: return bottomLeft;
                    case 3: return bottomRight;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set {
                switch (index) {
                    case 0: topLeft = value; break;
                    case 1: topRight = value; break;
                    case 2: bottomLeft = value; break;
                    case 3: bottomRight = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
    }
}
