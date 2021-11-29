using Gauss.MatrixMethod;
using System;
using System.Globalization;
using System.Net.Sockets;
using System.Text;

namespace ClientSrever
{
    public class TCPClient : Network
    {
        private delegate void StartData(string mes);

        private delegate string Data(string message);

        private static event Data Notify;

        private readonly TcpClient _client;

        private NetworkStream _stream;

        public TCPClient() => _client = new TcpClient();

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

        protected override void Dispouse()
        {
            _stream.Close();
            _client.Close();
        }
    }
}