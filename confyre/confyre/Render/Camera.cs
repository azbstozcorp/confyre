using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using confyre.Render.Position;

namespace confyre.Render {
    internal class Camera {
        internal Pos2 location;
        internal int zoom;
        internal int width;
        internal int height;

        internal Camera() { }
        internal Camera(Pos2 position) : this() { location = position; }
        internal Camera(Pos2 position, int zoom) : this(position) { this.zoom = zoom; }
        internal Camera(Pos2 position, int width, int height, int zoom) : this(position, zoom) {
            this.width = width;
            this.height = height;
        }

        internal Pos2 ScreenToWorld(Pos2 screenLocation) => screenLocation / zoom + location;
        internal Pos2 WorldToScreen(Pos2 worldLocation) => (worldLocation - location) * zoom;
    }
}
