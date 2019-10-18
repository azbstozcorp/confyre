using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre.Render.Position {
    internal class Pair<T> {
        internal T X { get => values[0]; set => values[0] = value; }
        internal T Y { get => values[1]; set => values[1] = value; }

        T[] values = new T[2];

        internal Pair() { }
        internal Pair(T x, T y) {
            values[0] = x;
            values[1] = y;
        }
        ~Pair() { }
    }
}
