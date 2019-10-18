using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using confyre.Render.Position;

namespace confyre.Render {
    internal class Camera {
        Pos2 location;
        float zoom;

        internal Camera() { }
        internal Camera(Pos2 position) { location = position; }
        internal Camera(Pos2 position, float zoom) : this(position) { this.zoom = zoom; }

        internal void ZoomIn(float amount) { zoom *= amount; }
        internal void ZoomOut(float amount) { zoom -= amount; }
    }
}
