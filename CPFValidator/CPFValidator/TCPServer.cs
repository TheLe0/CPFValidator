using System;
using System.IO;
using System.Net.Sockets;

namespace CPFValidator
{
    class TCPServer : IServer
    {
        public TcpListener Servidor { private set; get; }
        public void CreateHost()
        {
            this.Servidor = new TcpListener(8888);

            this.Servidor.Start();
            Console.WriteLine("Servidor Inicializado");

            TcpClient conversacliente = this.Servidor.AcceptTcpClient();
            Console.WriteLine("Cliente Conectou!!");

            NetworkStream saida = conversacliente.GetStream();
            BinaryReader recebe = new BinaryReader(saida);
            BinaryWriter envia = new BinaryWriter(saida);

            string cpf = recebe.ReadString();
            Console.WriteLine("Recebi a mensagem: " + cpf);
            string resposta;

            if (CPFUtils.IsCpf(cpf))
            {
                resposta = "Válido";
            }
            else
            {
                resposta = "Inválido";
            }

            envia.Write(resposta);

            saida.Close();
            recebe.Close();
            envia.Close();
            conversacliente.Close();
            this.Servidor.Stop();

            Console.WriteLine("Digite qualquer tecla para sair!");
            Console.ReadKey();
        }
    }
}
