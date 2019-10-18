using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace confyre {
    class Program {
        static void Main(string[] args) {
            Input.KeyWatcher.KeyPressed += KeyWatcher_KeyPressed;
        }

        private static void KeyWatcher_KeyPressed(object sender, Input.KeyWatcher.KeyEventArgs e) {
            Console.WriteLine($"Pressed {e.key}");
        }
    }
}
