using System;
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
                txtMessages.AppendText($"Received: {message}\n");
            }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.SendMessage(txtMessage.Text, int.Parse(txtDestPort.Text));
                txtMessages.AppendText($"Sent: {txtMessage.Text}\n");
                txtMessage.Clear();
            }
        }

        private void txtDestPort_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
