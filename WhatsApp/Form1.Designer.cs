namespace WhatsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtDestPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.RichTextBox txtMessages; // Cambiado a RichTextBox
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnConnect = new Button();
            btnSend = new Button();
            txtMessage = new TextBox();
            txtDestPort = new TextBox();
            txtPort = new TextBox();
            txtMessages = new RichTextBox(); // Cambiado a RichTextBox
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(372, 19);
            btnConnect.Margin = new Padding(4, 3, 4, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(88, 27);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(372, 146);
            btnSend.Margin = new Padding(4, 3, 4, 3);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(88, 27);
            btnSend.TabIndex = 1;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(23, 150);
            txtMessage.Margin = new Padding(4, 3, 4, 3);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(326, 23);
            txtMessage.TabIndex = 2;
            // 
            // txtDestPort
            // 
            txtDestPort.Location = new Point(23, 90);
            txtDestPort.Margin = new Padding(4, 3, 4, 3);
            txtDestPort.Name = "txtDestPort";
            txtDestPort.Size = new Size(116, 23);
            txtDestPort.TabIndex = 3;
            txtDestPort.Text = "Número de puerto";
            txtDestPort.TextChanged += txtDestPort_TextChanged;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(23, 23);
            txtPort.Margin = new Padding(4, 3, 4, 3);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(116, 23);
            txtPort.TabIndex = 4;
            txtPort.Text = "Número de puerto";
            // 
            // txtMessages
            // 
            txtMessages.Location = new Point(23, 189);
            txtMessages.Margin = new Padding(4, 3, 4, 3);
            txtMessages.Multiline = true;
            txtMessages.Name = "txtMessages";
            txtMessages.ReadOnly = true;
            txtMessages.Size = new Size(437, 230);
            txtMessages.TabIndex = 5;
            txtMessages.ScrollBars = RichTextBoxScrollBars.Vertical; 
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 29);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 6;
            label1.Text = "Puerto escucha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 98);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 7;
            label2.Text = "Puerto destino";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(490, 462);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMessages);
            Controls.Add(txtPort);
            Controls.Add(txtDestPort);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "ChatApp";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
