using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CPFValidator
{
	public class UDPServer
	{
		private const int listenPort = 11000;

		public int CreateHost()
		{
			UdpClient listener = new UdpClient(listenPort);
			IPEndPoint groupEP;
			string received_data;
			byte[] receive_byte_array;

			try
			{
				groupEP = new IPEndPoint(IPAddress.Any, listenPort);

				Console.WriteLine("Esperando a entrada de dados");

				receive_byte_array = listener.Receive(ref groupEP);
				received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);

				Console.WriteLine("Recebido o CPF: {0}", received_data);

				if (CPFUtils.IsCpf(received_data))
                {
					Console.WriteLine("O CPF é válido!");
                }
				else
                {
					Console.WriteLine("O CPF é inválido!");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
            finally
            {
				listener.Close();
			}
			
			return 0;

		}
	}
}

