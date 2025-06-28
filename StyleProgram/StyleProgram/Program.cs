using System.Runtime.InteropServices;

namespace StyleProgram
{
    internal class Program
    {
        internal static class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("kernel32.dll")]
            public static extern bool Beep(int freq, int duration);

            [DllImport("user32.dll")]
            public static extern bool MessageBeep(uint uType);

            [DllImport("user32.dll")]
            public static extern bool SetWindowText(IntPtr hWnd, string lpString);
        }
        static void Main(string[] args)
        {
            RunConsoleApp();
        }
        static void RunConsoleApp()
        {
            Console.WriteLine("Введите заголовок окна для поиска:");
            string windowTitle = Console.ReadLine();

            IntPtr hWnd = NativeMethods.FindWindow(null, windowTitle);

            if (hWnd == IntPtr.Zero)
            {
                Console.WriteLine("Окно с таким заголовком не найдено.");
                return;
            }

            Console.WriteLine("Окно найдено. Выберите действие:");
            Console.WriteLine("1 — Изменить заголовок");
            Console.WriteLine("2 — Закрыть окно");
            Console.WriteLine("3 — Изменить стиль элементов управления");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Введите новый заголовок: ");
                string newTitle = Console.ReadLine();

                NativeMethods.SetWindowText(hWnd, newTitle);
            }
            else if (choice == "2")
            {
                NativeMethods.SendMessage(hWnd, 0x0010, IntPtr.Zero, IntPtr.Zero);
            }
            else if (choice == "3")
            {
                NativeMethods.SendMessage(hWnd, 0x0401, IntPtr.Zero, IntPtr.Zero);
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }
        }
    }
}
