using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render.Position {
    internal class Position : Pair<int> {
        internal Position(int x, int y) : base(x, y) { }

        public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y);
        public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y);
        public static Position operator *(Position a, Position b) => new Position(a.X * b.X, a.Y * b.Y);
        public static Position operator /(Position a, Position b) => new Position(a.X / b.X, a.Y / b.Y);
    }
}
