using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using confyre.Render;
using confyre.Render.Position;
using static confyre.Math.Trig;

namespace confyre.Loop {
    internal class App {
        internal event EventHandler<UpdateEventArgs> Update;

        internal int ScreenWidth { get; private set; }
        internal int ScreenHeight { get; private set; }
        internal List<Camera> cameras;

        int targetMSPerFrame;
        float timer;
        DateTime lastFrame;

        App() {
            cameras = new List<Camera>();
            timer = 0;
            lastFrame = DateTime.Now;

            Thread thread = new Thread(Do);
            thread.Start();
        }
        public App(int width, int height, int targetMSPerFrame = 20) : this() {
            ScreenWidth = width;
            ScreenHeight = height;
            this.targetMSPerFrame = targetMSPerFrame;
        }

        void Do() {
            while (true) {
                DateTime thisFrame = DateTime.Now;
                Update(null, new UpdateEventArgs(timer));
                timer = thisFrame.Millisecond - lastFrame.Millisecond;
            }
        }

        internal class UpdateEventArgs : EventArgs {
            float elapsed;
            public UpdateEventArgs(float e) {
                elapsed = e;
            }
        }
    }
}
