using System;

namespace GarbageCollectorMemoryLeak
{
    class Program
    {
        public class MainWindow
        {
            public event EventHandler<EventArgs> mainWindowEventHandler;

            private void buttonClick_OpenChildWindow(object sender, EventArgs e)
            {
                var childWindow = new ChildWindow(this);
                childWindow.Show();
            }
        }

        public class ChildWindow
        {
            private MainWindow _mainApplicationWindow;

            public ChildWindow(MainWindow mainApplicationWindow)
            {
                _mainApplicationWindow = mainApplicationWindow;
                _mainApplicationWindow.mainWindowEventHandler += HandleEventFromMainWindowInChildWindow;
            }

            private void HandleEventFromMainWindowInChildWindow(object sender, EventArgs e)
            {
            }

            internal void Show()
            {
                //opening a window
            }

            void OnWindowClosing()
            {
                _mainApplicationWindow.mainWindowEventHandler -= HandleEventFromMainWindowInChildWindow;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
