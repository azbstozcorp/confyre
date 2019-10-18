using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render {
    /// <summary>
    /// Represents a ConsoleColor paired with a character for display.
    /// </summary>
    internal struct Textel : ICloneable {
        internal char Display;
        internal ConsoleColor Colour;

        internal Textel(char display, ConsoleColor colour) {
            Display = display;
            Colour = colour;
        }

        public object Clone() {
            return new Textel { Display = Display, Colour = Colour };
        }
    }
}
