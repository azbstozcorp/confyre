using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace confyre.Input {
    internal static class KeyWatcher {
        static Thread watcher = new Thread(Do);
        internal static event EventHandler<KeyEventArgs> KeyPressed;


        static KeyWatcher() {
            watcher.Start();
        }

        static void Do() {
            while (true) {
                if (Console.KeyAvailable) KeyPressed(null, new KeyEventArgs(Console.ReadKey(true).Key));
            }
        }

        internal class KeyEventArgs : EventArgs {
            internal ConsoleKey key;
            public KeyEventArgs(ConsoleKey key) { this.key = key; }
        }
    }
}
