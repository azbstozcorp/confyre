using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render.Position {
    internal class Position : Pair<int> {
        internal Position() : base() { }
        internal Position(int x, int y) : base(x, y) { }

        internal int Sum => X + Y;
        internal int Length => (int)System.Math.Sqrt((X * X) + (Y * Y));

        public override bool Equals(object obj) {
            if (!(obj is Position)) return false;
            return (obj as Position) == this;
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y);
        public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y);
        public static Position operator *(Position a, Position b) => new Position(a.X * b.X, a.Y * b.Y);
        public static Position operator /(Position a, Position b) => new Position(a.X / b.X, a.Y / b.Y);
        public static Position operator +(int a, Position n) => new Position(n.X + a, n.Y + a);
        public static Position operator -(int a, Position n) => new Position(n.X - a, n.Y - a);
        public static Position operator *(int a, Position n) => new Position(n.X * a, n.Y * a);
        public static Position operator /(int a, Position n) => new Position(n.X / a, n.Y / a);
        public static Position operator ++(Position a) => new Position(++a.X, ++a.Y);
        public static Position operator --(Position a) => new Position(--a.X, --a.Y);
        public static bool operator ==(Position a, Position b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Position a, Position b) => !(a.X == b.X && a.Y == b.Y);
    }
}
