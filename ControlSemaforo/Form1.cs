using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace ControlSemaforo
{
    public partial class Hola : Form
    {
        SerialPort serialPort;
        List<SemaforoConfig> semaforosConfig;
        const string configFilePath = "semaforosConfig.json";

        public Hola()
        {
            InitializeComponent();

            serialPort = new SerialPort
            {
                PortName = "COM11", // Cambia esto según tu configuración
                BaudRate = 9600,
                ReadTimeout = 500
            };
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string message = serialPort.ReadLine();
                string[] partes =  message.Split(':');

                string sensorName = partes[0];
                string sensorNum = partes[1];
                string valor = partes[2].Trim();


                UpdateListBox(sensorName, sensorNum, valor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer del puerto: {ex.Message}");
            }
        }

        private void UpdateListBox(string sensorName, string sensorNum, string valor)
        {
            string outputMessage = "";

            int sensorIndex = int.Parse(sensorNum);

            if (sensorName.StartsWith("LE"))
            {

                string color = sensorName switch
                {
                    "LER" => "Rojo",
                    "LEV" => "Verde",
                    "LEA" => "Amarillo",
                    _ => "Desconocido"
                };

                string estado = valor == "1" ? "encendido" : "apagado";

                outputMessage = $"Semaforo {sensorIndex + 1} - LED {color} está {estado}.";
            }else if(sensorName == "SON"){
                string estado = valor == "1" ? "detectado" : "no detectado";
                outputMessage = $"Sensor ultrasónico {sensorIndex + 1} - {estado}.";
            }

            if (historial.InvokeRequired)
            {
                historial.BeginInvoke((MethodInvoker)delegate
                {
                    valorActual.Text = outputMessage;
                    AddItemToListBox(outputMessage);
                });
            }
            else
            {
                valorActual.Text = outputMessage;
                AddItemToListBox(outputMessage);
            }
        }

        private void AddItemToListBox(string message)
        {
            historial.Items.Add(message);
            historial.Items.Add("---------------------------------------------------------------");

            // Desplaza automaticamente el final
            historial.TopIndex = historial.Items.Count - 1;
        }

     

        private void SendConfigToArduino()
        {
            if (serialPort.IsOpen)
            {
                string jsonConfig = JsonConvert.SerializeObject(semaforosConfig);
                serialPort.WriteLine("CONFIG: " + jsonConfig);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                // Envía un comando específico para iniciar el recorrido
                serialPort.WriteLine("ON"); // Modificar el comando según lo que espera el Arduino
                MessageBox.Show("Recorrido iniciado.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                // Envía un comando específico para detener el recorrido
                serialPort.WriteLine("OFF"); // Modificar el comando según lo que espera el Arduino
                MessageBox.Show("Recorrido detenido.");
                button2.Enabled = true;
            }
        }

    }

    public class SemaforoConfig
    {
        public int Id { get; set; }
        public int[] Pins { get; set; }
    }
}
