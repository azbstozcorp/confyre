using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render.Position {
    internal class Rect {
        Pos2 topLeft, topRight, bottomLeft, bottomRight;

        internal int Top => topLeft.Y;
        internal int Bottom => bottomLeft.Y;
        internal int Left => topLeft.X;
        internal int Right => topRight.X;

        void MoveBy(Pos2 amount) {
            for (int i = 0; i < 4; i++) this[i] += amount;
        }

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
