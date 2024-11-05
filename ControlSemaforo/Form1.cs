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
                PortName = "COM10", // Cambia esto según tu configuración
                BaudRate = 9600,
                ReadTimeout = 500
            };
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();

            // Cargar configuración de semáforos desde archivo JSON
            LoadSemaforosConfig();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string message = serialPort.ReadLine();
                UpdateListBox(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer del puerto: {ex.Message}");
            }
        }

        private void UpdateListBox(string message)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.BeginInvoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add(message);
                    listBox1.Items.Add("---------------------------------");
                });
            }
            else
            {
                listBox1.Items.Add(message);
                listBox1.Items.Add("---------------------------------");
            }
        }

        private void LoadSemaforosConfig()
        {
            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                semaforosConfig = JsonConvert.DeserializeObject<List<SemaforoConfig>>(json);
                SendConfigToArduino();
                MessageBox.Show("Configuración cargada.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                int semaforo;
                string color;

                if (int.TryParse(Interaction.InputBox("Ingrese el número de semáforo:", "Encender LED"), out semaforo) &&
                    semaforo >= 0 && semaforo < semaforosConfig.Count)
                {
                    color = Interaction.InputBox("Ingrese el color (R, A, V):", "Encender LED").ToUpper();
                    if (color == "R" || color == "A" || color == "V")
                    {
                        serialPort.WriteLine(semaforo.ToString() + color);
                        MessageBox.Show($"LED {color} del semáforo {semaforo} encendido.");
                        button2.Enabled = false;
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
                // Envía un comando específico para iniciar el recorrido
                serialPort.WriteLine("ON"); // Modificar el comando según lo que espera el Arduino
                MessageBox.Show("Recorrido iniciado.");
                button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                // Envía un comando específico para detener el recorrido
                serialPort.WriteLine("OFF"); // Modificar el comando según lo que espera el Arduino
                MessageBox.Show("Recorrido detenido.");
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void buttonConfigurar_Click_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                if (int.TryParse(Interaction.InputBox("Ingrese el número de semáforos:", "Configurar Semáforos"), out int numSemaforos) && numSemaforos > 0)
                {
                    semaforosConfig.Clear();
                    for (int i = 0; i < numSemaforos; i++)
                    {
                        SemaforoConfig semaforo = new SemaforoConfig { Id = i, Pins = new int[3] };

                        for (int j = 0; j < 3; j++)
                        {
                            string color = (j == 0) ? "Rojo" : (j == 1) ? "Amarillo" : "Verde";
                            if (int.TryParse(Interaction.InputBox($"Ingrese el pin para el color {color} del semáforo {i + 1}:", "Configurar Pines"), out int pin))
                            {
                                semaforo.Pins[j] = pin;
                            }
                            else
                            {
                                MessageBox.Show("Pin no válido. Configuración cancelada.");
                                return;
                            }
                        }
                        semaforosConfig.Add(semaforo);
                    }
                    SaveSemaforosConfig();
                    SendConfigToArduino();
                    UpdateDataGridView(); // Actualiza el DataGridView
                    MessageBox.Show($"Configuración de {numSemaforos} semáforos guardada y enviada.");
                }
                else
                {
                    MessageBox.Show("Número de semáforos no válido.");
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
