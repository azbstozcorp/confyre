using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render.Position {
    internal class Pos2 : Pair<int> {
        internal Pos2(int x, int y) : base(x, y) { }

        public static Pos2 operator +(Pos2 a, Pos2 b) => new Pos2(a.X + b.X, a.Y + b.Y);
        public static Pos2 operator -(Pos2 a, Pos2 b) => new Pos2(a.X - b.X, a.Y - b.Y);
        public static Pos2 operator *(Pos2 a, Pos2 b) => new Pos2(a.X * b.X, a.Y * b.Y);
        public static Pos2 operator /(Pos2 a, Pos2 b) => new Pos2(a.X / b.X, a.Y / b.Y);
    }
}
