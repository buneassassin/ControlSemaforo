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
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSemaforos).BeginInit();
            Acciones.SuspendLayout();
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
            historial.Location = new Point(640, 69);
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
            dataGridViewSemaforos.Location = new Point(59, 271);
            dataGridViewSemaforos.Name = "dataGridViewSemaforos";
            dataGridViewSemaforos.ReadOnly = true;
            dataGridViewSemaforos.RowHeadersWidth = 51;
            dataGridViewSemaforos.Size = new Size(554, 318);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(528, 150);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // Hola
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1067, 605);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(Acciones);
            Controls.Add(dataGridViewSemaforos);
            Controls.Add(historial);
            Name = "Hola";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSemaforos).EndInit();
            Acciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private Label label1;
    }
}
