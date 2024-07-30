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

        public Client(string ip, int port) // Constructor que inicializa los sockets y puntos finales (local y remoto)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            localEndPoint = new IPEndPoint(ipAddress, port); // Crea un punto final local con la dirección IP y el puerto
            clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp); // Crea un socket cliente
            sendSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp); // Crea un socket para enviar datos
        }

        public void Connect() // Vincula el socket al punto final local, lo configura para escuchar y acepta conexiones entrantes.
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

        private void AcceptCallback(IAsyncResult ar) // Callback para aceptar conexiones entrantes, asigna el socket aceptado a un objeto StateObject y comienza a recibir datos.
        {
            try
            {
                Socket handler = clientSocket.EndAccept(ar);
                StateObject state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state); // Inicia a recibir datos
            }
            catch (Exception ex)
            {
                MessageBox.Show($"AcceptCallback Error: {ex.Message}");
            }
        }

        private void ReadCallback(IAsyncResult ar) // Callback para leer datos recibidos, convierte los datos a cadena y desencadena el evento MessageReceived, continúa recibiendo datos.
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState; // Obtiene el objeto StateObject del resultado asincrónico
                Socket handler = state.workSocket; // Obtiene el socket del objeto StateObject
                int bytesRead = handler.EndReceive(ar); // Finaliza la operación de recepción y obtiene el número de bytes leídos
                  
                if (bytesRead > 0)
                {
                    string content = Encoding.ASCII.GetString(state.buffer, 0, bytesRead); 
                    MessageReceived?.Invoke(content); // Invoca el evento MessageReceived con el contenido recibido
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state); // Continúa recibiendo datos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ReadCallback Error: {ex.Message}");
            }
        }

        public void SendMessage(string message, int port) // Envía un mensaje al punto final remoto especificado, conecta el socket si no está ya conectado.
        {
            try
            {
                if (!sendSocket.Connected) // Verifica si el socket de envío no está conectado y lo conecta si es necesario
                {
                    IPAddress ipAddress = IPAddress.Parse("127.0.0.1"); 
                    remoteEndPoint = new IPEndPoint(ipAddress, port); 
                    sendSocket.Connect(remoteEndPoint);
                }

                byte[] msg = Encoding.ASCII.GetBytes(message);
                sendSocket.Send(msg); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SendMessage Error: {ex.Message}");
            }
        }
    }

    public class StateObject // Clase para manejar el estado de las operaciones asíncronas
    {
        public Socket workSocket = null; // Declaro un campo público de tipo Socket llamado workSocket
        public const int BufferSize = 1024; // Declaro una constante pública para el tamaño del buffer
        public byte[] buffer = new byte[BufferSize]; // Declaro un arreglo de bytes para el buffer con el tamaño especificado
    }
}
