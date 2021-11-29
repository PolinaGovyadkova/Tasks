using Gauss.Algorithm;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientSrever
{
    public class TCPIPServer : Network
    {
        protected delegate void VectorX(string vectorX);

        protected static event VectorX Notify;

        private TcpListener _server;
        private TcpClient _client;
        private NetworkStream _stream;

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

        protected override void Dispouse()
        {
            _stream.Close();
            _client.Close();
        }
    }
}