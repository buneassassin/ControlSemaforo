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
                PortName = "COM10", // Cambia esto seg�n tu configuraci�n
                BaudRate = 9600,
                ReadTimeout = 500
            };
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();

            // Cargar configuraci�n de sem�foros desde archivo JSON
            LoadSemaforosConfig();
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

                outputMessage = $"Semaforo {sensorIndex + 1} - LED {color} est� {estado}.";
            }else if(sensorName == "SON"){
                string estado = valor == "1" ? "detectado" : "no detectado";
                outputMessage = $"Sensor ultras�nico {sensorIndex + 1} - {estado}.";
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

        private void LoadSemaforosConfig()
        {
            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                semaforosConfig = JsonConvert.DeserializeObject<List<SemaforoConfig>>(json);
                SendConfigToArduino();
                MessageBox.Show("Configuraci�n cargada.");
                UpdateDataGridView(); // Actualiza el DataGridView
            }
            else
            {
                semaforosConfig = new List<SemaforoConfig>();
            }
        }

        private void UpdateDataGridView()
        {
            dataGridViewSemaforos.Rows.Clear(); // Limpiar filas existentes
            foreach (var semaforo in semaforosConfig)
            {
                dataGridViewSemaforos.Rows.Add(semaforo.Id, semaforo.Pins[0], semaforo.Pins[1], semaforo.Pins[2]);
            }
        }

        private void SaveSemaforosConfig()
        {
            string json = JsonConvert.SerializeObject(semaforosConfig, Formatting.Indented);
            File.WriteAllText(configFilePath, json);
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
                // Env�a un comando espec�fico para iniciar el recorrido
                serialPort.WriteLine("ON"); // Modificar el comando seg�n lo que espera el Arduino
                MessageBox.Show("Recorrido iniciado.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                // Env�a un comando espec�fico para detener el recorrido
                serialPort.WriteLine("OFF"); // Modificar el comando seg�n lo que espera el Arduino
                MessageBox.Show("Recorrido detenido.");
                button2.Enabled = true;
            }
        }

        private void buttonConfigurar_Click_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                if (int.TryParse(Interaction.InputBox("Ingrese el n�mero de sem�foros:", "Configurar Sem�foros"), out int numSemaforos) && numSemaforos > 0)
                {
                    semaforosConfig.Clear();
                    for (int i = 0; i < numSemaforos; i++)
                    {
                        SemaforoConfig semaforo = new SemaforoConfig { Id = i, Pins = new int[3] };

                        for (int j = 0; j < 3; j++)
                        {
                            string color = (j == 0) ? "Rojo" : (j == 1) ? "Amarillo" : "Verde";
                            if (int.TryParse(Interaction.InputBox($"Ingrese el pin para el color {color} del sem�foro {i + 1}:", "Configurar Pines"), out int pin))
                            {
                                semaforo.Pins[j] = pin;
                            }
                            else
                            {
                                MessageBox.Show("Pin no v�lido. Configuraci�n cancelada.");
                                return;
                            }
                        }
                        semaforosConfig.Add(semaforo);
                    }
                    SaveSemaforosConfig();
                    SendConfigToArduino();
                    UpdateDataGridView(); // Actualiza el DataGridView
                    MessageBox.Show($"Configuraci�n de {numSemaforos} sem�foros guardada y enviada.");
                }
                else
                {
                    MessageBox.Show("N�mero de sem�foros no v�lido.");
                }
            }
        }
    }

    public class SemaforoConfig
    {
        public int Id { get; set; }
        public int[] Pins { get; set; }
    }
}
