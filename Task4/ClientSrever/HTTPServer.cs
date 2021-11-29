using Gauss.Algorithm;
using System.IO;
using System.Net;
using System.Text;

namespace ClientSrever
{
    public class HTTPServer : TCPIPServer
    {
        private Stream _output;
        private readonly HttpListener _listener;
        private readonly string _connectionString = $"http://localhost:{Port}/connection/";

        public HTTPServer() => _listener = new HttpListener();

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

        protected override void Dispouse()
        {
            _output.Close();
            _listener.Stop();
        }
    }
}