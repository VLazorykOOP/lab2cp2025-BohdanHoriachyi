using System;
using System.Windows.Forms;

namespace VehicleSimulation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenSimulation(int mode)
        {
            SimulationForm simForm = new SimulationForm(mode);
            simForm.Show();
        }

        private void btnTrucks_Click(object sender, EventArgs e)
        {
            OpenSimulation(1);
        }

        private void btnCars_Click(object sender, EventArgs e)
        {
            OpenSimulation(2);
        }

        private void btnBoth_Click(object sender, EventArgs e)
        {
            OpenSimulation(3);
        }
    }
}
