using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render.Position {
    internal class Rect {
        internal Pos2 TopLeft { get; private set; }
        internal Pos2 BottomRight { get; private set; }

        internal int Left => TopLeft.X;
        internal int Right => BottomRight.X;
        internal int Top => TopLeft.Y;
        internal int Bottom => BottomRight.Y;

        public static bool IntersectsWith(this Rect me, Rect other) => ()
    }
}
