using System;
using System.Windows.Forms;
using VehicleSimulation;

namespace WinFormsApp1 // ← переконайся, що цей namespace збігається з MainForm.cs
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Включення сучасного рендерингу для WinForms (DPI, шрифти)
            ApplicationConfiguration.Initialize();

            // Запуск головної форми
            Application.Run(new MainForm());
        }
    }
}
