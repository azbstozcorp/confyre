using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using confyre.Render.Position;

namespace confyre.Render {
    internal class WorldSpace {
        internal Camera camera;
        internal List<Consprite> sprites;

        internal List<Consprite> AABBCull() {
            Pos2 topLeft = new Pos2(0, 0);
            Pos2 bottomRight = new Pos2(camera.width, camera.height);

            topLeft = camera.ScreenToWorld(topLeft);
            bottomRight = camera.ScreenToWorld(bottomRight);
            Rect worldSpace = new Rect(topLeft, bottomRight);

            var list = new List<Consprite>();
            list.AddRange(sprites.Where(x => x.WithinRectangle(worldSpace)));
            return list;
        }
    }
}
