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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hola));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            buttonConfigurar_Click = new Button();
            dataGridViewSemaforos = new DataGridView();
            semaforo = new DataGridViewTextBoxColumn();
            pin1 = new DataGridViewTextBoxColumn();
            pin2 = new DataGridViewTextBoxColumn();
            pin3 = new DataGridViewTextBoxColumn();
            Acciones = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSemaforos).BeginInit();
            Acciones.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.Location = new Point(337, 126);
            button1.Name = "button1";
            button1.Size = new Size(160, 51);
            button1.TabIndex = 0;
            button1.Text = "Elegir";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Lime;
            button2.Location = new Point(337, 35);
            button2.Name = "button2";
            button2.Size = new Size(160, 51);
            button2.TabIndex = 1;
            button2.Text = "Preder";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Location = new Point(337, 209);
            button3.Name = "button3";
            button3.Size = new Size(160, 51);
            button3.TabIndex = 2;
            button3.Text = "Apagar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(23, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(224, 225);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Info;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(648, 69);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(414, 424);
            listBox1.TabIndex = 4;
            // 
            // buttonConfigurar_Click
            // 
            buttonConfigurar_Click.BackColor = Color.CornflowerBlue;
            buttonConfigurar_Click.Location = new Point(782, 12);
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
            dataGridViewSemaforos.Location = new Point(59, 368);
            dataGridViewSemaforos.Name = "dataGridViewSemaforos";
            dataGridViewSemaforos.ReadOnly = true;
            dataGridViewSemaforos.RowHeadersWidth = 51;
            dataGridViewSemaforos.Size = new Size(551, 125);
            dataGridViewSemaforos.TabIndex = 6;
            dataGridViewSemaforos.CellContentClick += dataGridView1_CellContentClick;
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
            Acciones.Controls.Add(pictureBox1);
            Acciones.Controls.Add(button3);
            Acciones.Controls.Add(button2);
            Acciones.Controls.Add(button1);
            Acciones.Location = new Point(59, 69);
            Acciones.Name = "Acciones";
            Acciones.Size = new Size(551, 270);
            Acciones.TabIndex = 7;
            Acciones.TabStop = false;
            Acciones.Text = "Acciones";
            Acciones.Enter += groupBox1_Enter;
            // 
            // Hola
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1098, 554);
            ControlBox = false;
            Controls.Add(Acciones);
            Controls.Add(dataGridViewSemaforos);
            Controls.Add(buttonConfigurar_Click);
            Controls.Add(listBox1);
            Name = "Hola";
            Text = "Form1";
            Load += Hola_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSemaforos).EndInit();
            Acciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private Button buttonConfigurar_Click;
        private DataGridView dataGridViewSemaforos;
        private DataGridViewTextBoxColumn semaforo;
        private DataGridViewTextBoxColumn pin1;
        private DataGridViewTextBoxColumn pin2;
        private DataGridViewTextBoxColumn pin3;
        private GroupBox Acciones;
    }
}
