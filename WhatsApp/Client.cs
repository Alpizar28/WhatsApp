using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WhatsApp
{
    public class Client
    {
        private Socket clientSocket;
        private IPEndPoint localEndPoint;
        private IPEndPoint remoteEndPoint;
        private Socket sendSocket;

        public event Action<string> MessageReceived = delegate { };

        public Client(string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            localEndPoint = new IPEndPoint(ipAddress, port);
            clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sendSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect()
        {
            try
            {
                clientSocket.Bind(localEndPoint);
                clientSocket.Listen(10);
                clientSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = clientSocket.EndAccept(ar);
                StateObject state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"AcceptCallback Error: {ex.Message}");
            }
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    string content = Encoding.ASCII.GetString(state.buffer, 0, bytesRead);
                    MessageReceived?.Invoke(content);
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ReadCallback Error: {ex.Message}");
            }
        }

        public void SendMessage(string message, int port)
        {
            try
            {
                if (!sendSocket.Connected)
                {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                remoteEndPoint = new IPEndPoint(ipAddress, port);
                Socket sendSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                sendSocket.Connect(remoteEndPoint);
                byte[] msg = Encoding.ASCII.GetBytes(message);
                sendSocket.Send(msg);
                sendSocket.Shutdown(SocketShutdown.Both);
                sendSocket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SendMessage Error: {ex.Message}");
            }
        }
    }

    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
    }
}
