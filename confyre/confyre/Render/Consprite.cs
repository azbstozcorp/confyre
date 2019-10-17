using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render {
    /// <summary>
    /// Data structure represent a rectangular collection of RGB values.
    /// </summary>
    internal struct Consprite : ICloneable {
        internal int Width { get; private set; }
        internal int Height { get; private set; }
        internal Textel[] Textels;

        internal Consprite(int width, int height) {
            Width = width; Height = height;
            Textels = new Textel[Width * Height];
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
