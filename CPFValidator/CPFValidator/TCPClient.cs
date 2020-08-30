using System;
using System.IO;
using System.Net.Sockets;

namespace CPFValidator
{
    class TCPClient :IClient
    {
        public void ConnectHost()
        {
            TcpClient cliente = new TcpClient("localhost", 8888);
            Console.WriteLine("Conectei no servidor!!");

            NetworkStream saida = cliente.GetStream();
            BinaryReader recebe = new BinaryReader(saida);
            BinaryWriter envia = new BinaryWriter(saida);

            Console.WriteLine("Digite o CPF:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Vou enviar o Cpf: " + cpf);
            envia.Write(cpf);

            Console.WriteLine("Aguardando =resposta do servidor");
            string resposta = recebe.ReadString();
            Console.WriteLine("O Cpf é " + resposta);

            saida.Close();
            recebe.Close();
            envia.Close();
            cliente.Close();

            Console.WriteLine("Digite qualquer tecla para sair!");
            Console.ReadKey();
        }
    }
}
