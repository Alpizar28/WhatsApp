using System; 
using System.Drawing; 
using System.Windows.Forms; 

namespace WhatsApp 
{
    public partial class Form1 : Form // Define una clase parcial llamada Form1 que hereda de Form
    {
        private Client client; 

        public Form1() // Constructor de la clase Form1
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e) // Crea y conecta un cliente al hacer clic en el botón "Connect"
        {
            client = new Client("127.0.0.1", int.Parse(txtPort.Text)); // Crea una instancia del cliente usando la IP local y el puerto del cuadro de texto
            client.MessageReceived += Client_MessageReceived; // Suscribe el método Client_MessageReceived al evento MessageReceived del cliente
            client.Connect();
        }

        private void Client_MessageReceived(string message) //Muestra el mensaje recibido en el RichTextBox con color azul.
        {
            Invoke((Action)(() => // Usa Invoke para actualizar el UI desde un hilo diferente
            {
                AppendText(txtMessages, $"Received: {message}{Environment.NewLine}", Color.Blue); 
            }));
        }

        private void btnSend_Click(object sender, EventArgs e) // Envía el mensaje escrito al puerto de destino especificado, y lo enseña en el RichTextBox con color verde.
        {
            if (client != null) // Verifica que el cliente no sea nulo
            {
                client.SendMessage(txtMessage.Text, int.Parse(txtDestPort.Text));
                AppendText(txtMessages, $"Sent: {txtMessage.Text}{Environment.NewLine}", Color.Green);
                txtMessage.Clear(); 
            }
        }

        private void txtDestPort_TextChanged(object sender, EventArgs e)
        {
        }

        private void AppendText(RichTextBox box, string text, Color color) // Método para añadir texto a un RichTextBox con un color específico
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color; 
            box.AppendText(text);
            box.SelectionColor = box.ForeColor; // Restablece el color de la selección al color predeterminado
        }
    }
}
