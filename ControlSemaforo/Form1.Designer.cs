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
            button2 = new Button();
            button3 = new Button();
            historial = new ListBox();
            buttonConfigurar_Click = new Button();
            dataGridViewSemaforos = new DataGridView();
            semaforo = new DataGridViewTextBoxColumn();
            pin1 = new DataGridViewTextBoxColumn();
            pin2 = new DataGridViewTextBoxColumn();
            pin3 = new DataGridViewTextBoxColumn();
            Acciones = new GroupBox();
            valorActual = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSemaforos).BeginInit();
            Acciones.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Location = new Point(27, 35);
            button2.Name = "button2";
            button2.Size = new Size(160, 51);
            button2.TabIndex = 1;
            button2.Text = "Encender";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Location = new Point(208, 35);
            button3.Name = "button3";
            button3.Size = new Size(160, 51);
            button3.TabIndex = 2;
            button3.Text = "Apagar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // historial
            // 
            historial.BackColor = SystemColors.Info;
            historial.FormattingEnabled = true;
            historial.Location = new Point(896, 69);
            historial.Name = "historial";
            historial.Size = new Size(414, 524);
            historial.TabIndex = 4;
            // 
            // buttonConfigurar_Click
            // 
            buttonConfigurar_Click.BackColor = Color.Transparent;
            buttonConfigurar_Click.Location = new Point(27, 107);
            buttonConfigurar_Click.Name = "buttonConfigurar_Click";
            buttonConfigurar_Click.Size = new Size(160, 51);
            buttonConfigurar_Click.TabIndex = 5;
            buttonConfigurar_Click.Text = "Configurar";
            buttonConfigurar_Click.UseVisualStyleBackColor = false;
            buttonConfigurar_Click.Click += buttonConfigurar_Click_Click;
            // 
            // dataGridViewSemaforos
            // 
            dataGridViewSemaforos.AllowUserToDeleteRows = false;
            dataGridViewSemaforos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSemaforos.Columns.AddRange(new DataGridViewColumn[] { semaforo, pin1, pin2, pin3 });
            dataGridViewSemaforos.Location = new Point(59, 277);
            dataGridViewSemaforos.Name = "dataGridViewSemaforos";
            dataGridViewSemaforos.ReadOnly = true;
            dataGridViewSemaforos.RowHeadersWidth = 51;
            dataGridViewSemaforos.Size = new Size(554, 307);
            dataGridViewSemaforos.TabIndex = 6;
            // 
            // semaforo
            // 
            semaforo.HeaderText = "Semaforo";
            semaforo.MinimumWidth = 6;
            semaforo.Name = "semaforo";
            semaforo.ReadOnly = true;
            semaforo.Width = 125;
            // 
            // pin1
            // 
            pin1.HeaderText = "Pin R";
            pin1.MinimumWidth = 6;
            pin1.Name = "pin1";
            pin1.ReadOnly = true;
            pin1.Width = 125;
            // 
            // pin2
            // 
            pin2.HeaderText = "Pin A";
            pin2.MinimumWidth = 6;
            pin2.Name = "pin2";
            pin2.ReadOnly = true;
            pin2.Width = 125;
            // 
            // pin3
            // 
            pin3.HeaderText = "Pin V";
            pin3.MinimumWidth = 6;
            pin3.Name = "pin3";
            pin3.ReadOnly = true;
            pin3.Width = 125;
            // 
            // Acciones
            // 
            Acciones.Controls.Add(button3);
            Acciones.Controls.Add(button2);
            Acciones.Controls.Add(buttonConfigurar_Click);
            Acciones.Location = new Point(59, 69);
            Acciones.Name = "Acciones";
            Acciones.Size = new Size(395, 177);
            Acciones.TabIndex = 7;
            Acciones.TabStop = false;
            Acciones.Text = "Acciones";
            // 
            // valorActual
            // 
            valorActual.AutoSize = true;
            valorActual.Location = new Point(39, 87);
            valorActual.Name = "valorActual";
            valorActual.Size = new Size(50, 20);
            valorActual.TabIndex = 8;
            valorActual.Text = "label1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(valorActual);
            groupBox1.Location = new Point(500, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(379, 177);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Valor Actual";
            // 
            // Hola
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1349, 796);
            ControlBox = false;
            Controls.Add(groupBox1);
            Controls.Add(Acciones);
            Controls.Add(dataGridViewSemaforos);
            Controls.Add(historial);
            Name = "Hola";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSemaforos).EndInit();
            Acciones.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Button button3;
        private ListBox historial;
        private Button buttonConfigurar_Click;
        private DataGridView dataGridViewSemaforos;
        private DataGridViewTextBoxColumn semaforo;
        private DataGridViewTextBoxColumn pin1;
        private DataGridViewTextBoxColumn pin2;
        private DataGridViewTextBoxColumn pin3;
        private GroupBox Acciones;
        private Label valorActual;
        private GroupBox groupBox1;
    }
}
