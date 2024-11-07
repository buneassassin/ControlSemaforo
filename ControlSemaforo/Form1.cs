using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;


namespace ControlSemaforo
{
    public partial class Hola : Form
    {
        SerialPort serialPort;
        const string configFilePath = "datos.json";

        public Hola()
        {
            InitializeComponent();

            serialPort = new SerialPort
            {
                PortName = "COM6", // Cambia esto según tu configuración
                BaudRate = 9600,
                ReadTimeout = 500
            };
            serialPort.DataReceived += SerialPort_DataReceived;
            //serialPort.Open();

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string message = serialPort.ReadLine();
                string[] partes = message.Split(':');

                if (partes.Length < 3) return;

                string sensorName = partes[0];
                string sensorNum = partes[1];
                string valor = partes[2].Trim();

                sensorNum = "SON";
                sensorName = "1";
                valor = "0";

                UpdateDataGridView(sensorName, sensorNum, valor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer del puerto: {ex.Message}");
            }
        }

        private void UpdateDataGridView(string sensorName, string sensorNum, string valor)
        {
            string outputMessage = "";

            int sensorIndex = int.Parse(sensorNum);

            string descripcion = data.ContainsKey(sensorName) ? data[sensorName].Descripcion : "Desconocido";
            string estado = valor == "1" ? "Encendido/Detectado" : "Apagado/Nodetectado";

            if (dataGridView1.InvokeRequired)
            {

                dataGridView1.BeginInvoke((MethodInvoker)delegate { 
                    valorActual.Text = $"{descripcion} {sensorNum}: {valor}";
                });

                dataGridView1.Rows.Add(new object[] {descripcion, sensorNum, valor });

            }
            else
            {
                valorActual.Text = $"{descripcion} {sensorNum}: {valor}";
                dataGridView1.Rows.Add(new object[] { descripcion, sensorNum, valor });
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
            }
        }

        private Dictionary<string, SensorInfo> data;

private void Hola_Load(object sender, EventArgs e)
{
    try
    {
        if (!File.Exists(configFilePath))
        {
            MessageBox.Show("El archivo JSON no existe.");
            return;
        }

        string json = File.ReadAllText(configFilePath);

        if (string.IsNullOrEmpty(json))
        {
            MessageBox.Show("El archivo JSON está vacío.");
            return;
        }

        // Deserializar el JSON a un diccionario de tipo <string, SensorInfo>
        data = JsonConvert.DeserializeObject<Dictionary<string, SensorInfo>>(json);

        if (data == null)
        {
            MessageBox.Show("Error al deserializar el JSON.");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Se produjo un error: {ex.Message}");
    }
}
    }
}
