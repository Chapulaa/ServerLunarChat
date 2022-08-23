using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class FormServidor : Form
    {
        private delegate void AtualizarStatusCallBack(string strMensagem);

        private bool conectado = false;
        public FormServidor()
        {
            InitializeComponent();
        }

        private void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            if (conectado)
            {
                Application.Exit();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIp.Texts))
            {
                MessageBox.Show("Informe o endereço de IP");
                txtIp.Focus();
                return;
            }

            try
            {
                //Analisa o endereco IP do servidor informado no textobox
                IPAddress enderecoIP = IPAddress.Parse(txtIp.Texts);
                int portaHost = (int)txtPort.Value;

                //Cria uma nova instância do objeto ChatServidor
                Servidor mainServidor = new Servidor(enderecoIP, portaHost);

                //Vincula o tratamento de evento StatusChanged a mainServer_StatusChanged
                Servidor.StatusChaged += new StatusChangedEventHandler(mainServidor_StatusChanged);

                //Inicia o atendimento das conexões
                mainServidor.IniciaAtendimento();

                //Mostra que nos iniciamos o atendimento para conexões
                listLogs.Items.Add("Servidor ativo, aguardando usuários conectarem-se...");
                listLogs.SetSelected(listLogs.Items.Count - 1, true);
            }
            catch (Exception ex)
            {
                listLogs.Items.Add("Erro de conexão: " + ex.Message);
                listLogs.SetSelected(listLogs.Items.Count - 1, true);
                return;
            }

            conectado = true;
            txtIp.Enabled = false;
            txtPort.Enabled = false;
            btnIniciarServidor.ForeColor = Color.Red;
            btnIniciarServidor.Text = "Sair";
        }

        public void mainServidor_StatusChanged(object sender, StatusChagedEventsArgs e)
        {
            //Chama o metodo que atualiza o formulário
            this.Invoke(new AtualizarStatusCallBack(this.AtualizarStatus), new object[] { e.EventMessage });
        }

        public void AtualizarStatus(string strMensagem)
        {
            listLogs.Items.Add(strMensagem);
            listLogs.SetSelected(listLogs.Items.Count - 1, true);
        }
    }
}
