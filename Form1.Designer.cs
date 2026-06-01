namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label5 = new Label();
            txtKafkaServer = new TextBox();
            txtTopic = new TextBox();
            label1 = new Label();
            txtUserId = new TextBox();
            label2 = new Label();
            txtTitle = new TextBox();
            label3 = new Label();
            txtMessage = new TextBox();
            label4 = new Label();
            btnSend = new Button();
            txtLog = new TextBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 9;
            label5.Text = "Kafka 서버주소";
            label5.Click += label5_Click;
            // 
            // txtKafkaServer
            // 
            txtKafkaServer.Location = new Point(12, 27);
            txtKafkaServer.Name = "txtKafkaServer";
            txtKafkaServer.Size = new Size(100, 23);
            txtKafkaServer.TabIndex = 10;
            txtKafkaServer.TextChanged += textBox5_TextChanged;
            // 
            // txtTopic
            // 
            txtTopic.Location = new Point(12, 83);
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(100, 23);
            txtTopic.TabIndex = 12;
            txtTopic.TextChanged += txtTopic_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 65);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 11;
            label1.Text = "Topic";
            label1.Click += label1_Click_1;
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(12, 143);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(100, 23);
            txtUserId.TabIndex = 14;
            txtUserId.TextChanged += txtUserId_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 125);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 13;
            label2.Text = "사용자 ID";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 197);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 23);
            txtTitle.TabIndex = 16;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 179);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 15;
            label3.Text = "제목";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 252);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(100, 23);
            txtMessage.TabIndex = 18;
            txtMessage.TextChanged += textBox4_TextChanged_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 234);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 17;
            label4.Text = "내용";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 290);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 19;
            btnSend.Text = "전송";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(12, 331);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(537, 168);
            txtLog.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 511);
            Controls.Add(txtLog);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(label4);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(txtUserId);
            Controls.Add(label2);
            Controls.Add(txtTopic);
            Controls.Add(label1);
            Controls.Add(txtKafkaServer);
            Controls.Add(label5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private TextBox txtKafkaServer;
        private TextBox txtTopic;
        private Label label1;
        private TextBox txtUserId;
        private Label label2;
        private TextBox txtTitle;
        private Label label3;
        private TextBox txtMessage;
        private Label label4;
        private Button btnSend;
        private TextBox txtLog;
    }
}
