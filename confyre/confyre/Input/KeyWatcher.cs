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
        static ConcurrentDictionary<ConsoleKey, bool> keyStates = new ConcurrentDictionary<ConsoleKey, bool>();

        static KeyWatcher() {
            watcher.Start();
        }

        static void Do() {
            while (true) {
                keyStates = new ConcurrentDictionary<ConsoleKey, bool>();
                ConsoleKey key = Console.ReadKey(true).Key;
                keyStates[key] = true;
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Checks if the specified key was pressed within the last 10ms.
        /// </summary>
        internal static bool KeyPressed(ConsoleKey key) => keyStates[key];
    }
}
