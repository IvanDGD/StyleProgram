using System;
using System.Diagnostics;
using System.Management;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace DllProjectHomeWork
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

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1
            //NativeMethods.MessageBox(IntPtr.Zero, "Ім'я: Дмитро", "Info", 0);
            //NativeMethods.MessageBox(IntPtr.Zero, "Пошта: dmytro123@gmail.com", "Info", 0);
            //NativeMethods.MessageBox(IntPtr.Zero, "Навчальний заклад: ITStep", "Info", 0);

            // #2
            //IntPtr hWnd = NativeMethods.FindWindow("Notepad", null);

            //if (hWnd == IntPtr.Zero)
            //{
            //    NativeMethods.MessageBox(IntPtr.Zero, "Window don't found", "Error", 0x00000010);
            //    return;
            //}

            //Console.WriteLine("Menu:");
            //Console.WriteLine("1 — Change window title");
            //Console.WriteLine("2 — Close window");

            //string choice = Console.ReadLine();

            //if (choice == "1")
            //{
            //    Console.Write("Enter new window title: ");

            //    string newTitle = Console.ReadLine();
            //    NativeMethods.SendMessage(hWnd, 0x000C, 0, newTitle);
            //    NativeMethods.MessageBox(IntPtr.Zero, "Title changed", "Info", 0x00000040);
            //}
            //else if (choice == "2")
            //{
            //    NativeMethods.SendMessage(hWnd, 0x0010, 0, null);
            //}
            //else
            //{
            //    NativeMethods.MessageBox(IntPtr.Zero, "Incorrect choice", "Error", 0x00000010);
            //}

            // #3
            //var beepList = new (int freq, int duration)[]
            //{
            //    (400, 300),
            //    (600, 200),
            //    (800, 500),
            //    (1000, 400),
            //    (1200, 250),
            //    (1500, 350)
            //};



            //foreach (var beep in beepList)
            //{
            //    Random rand = new Random();
            //    int index = rand.Next(beepList.Length);
            //    var selected = beepList[index];
            //    NativeMethods.Beep(selected.freq, selected.duration);
            //    Thread.Sleep(300);
            //}

            //NativeMethods.MessageBeep(0x00000040);
            //Thread.Sleep(500);
            //NativeMethods.MessageBeep(0x00000040);

            // #4
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainForm());
        }
    }
    internal class MainForm : Form
    {
        private TextBox textBox;
        private Button button;
        private System.Windows.Forms.Label label;


        public MainForm()
        {
            this.Text = "App";
            this.Width = 300;
            this.Height = 200;

            textBox = new TextBox() { Location = new System.Drawing.Point(20, 20), Width = 200 };
            button = new Button() { Location = new System.Drawing.Point(20, 60), Text = "Кнопка", Width = 100 };
            label = new System.Windows.Forms.Label() { Location = new System.Drawing.Point(20, 100), Text = "Метка" };

            this.Controls.Add(textBox);
            this.Controls.Add(button);
            this.Controls.Add(label);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0401)
            {
                this.button.BackColor = System.Drawing.Color.LightGreen;
                this.button.Text = "Изменено!";
                this.textBox.BackColor = System.Drawing.Color.LightYellow;
                this.label.ForeColor = System.Drawing.Color.Red;
            }
            base.WndProc(ref m);
        }
    }
}

