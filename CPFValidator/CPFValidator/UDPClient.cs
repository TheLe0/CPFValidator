using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CPFValidator
{
    class UDPClient :IClient
    {
        public void ConnectHost()
        {
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse("127.0.0.1");
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);

            Console.WriteLine("Digite o CPF: ");
            string cpf = Console.ReadLine();
            byte[] send_buffer = Encoding.ASCII.GetBytes(cpf);

            try
            {
                sending_socket.SendTo(send_buffer, sending_end_point);
            }
            catch (Exception send_exception)
            {
                Console.WriteLine(" Exception {0}", send_exception.Message);
            }

            Console.WriteLine("FIM!");
        }
    }
}
