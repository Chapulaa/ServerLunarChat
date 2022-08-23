using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    public delegate void StatusChangedEventHandler(object sender, StatusChagedEventsArgs e);

    public class Servidor
    {
        public static Hashtable htUsuarios = new Hashtable(30);//Limite de usuarios definidos

        public static Hashtable htConexoes = new Hashtable(30);//Limite de conexões

        //Informações do endereço IP passado
        private IPAddress enderecoIp;
        private int portaHost;
        private TcpClient tcpClient;

        //O evento e o seu argumento ira mostrar quando um usuário se conecta ou desconect
        public static event StatusChangedEventHandler StatusChaged;
        private static StatusChagedEventsArgs e;

        //O construct define o enderecoIp para aquele retornado pela instancia do objeto
        public Servidor(IPAddress endereco, int port)
        {
            enderecoIp = endereco;
            portaHost = port;
        }

        //Thread ira tratar o escutador de conexões
        private Thread thrListener;

        //O objeto TCP object que escuta as conexões
        private TcpListener tlsCliente;

        //Irá dizer ao while para manter o servidor rodando
        bool ServRodando = false;

        //Inclui o usuario na tabelas hash
        public static void IncluiUsuario(TcpClient tcpUsuario, string strUsername)
        {
            //Primeiro inclui o nome e conexão associada para ambas as hash tables
            Servidor.htUsuarios.Add(strUsername, tcpUsuario);
            Servidor.htConexoes.Add(tcpUsuario, strUsername);

            //Informa a nova conexão para todos os usuários e para o formulário do servidor
            EnviaMensagemAdmin(htConexoes[tcpUsuario] + " entrou...");
        }

        //Remove os usuarios das hash tables
        public static void RemoveUsuario(TcpClient tcpUsuario)
        {
            //Se o usuário existir
            if (htConexoes[tcpUsuario] != null)
            {
                //Primeira informa ao outros usuários sobre a conexão
                EnviaMensagemAdmin(htConexoes[tcpUsuario] + " saiu...");

                //Remove o usuário da hash table
                Servidor.htUsuarios.Remove(Servidor.htConexoes[tcpUsuario]);
                Servidor.htConexoes.Remove(tcpUsuario);
            }
        }

        //Este evento é chamado quando disparamos o evento StatusChaged
        public static void OnStatusChanged(StatusChagedEventsArgs e)
        {
            StatusChangedEventHandler statusHandler = StatusChaged;

            if (statusHandler != null)
            {
                //Invoca o delegate
                statusHandler(null, e);
            }
        }

        //Envia mensagens para todos os usuários
        public static void EnviaMensagemAdmin(string pMensagem)
        {
            StreamWriter swSender;

            //Exibe primeiro na aplicação
            e = new StatusChagedEventsArgs("Administrador: " + pMensagem);
            OnStatusChanged(e);

            //Cria um array de clientes TCPs do tamanho do numero de clientes existentes
            TcpClient[] tcpClientes = new TcpClient[Servidor.htUsuarios.Count];
            //Copia os objetos TcpClient no array
            Servidor.htUsuarios.Values.CopyTo(tcpClientes, 0);

            //Percorre a lista de tcpCliente
            for (int i = 0; i < tcpClientes.Length; i++)
            {
                //Tenta enviar uma mensagem para cada cliente
                try
                {
                    //Se a mensagem estiver em branco ou a conexão for nula sai...
                    if (pMensagem.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }

                    //Envia a mensagem para o usuário atual no laço
                    swSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSender.WriteLine("Administrador: " + pMensagem);
                    swSender.Flush();
                    swSender = null;
                }
                catch
                {
                    //Se houver um problema , o usuario não existe, então remove-o
                    RemoveUsuario(tcpClientes[i]);
                }
            }
        }

        //Envia mensagens de um usuário para todos os usuários
        public static void EnviaMensagem(string Origem, string pMensagem)
        {
            StreamWriter swSender;

            //Primeiro exibe a mensagem na aplicação
            e = new StatusChagedEventsArgs(Origem + " disse: " + pMensagem);
            OnStatusChanged(e);

            //Cria um array de clientes TCPs do tamanho do numero de clientes existentes
            TcpClient[] tcpClientes = new TcpClient[Servidor.htUsuarios.Count];
            //Copia os objetos TcpClient no array
            Servidor.htUsuarios.Values.CopyTo(tcpClientes, 0);

            //Percorre a lista de tcpCliente
            for (int i = 0; i < tcpClientes.Length; i++)
            {
                //Tenta enviar uma mensagem para cada cliente
                try
                {
                    //Se a mensagem estiver em branco ou a conexão for nula sai...
                    if (pMensagem.Trim() == "" || tcpClientes[i] == null)
                    {
                        continue;
                    }

                    //Envia a mensagem para o usuário atual no laço
                    swSender = new StreamWriter(tcpClientes[i].GetStream());
                    swSender.WriteLine("Administrador: " + pMensagem);
                    swSender.Flush();
                    swSender = null;
                }
                catch
                {
                    //Se houver um problema , o usuario não existe, então remove-o
                    RemoveUsuario(tcpClientes[i]);
                }
            }
        }

        public void IniciaAtendimento()
        {
            try
            {
                //Pega o IP
                IPAddress ipLocal = enderecoIp;

                int portaLocal = portaHost;

                tlsCliente = new TcpListener(ipLocal, portaLocal);

                //Inicia o TCP listener e escuta as conexões
                tlsCliente.Start();

                //O laço While verifica se o servidor esta rodando antes de checar as conexões
                ServRodando = true;

                //Inicia uma nova thread que hospeda o listener
                thrListener = new Thread(MantemAtendimento);
                thrListener.IsBackground = true;
                thrListener.Start();
            }
            catch (Exception ex)
            {

            }
        }

        private void MantemAtendimento()
        {
            while (ServRodando)
            {
                //Aceita uma conexão pendente
                tcpClient = tlsCliente.AcceptTcpClient();
                //Cria uma nova instancia da conexão
                Conexao newConnection = new Conexao(tcpClient);
            }
        }
    }
}
