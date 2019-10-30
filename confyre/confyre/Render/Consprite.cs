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
        internal Textel At(Pos2 p) {
            return At(p.X, p.Y);
        }

        public Textel this[int x, int y] => At(x, y);

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

        /// <summary>
        /// Returns a new Consprite including only the textels of a colour.
        /// </summary>
        /// <param name="colour"></param>
        /// <returns></returns>
        internal Consprite WithColour(ConsoleColor colour) {
            return new Consprite() { Textels = Textels.Where(x => x.Colour == colour).ToArray() };
        }

        public object Clone() {
            return new Consprite() {
                Height = Height,
                Width = Width,
                Textels = Textels
            };
        }

        /// <summary>
        /// Assembles one large Consprite out of a collection of Consprites.
        /// </summary>
        /// <param name="sprites"></param>
        /// <returns></returns>
        internal static Consprite AssembleMegaSprite(IEnumerable<Consprite> sprites) {
            int totalWidth = 0;
            int totalHeight = 0;
            int leastX = sprites.FirstOrDefault().Position.X;
            int leastY = sprites.FirstOrDefault().Position.Y;

            var zLevels = new Dictionary<int, List<Textel>>();

            foreach (Consprite s in sprites) {
                totalWidth += s.Width;
                totalHeight += s.Height;
                leastX = leastX < s.Position.X ? s.Position.X : leastX;
                leastY = leastY < s.Position.Y ? s.Position.Y : leastY;

                for (int i = 0; i < s.Width; i++) for (int j = 0; j < s.Height; j++)
                        zLevels[s.Z][(j + s.Position.Y) * s.Width + s.Position.X + i] = s[i, j];
            }

            var workingTextels = new Textel[totalWidth * totalHeight];
            foreach (int z in zLevels.Keys.OrderBy(x => x)) {
                for (int i = 0; i < zLevels[z].Count; i++) workingTextels[i] = zLevels[z][i];
            }

            var workingConsprite = new Consprite(totalWidth, totalHeight, leastX, leastY, 1) { Textels = workingTextels };
            return workingConsprite;
        }

        public static implicit operator Consprite(string s) {
            var cs = new Consprite(s.Length, 1) { };
            for (int i = 0; i < s.Length; i++) cs.Textels[i] = s[i];
            return cs;
        }
    }
}
