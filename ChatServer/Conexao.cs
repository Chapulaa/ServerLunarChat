using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    //Trata as conexoes
    public class Conexao
    {
        TcpClient tcpCliente;

        private Thread thrSender;
        private StreamReader srReceptor;
        private StreamWriter swEnviador;
        private string usuarioAtual;
        private string strResposta;

        //Constutor que recebre a conexão TCP
        public Conexao(TcpClient tcpCon)
        {
            this.tcpCliente = tcpCon;
            //A thread que aceita o cliente e espera a mensagem
            thrSender = new Thread(AceitaCliente);
            thrSender.IsBackground = true;
            thrSender.Start();
        }

        private void FechaConexao()
        {
            //Fecha objetos abertos
            tcpCliente.Close();
            srReceptor.Close();
            swEnviador.Close();
        }

        //Quando o novo cliente é aceito
        private void AceitaCliente()
        {
            srReceptor = new StreamReader(tcpCliente.GetStream());
            swEnviador = new StreamWriter(tcpCliente.GetStream());

            //Lê a informação da conta do cliente
            usuarioAtual = srReceptor.ReadLine();

            //Resposta do cliente
            if (usuarioAtual != "")
            {
                //Armazena o nome de usuario na hash table
                if (Servidor.htUsuarios.Contains(usuarioAtual))
                {
                    // 0 => significa nao conctado
                    swEnviador.WriteLine("O|Este nome de usuário já existe.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else if (usuarioAtual == "Administador")
                {
                    swEnviador.WriteLine("O|Este nome é reservado.");
                    swEnviador.Flush();
                    FechaConexao();
                    return;
                }
                else
                {
                    //1 => se conectou com sucesso
                    swEnviador.WriteLine("1");
                    swEnviador.Flush();

                    //Inclui o usuário na hash table e inicia a escuta de suas mensagens
                    Servidor.IncluiUsuario(tcpCliente, usuarioAtual);
                }
            }
            else
            {
                FechaConexao();
                return;
            }

            try
            {
                //continua aguardando por uma mensagem do usuário
                while ((strResposta = srReceptor.ReadLine()) != "")
                {
                    //Se for inválido remove-o
                    if(strResposta == null)
                    {
                        Servidor.RemoveUsuario(tcpCliente);
                    }
                    else
                    {
                        //Envia mensagem para todos os usuários
                        Servidor.EnviaMensagem(usuarioAtual,strResposta);
                    }
                }
            }
            catch
            {
                //Se houve problema com o usuario desconecta-lo
                Servidor.RemoveUsuario(tcpCliente);
            }
        }
    }
}
