using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class FormServidor : Form
    {
        public FormServidor()
        {
            InitializeComponent();

            this.listLogs.BackColor = Color.Transparent;
            this.TransparencyKey = BackColor;
        }
    }
}
