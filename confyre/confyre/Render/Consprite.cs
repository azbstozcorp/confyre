using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using confyre.Render.Position;

namespace confyre.Render {
    /// <summary>
    /// Data structure represent a rectangular collection of RGB values.
    /// </summary>
    internal struct Consprite : ICloneable {
        internal Pos2 Position;
        internal int Width { get; private set; }
        internal int Height { get; private set; }
        internal int Z { get; private set; }
        internal Textel[] Textels;

        internal Textel At(int x, int y) {
            if (x > Width || x < 0 || y > Height || x < 0) throw new IndexOutOfRangeException("Internal sprite coordinates out of range.");
            return Textels[y * Width + x];
        }
        internal Textel At(Position.Pos2 p) {
            return At(p.X, p.Y);
        }

        internal Consprite(int width, int height) {
            Width = width; Height = height;
            Textels = new Textel[Width * Height];
            Z = 0;
            Position = new Pos2(0, 0);
        }
        internal Consprite(int width, int height, int z) : this(width, height) {
            Z = z;
        }
        internal Consprite(int width, int height, int x, int y, int z) : this(width, height, z) {
            Position = new Pos2(x, y);
        }
        internal Consprite(int width, int height, Pos2 position, int z) : this(width, height, position.X, position.Y, z) { }

        internal bool WithinRectangle(Rect rect) {
            return rect.Intersects(new Rect(Position, Position + new Pos2(Width, Height)));
        }

        public object Clone() {
            return new Consprite() {
                Height = Height,
                Width = Width,
                Textels = Textels
            };
        }
    }
}
