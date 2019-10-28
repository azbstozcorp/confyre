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

        internal char GetTopChar(List<Consprite> sprites, int index) {
            return 'z';
        }

        internal void Render(Loop.App context) {
            var screenInProgress = new StringBuilder(context.ScreenWidth*context.ScreenHeight);
            var toRender = AABBCull();

            for(int i = 0; i < screenInProgress.Length; i++) {
                screenInProgress[i] = GetTopChar(toRender, i);
            }

            Console.Write(screenInProgress.ToString());
        }
    }
}
