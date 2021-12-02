using Gauss.MatrixMethod;
using System;
using System.Globalization;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    /// <summary>
    /// TCPClient
    /// </summary>
    /// <seealso cref="ClientServer.Network" />
    public class TCPClient : Network
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="mes">The mes.</param>
        private delegate void StartData(string mes);

        /// <summary>
        ///
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private delegate string Data(string message);

        /// <summary>
        /// Occurs when [notify].
        /// </summary>
        private static event Data Notify;

        /// <summary>
        /// The client
        /// </summary>
        private readonly TcpClient _client;

        /// <summary>
        /// The stream
        /// </summary>
        private NetworkStream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="TCPClient"/> class.
        /// </summary>
        public TCPClient() => _client = new TcpClient();

        /// <summary>
        /// Sets the listener.
        /// </summary>
        /// <returns></returns>
        protected override bool SetListener()
        {
            try
            {
                _client.Connect(ServerIp, Port);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sends to server.
        /// </summary>
        /// <param name="inputMatrix">The input matrix.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// SocketException: {0}
        /// or
        /// Exception: {0}
        /// </exception>
        public StringBuilder SendToServer(Matrix inputMatrix)
        {
            var result = new StringBuilder();
            try
            {
                if (SetListener())
                {
                    StartData startData = delegate (string mes) { result.Append("Add:\n" + mes); };
                    _stream = _client.GetStream();
                    var response = new StringBuilder();
                    for (var i = 0; i < inputMatrix.RowCount; i++)
                    {
                        for (var j = 0; j < inputMatrix.ColumnCount - 1; j++)
                        {
                            response.Append(inputMatrix[i, j].ToString(CultureInfo.InvariantCulture) + " ");
                        }

                        response.AppendLine();
                    }

                    for (var i = 0; i < inputMatrix.LastColumn().Length; i++)
                    {
                        response.AppendLine(inputMatrix.LastColumn()[i].ToString(CultureInfo.InvariantCulture) + " ");
                    }

                    Notify += (string resultString) => response.ToString();
                    var data = Encoding.UTF8.GetBytes(response.ToString());
                    _stream.Write(data, 0, data.Length);
                    startData(Notify?.Invoke(response.ToString()));
                    Dispouse();
                }
            }
            catch (SocketException e)
            {
                throw new Exception("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                throw new Exception("Exception: {0}", e);
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
            TCPClient tcpClient = (TCPClient)obj;
            return tcpClient != null && _stream == tcpClient._stream && _client == tcpClient._client;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => _client.GetHashCode() + _stream.GetHashCode();
    }
}