using Gauss.Algorithm;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    /// <summary>
    /// TCPIPServer
    /// </summary>
    /// <seealso cref="ClientServer.Network" />
    public class TCPIPServer : Network
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="vectorX">The vector x.</param>
        protected delegate void VectorX(string vectorX);

        /// <summary>
        /// Occurs when [notify].
        /// </summary>
        protected static event VectorX Notify;

        /// <summary>
        /// The server
        /// </summary>
        private TcpListener _server;

        /// <summary>
        /// The client
        /// </summary>
        private TcpClient _client;

        /// <summary>
        /// The stream
        /// </summary>
        private NetworkStream _stream;

        /// <summary>
        /// Sets the listener.
        /// </summary>
        /// <returns></returns>
        protected override bool SetListener()
        {
            try
            {
                var localServerAddress = IPAddress.Parse(ServerIp);
                _server = new TcpListener(localServerAddress, Port);
                _server.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sends to client.
        /// </summary>
        /// <param name="linearSystem">The linear system.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public StringBuilder SendToClient(LinearSystem linearSystem)
        {
            var result = new StringBuilder();
            try
            {
                if (SetListener())
                {
                    Notify = delegate (string mes) { result.Append(mes); };
                    while (true)
                    {
                        _client = _server.AcceptTcpClient();
                        _stream = _client.GetStream();
                        var vectorX = new StringBuilder();
                        vectorX.Append(linearSystem.GaussSolve());
                        var data = Encoding.UTF8.GetBytes(vectorX.ToString());
                        _stream.Write(data, 0, data.Length);
                        Notify?.Invoke(vectorX.ToString());
                        Dispouse();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                _server?.Stop();
            }

            return result;
        }

        /// <summary>
        /// Dispouses this instance.
        /// </summary>
        protected override void Dispouse()
        {
            _stream.Close();
            _client.Close();
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{GetType().Name} Port: {Port}. ServerIp: {ServerIp}";

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != GetType())
                return false;
            TCPIPServer tcpipServer = (TCPIPServer)obj;
            return tcpipServer != null;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => _server.GetHashCode();
    }
}