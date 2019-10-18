using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render.Position {
    internal class Pos2 : Pair<int> {
        internal Pos2() : base() { }
        internal Pos2(int x, int y) : base(x, y) { }

        internal int Sum => X + Y;
        internal int Length => (int)System.Math.Sqrt((X * X) + (Y * Y));

        public override bool Equals(object obj) {
            if (!(obj is Pos2)) return false;
            return (obj as Pos2) == this;
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public static Pos2 operator +(Pos2 a, Pos2 b) => new Pos2(a.X + b.X, a.Y + b.Y);
        public static Pos2 operator -(Pos2 a, Pos2 b) => new Pos2(a.X - b.X, a.Y - b.Y);
        public static Pos2 operator *(Pos2 a, Pos2 b) => new Pos2(a.X * b.X, a.Y * b.Y);
        public static Pos2 operator /(Pos2 a, Pos2 b) => new Pos2(a.X / b.X, a.Y / b.Y);
        public static Pos2 operator +(int a, Pos2 n) => new Pos2(n.X + a, n.Y + a);
        public static Pos2 operator -(int a, Pos2 n) => new Pos2(n.X - a, n.Y - a);
        public static Pos2 operator *(int a, Pos2 n) => new Pos2(n.X * a, n.Y * a);
        public static Pos2 operator /(int a, Pos2 n) => new Pos2(n.X / a, n.Y / a);
        public static Pos2 operator ++(Pos2 a) => new Pos2(++a.X, ++a.Y);
        public static Pos2 operator --(Pos2 a) => new Pos2(--a.X, --a.Y);
        public static bool operator ==(Pos2 a, Pos2 b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Pos2 a, Pos2 b) => !(a.X == b.X && a.Y == b.Y);
    }
}
