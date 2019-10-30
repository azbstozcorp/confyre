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

        internal void Render(Loop.App context) {
            // Need to write once for each colour, so
            // -- collect all textels of one colour into a collection for each
            // -- store to a stringbuilder for each
            // -- write out to console in relevant colour
            var megaSprite = Consprite.AssembleMegaSprite(AABBCull());
            var megaSpriteColours = new List<Consprite>();
            foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor))) megaSpriteColours.Add(megaSprite.WithColour(c));

            foreach (Consprite c in megaSpriteColours) {
                var screenInProgress = new StringBuilder(context.ScreenWidth * context.ScreenHeight);

                for (int i = 0; i < c.Width; i++) for (int j = 0; j < c.Height; j++) if (c.At(i, j).Display != ' ') screenInProgress[j * context.ScreenWidth + i] = c.At(i, j).Display;

                Console.BackgroundColor = c.At(0, 0).Colour;
                Console.SetCursorPosition(0, 0);
                Console.Write(screenInProgress.ToString());
            }
        }
    }
}
