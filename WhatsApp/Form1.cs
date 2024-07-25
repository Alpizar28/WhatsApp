using System;
using System.Drawing; // Añadir este using para usar los colores
using System.Windows.Forms;

namespace WhatsApp
{
    public partial class Form1 : Form
    {
        private Client client;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new Client("127.0.0.1", int.Parse(txtPort.Text));
            client.MessageReceived += Client_MessageReceived;
            client.Connect();
        }

        private void Client_MessageReceived(string message)
        {
            Invoke((Action)(() =>
            {
                AppendText(txtMessages, $"Received: {message}{Environment.NewLine}", Color.Blue);
            }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.SendMessage(txtMessage.Text, int.Parse(txtDestPort.Text));
                AppendText(txtMessages, $"Sent: {txtMessage.Text}{Environment.NewLine}", Color.Green);
                txtMessage.Clear();
            }
        }

        private void txtDestPort_TextChanged(object sender, EventArgs e)
        {
        }

        private void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
