using ClientSrever;
using Gauss.Algorithm;
using Gauss.MatrixMethod;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new TCPIPServer();
            var serverHttp = new HTTPServer();
            var client = new TCPClient();
            var matrix = new double[3, 4]
            {
                {2, 1, -1, 8},
                {-3, -1, 2, -11},
                {-2, 1, 7, -3}
            };
            Matrix matrix1 = new Matrix(matrix);
            var algorithm = new LinearSystem(matrix1);
            var result = algorithm.GaussSolve();
            // client.SendToServer(matrix);

            //server.SendToClient(algorithm);
            Console.WriteLine(client.SendToServer(matrix1));
            //Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}