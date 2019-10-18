using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Math {
    internal static class Trig {
        public static int Distance(Render.Position.Pos2 pos1, Render.Position.Pos2 pos2) =>
            (int)System.Math.Sqrt((pos1.X - pos2.X) * (pos1.X - pos2.X) + (pos1.Y - pos2.Y) * (pos1.Y - pos2.Y));
    }
}
