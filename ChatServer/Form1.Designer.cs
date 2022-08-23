namespace ChatServer
{
    partial class FormServidor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBackground = new System.Windows.Forms.Panel();
            this.listLogs = new System.Windows.Forms.ListBox();
            this.txtPort = new System.Windows.Forms.NumericUpDown();
            this.txtIp = new ChatServer.Controls.TextBoxControl();
            this.btnIniciarServidor = new TransferirArquivosServer.Controls.ButtonControl();
            this.panelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Location = new System.Drawing.Point(305, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 1;
            // 
            // panelBackground
            // 
            this.panelBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(52)))), ((int)(((byte)(95)))));
            this.panelBackground.BackgroundImage = global::ChatServer.Properties.Resources.LuaLogo;
            this.panelBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelBackground.Controls.Add(this.listLogs);
            this.panelBackground.Controls.Add(this.txtPort);
            this.panelBackground.Controls.Add(this.txtIp);
            this.panelBackground.Controls.Add(this.btnIniciarServidor);
            this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackground.Location = new System.Drawing.Point(0, 0);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(564, 450);
            this.panelBackground.TabIndex = 6;
            // 
            // listLogs
            // 
            this.listLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(52)))), ((int)(((byte)(95)))));
            this.listLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLogs.ForeColor = System.Drawing.Color.White;
            this.listLogs.FormattingEnabled = true;
            this.listLogs.ItemHeight = 20;
            this.listLogs.Location = new System.Drawing.Point(12, 87);
            this.listLogs.Name = "listLogs";
            this.listLogs.Size = new System.Drawing.Size(540, 340);
            this.listLogs.TabIndex = 3;
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(52)))), ((int)(((byte)(95)))));
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.ForeColor = System.Drawing.Color.White;
            this.txtPort.Location = new System.Drawing.Point(312, 39);
            this.txtPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(83, 18);
            this.txtPort.TabIndex = 2;
            this.txtPort.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // txtIp
            // 
            this.txtIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(52)))), ((int)(((byte)(95)))));
            this.txtIp.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtIp.BorderSize = 2;
            this.txtIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.ForeColor = System.Drawing.Color.White;
            this.txtIp.Location = new System.Drawing.Point(13, 24);
            this.txtIp.Margin = new System.Windows.Forms.Padding(4);
            this.txtIp.Name = "txtIp";
            this.txtIp.Padding = new System.Windows.Forms.Padding(7);
            this.txtIp.Size = new System.Drawing.Size(292, 30);
            this.txtIp.TabIndex = 1;
            this.txtIp.Texts = "";
            this.txtIp.UnderLinedStyle = true;
            // 
            // btnIniciarServidor
            // 
            this.btnIniciarServidor.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnIniciarServidor.BackGroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnIniciarServidor.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnIniciarServidor.BorderRadius = 40;
            this.btnIniciarServidor.BorderSize = 0;
            this.btnIniciarServidor.FlatAppearance.BorderSize = 0;
            this.btnIniciarServidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarServidor.ForeColor = System.Drawing.Color.White;
            this.btnIniciarServidor.Location = new System.Drawing.Point(401, 17);
            this.btnIniciarServidor.Name = "btnIniciarServidor";
            this.btnIniciarServidor.Size = new System.Drawing.Size(151, 53);
            this.btnIniciarServidor.TabIndex = 0;
            this.btnIniciarServidor.Text = "Iniciar Servidor";
            this.btnIniciarServidor.TextColor = System.Drawing.Color.White;
            this.btnIniciarServidor.UseVisualStyleBackColor = false;
            this.btnIniciarServidor.Click += new System.EventHandler(this.btnIniciarServidor_Click);
            // 
            // FormServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 450);
            this.Controls.Add(this.panelBackground);
            this.Controls.Add(this.panel1);
            this.Name = "FormServidor";
            this.Text = "Servidor LunarChat";
            this.panelBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBackground;
        private TransferirArquivosServer.Controls.ButtonControl btnIniciarServidor;
        private Controls.TextBoxControl txtIp;
        private System.Windows.Forms.NumericUpDown txtPort;
        private System.Windows.Forms.ListBox listLogs;
    }
}

