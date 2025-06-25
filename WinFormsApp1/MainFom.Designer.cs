namespace VehicleSimulation
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnTrucks;
        private Button btnCars;
        private Button btnBoth;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnTrucks = new System.Windows.Forms.Button();
            this.btnCars = new System.Windows.Forms.Button();
            this.btnBoth = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btnTrucks
            // 
            this.btnTrucks.Location = new System.Drawing.Point(50, 30);
            this.btnTrucks.Name = "btnTrucks";
            this.btnTrucks.Size = new System.Drawing.Size(200, 40);
            this.btnTrucks.TabIndex = 0;
            this.btnTrucks.Text = "1. Тільки вантажні";
            this.btnTrucks.UseVisualStyleBackColor = true;
            this.btnTrucks.Click += new System.EventHandler(this.btnTrucks_Click);

            // 
            // btnCars
            // 
            this.btnCars.Location = new System.Drawing.Point(50, 80);
            this.btnCars.Name = "btnCars";
            this.btnCars.Size = new System.Drawing.Size(200, 40);
            this.btnCars.TabIndex = 1;
            this.btnCars.Text = "2. Тільки легкові";
            this.btnCars.UseVisualStyleBackColor = true;
            this.btnCars.Click += new System.EventHandler(this.btnCars_Click);

            // 
            // btnBoth
            // 
            this.btnBoth.Location = new System.Drawing.Point(50, 130);
            this.btnBoth.Name = "btnBoth";
            this.btnBoth.Size = new System.Drawing.Size(200, 40);
            this.btnBoth.TabIndex = 2;
            this.btnBoth.Text = "3. Обидва типи";
            this.btnBoth.UseVisualStyleBackColor = true;
            this.btnBoth.Click += new System.EventHandler(this.btnBoth_Click);

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnTrucks);
            this.Controls.Add(this.btnCars);
            this.Controls.Add(this.btnBoth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "MainForm";
            this.Text = "Меню симуляції";
            this.ResumeLayout(false);
        }
    }
}
