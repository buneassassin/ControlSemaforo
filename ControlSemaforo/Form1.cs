using Newtonsoft.Json;
using System.IO.Ports;


namespace ControlSemaforo
{
    public partial class Hola : Form
    {
        SerialPort serialPort;
        const string configFilePath = "datos.json";
        private Root data;

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
                string[] partes = message.Split(':');

                if (partes.Length < 3) return;

                string sensorName = partes[0];
                string sensorNum = partes[1];
                string valor = partes[2].Trim();

                UpdateDataGridView(sensorName, sensorNum, valor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer del puerto: {ex.Message}");
            }
        }

        private void UpdateDataGridView(string sensorName, string sensorNum, string valor)
        {
            string descripcion = "Desconocido";
            string estado = valor == "1" ? "Encendido/Detectado" : "Apagado/Nodetectado";
            string unidad = "";

            if (int.TryParse(sensorNum, out int sensorNumInt))
            {
                sensorNumInt += 1;
            }

            // Verificar si el sensor existe en los datos cargados
            if (data.Sensores.ContainsKey(sensorName))
            {
                var sensorInfo = data.Sensores[sensorName];
                descripcion = sensorInfo.Descripcion;
                unidad = sensorInfo.Unidad;
            }


            string valorCantidad = $"{valor} {unidad}";

            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.BeginInvoke((MethodInvoker)delegate
                {
                    valorActual.Text = $"{descripcion} {sensorNum}: {valorCantidad}";
                    dataGridView1.Rows.Add(new object[] { descripcion, sensorNumInt, valorCantidad });

                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                });
            }
            else
            {
                valorActual.Text = $"{descripcion} {sensorNum}: {valorCantidad}";
                dataGridView1.Rows.Add(new object[] { descripcion, sensorNumInt, valorCantidad });

                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            }

        }

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

                // Deserializar el JSON en la clase Root
                data = JsonConvert.DeserializeObject<Root>(json);

                if (data == null || data.Sensores == null)
                {
                    MessageBox.Show("Error al deserializar el JSON o no se encontró la información de sensores.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}");
            }
        }
    }
}
