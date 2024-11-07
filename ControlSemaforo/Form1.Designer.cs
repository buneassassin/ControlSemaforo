namespace ControlSemaforo
{
    partial class Hola
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            valorActual = new Label();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            Sensor = new DataGridViewTextBoxColumn();
            NumeroSensor = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // valorActual
            // 
            valorActual.AutoSize = true;
            valorActual.Location = new Point(36, 56);
            valorActual.Name = "valorActual";
            valorActual.Size = new Size(50, 20);
            valorActual.TabIndex = 8;
            valorActual.Text = "label1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(valorActual);
            groupBox1.Location = new Point(27, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(313, 115);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Valor Actual";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Sensor, NumeroSensor, Valor });
            dataGridView1.Location = new Point(364, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(429, 188);
            dataGridView1.TabIndex = 10;
            // 
            // Sensor
            // 
            Sensor.HeaderText = "Sensor";
            Sensor.MinimumWidth = 6;
            Sensor.Name = "Sensor";
            Sensor.Width = 125;
            // 
            // NumeroSensor
            // 
            NumeroSensor.HeaderText = "Número de Sensor";
            NumeroSensor.MinimumWidth = 6;
            NumeroSensor.Name = "NumeroSensor";
            NumeroSensor.Width = 125;
            // 
            // Valor
            // 
            Valor.HeaderText = "Valor";
            Valor.MinimumWidth = 6;
            Valor.Name = "Valor";
            Valor.Width = 125;
            // 
            // Hola
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(868, 566);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Name = "Hola";
            Text = "Form1";
            Load += Hola_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label valorActual;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Sensor;
        private DataGridViewTextBoxColumn NumeroSensor;
        private DataGridViewTextBoxColumn Valor;
    }
}
