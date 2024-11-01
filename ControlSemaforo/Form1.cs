using Microsoft.VisualBasic;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace ControlSemaforo
{
    public partial class Hola : Form
    {
        SerialPort serialPort;

        public Hola()
        {
            InitializeComponent();

            serialPort = new SerialPort();
            serialPort.PortName = "COM16";
            serialPort.BaudRate = 9600;
            serialPort.ReadTimeout = 500;
            serialPort.Open();
        }


 



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                int semaforo;
                string color;

                // Solicitar el número de semáforo
                if (int.TryParse(Interaction.InputBox("Ingrese el número de semáforo:", "Encender LED"), out semaforo) && semaforo >= 0 && semaforo < 2)
                {
                    // Solicitar el color de luz
                    color = Interaction.InputBox("Ingrese el color (R, A, V):", "Encender LED").ToUpper();
                    if (color == "R" || color == "A" || color == "V")
                    {
                        serialPort.Write(semaforo.ToString() + color);
                        MessageBox.Show($"LED {color} del semáforo {semaforo} encendido.");
                    }
                    else
                    {
                        MessageBox.Show("Color no válido. Usa R, A, o V.");
                    }
                }
                else
                {
                    MessageBox.Show("Número de semáforo no válido.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write("R"); // Inicia el recorrido
                MessageBox.Show("Recorrido iniciado.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {+9
+            if (serialPort.IsOpen)
            {
                serialPort.Write("S"); // Detiene el recorrido
                MessageBox.Show("Recorrido detenido.");
            }
        }
    }
}



