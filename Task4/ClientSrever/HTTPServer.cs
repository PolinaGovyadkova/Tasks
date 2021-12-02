using Gauss.Algorithm;
using System.IO;
using System.Net;
using System.Text;

namespace ClientServer
{
    /// <summary>
    /// HTTPServer
    /// </summary>
    /// <seealso cref="ClientServer.TCPIPServer" />
    public class HTTPServer : TCPIPServer
    {
        /// <summary>
        /// The output straem
        /// </summary>
        private Stream _output;

        /// <summary>
        /// The listener
        /// </summary>
        private readonly HttpListener _listener;

        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString = $"http://localhost:{Port}/connection/";

        /// <summary>
        /// Initializes a new instance of the <see cref="HTTPServer"/> class.
        /// </summary>
        public HTTPServer() => _listener = new HttpListener();

        /// <summary>
        /// Sets the listener.
        /// </summary>
        /// <returns></returns>
        protected override bool SetListener()
        {
            try
            {
                _listener.Prefixes.Add(_connectionString);
                _listener.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sends meassage to client.
        /// </summary>
        /// <param name="linearSystem">The linear system.</param>
        public new void SendToClient(LinearSystem linearSystem)
        {
            if (!SetListener()) return;
            var context = _listener.GetContext();
            var response = context.Response;
            var responseStr = $"<html><head><meta charset='utf8'></head><body>{linearSystem.GaussSolve()}</body></html>";
            var buffer = Encoding.UTF8.GetBytes(responseStr);
            response.ContentLength64 = buffer.Length;
            _output = response.OutputStream;
            _output.Write(buffer, 0, buffer.Length);
            Dispouse();
        }

        /// <summary>
        /// Dispouses this instance.
        /// </summary>
        protected override void Dispouse()
        {
            _output.Close();
            _listener.Stop();
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
            HTTPServer httpServer = (HTTPServer)obj;
            return httpServer != null && _output == httpServer._output && _connectionString == httpServer._connectionString && _listener == httpServer._listener;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => _listener.GetHashCode() + _connectionString.GetHashCode() + _output.GetHashCode();
    }
}