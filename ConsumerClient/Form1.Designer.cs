namespace ConsumerClient
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
            txtBootstrapServer = new TextBox();
            txtTopic = new TextBox();
            txtGroupId = new TextBox();
            btnStartConsumer = new Button();
            btnStopConsumer = new Button();
            btnLoad = new Button();
            lstMessages = new ListBox();
            dgvMessages = new DataGridView();
            lblBootstrapServer = new Label();
            lblTopic = new Label();
            lblGroupId = new Label();
            lblMessages = new Label();
            lblDatabase = new Label();
            lblSearchUserId = new Label();
            lblStartDate = new Label();
            lblEndDate = new Label();
            lblKeyword = new Label();
            txtSearchUserId = new TextBox();
            txtKeyword = new TextBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvMessages).BeginInit();
            SuspendLayout();
            // 
            // txtBootstrapServer
            // 
            txtBootstrapServer.Location = new Point(12, 27);
            txtBootstrapServer.Name = "txtBootstrapServer";
            txtBootstrapServer.Size = new Size(158, 23);
            txtBootstrapServer.TabIndex = 0;
            txtBootstrapServer.Text = "localhost:9092";
            txtBootstrapServer.TextChanged += txtBootstrapServer_TextChanged;
            // 
            // txtTopic
            // 
            txtTopic.Location = new Point(12, 71);
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(158, 23);
            txtTopic.TabIndex = 1;
            txtTopic.Text = "winform-sample-topic";
            // 
            // txtGroupId
            // 
            txtGroupId.Location = new Point(12, 115);
            txtGroupId.Name = "txtGroupId";
            txtGroupId.Size = new Size(158, 23);
            txtGroupId.TabIndex = 2;
            txtGroupId.Text = "notification-consumer";
            // 
            // btnStartConsumer
            // 
            btnStartConsumer.Location = new Point(13, 149);
            btnStartConsumer.Name = "btnStartConsumer";
            btnStartConsumer.Size = new Size(75, 23);
            btnStartConsumer.TabIndex = 3;
            btnStartConsumer.Text = "수신 시작";
            btnStartConsumer.UseVisualStyleBackColor = true;
            btnStartConsumer.Click += btnStartConsumer_Click;
            // 
            // btnStopConsumer
            // 
            btnStopConsumer.Location = new Point(95, 149);
            btnStopConsumer.Name = "btnStopConsumer";
            btnStopConsumer.Size = new Size(75, 23);
            btnStopConsumer.TabIndex = 4;
            btnStopConsumer.Text = "수신 중지";
            btnStopConsumer.UseVisualStyleBackColor = true;
            btnStopConsumer.Click += btnStopConsumer_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(502, 149);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "조회";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // lstMessages
            // 
            lstMessages.FormattingEnabled = true;
            lstMessages.Location = new Point(12, 212);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(689, 79);
            lstMessages.TabIndex = 6;
            lstMessages.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dgvMessages
            // 
            dgvMessages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMessages.Location = new Point(11, 312);
            dgvMessages.Name = "dgvMessages";
            dgvMessages.Size = new Size(690, 209);
            dgvMessages.TabIndex = 7;
            // 
            // lblBootstrapServer
            // 
            lblBootstrapServer.AutoSize = true;
            lblBootstrapServer.Location = new Point(10, 9);
            lblBootstrapServer.Name = "lblBootstrapServer";
            lblBootstrapServer.Size = new Size(73, 15);
            lblBootstrapServer.TabIndex = 8;
            lblBootstrapServer.Text = "Kafka Server";
            // 
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(13, 53);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(36, 15);
            lblTopic.TabIndex = 9;
            lblTopic.Text = "Topic";
            // 
            // lblGroupId
            // 
            lblGroupId.AutoSize = true;
            lblGroupId.Location = new Point(12, 97);
            lblGroupId.Name = "lblGroupId";
            lblGroupId.Size = new Size(56, 15);
            lblGroupId.TabIndex = 10;
            lblGroupId.Text = "Group ID";
            // 
            // lblMessages
            // 
            lblMessages.AutoSize = true;
            lblMessages.Location = new Point(12, 194);
            lblMessages.Name = "lblMessages";
            lblMessages.Size = new Size(71, 15);
            lblMessages.TabIndex = 11;
            lblMessages.Text = "수신 메시지";
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Location = new Point(12, 294);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(79, 15);
            lblDatabase.TabIndex = 12;
            lblDatabase.Text = "DB 조회 결과";
            // 
            // lblSearchUserId
            // 
            lblSearchUserId.AutoSize = true;
            lblSearchUserId.Location = new Point(352, 27);
            lblSearchUserId.Name = "lblSearchUserId";
            lblSearchUserId.Size = new Size(59, 15);
            lblSearchUserId.TabIndex = 13;
            lblSearchUserId.Text = "사용자 ID";
            lblSearchUserId.Click += label1_Click;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(352, 56);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(43, 15);
            lblStartDate.TabIndex = 14;
            lblStartDate.Text = "시작일";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(352, 83);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(43, 15);
            lblEndDate.TabIndex = 15;
            lblEndDate.Text = "종료일";
            // 
            // lblKeyword
            // 
            lblKeyword.AutoSize = true;
            lblKeyword.Location = new Point(352, 116);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(43, 15);
            lblKeyword.TabIndex = 16;
            lblKeyword.Text = "검색어";
            // 
            // txtSearchUserId
            // 
            txtSearchUserId.Location = new Point(417, 24);
            txtSearchUserId.Name = "txtSearchUserId";
            txtSearchUserId.Size = new Size(160, 23);
            txtSearchUserId.TabIndex = 17;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(417, 112);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(160, 23);
            txtKeyword.TabIndex = 18;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(417, 56);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(160, 23);
            dtpStartDate.TabIndex = 19;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(417, 83);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(160, 23);
            dtpEndDate.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 534);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(txtKeyword);
            Controls.Add(txtSearchUserId);
            Controls.Add(lblKeyword);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblSearchUserId);
            Controls.Add(lblDatabase);
            Controls.Add(lblMessages);
            Controls.Add(lblGroupId);
            Controls.Add(lblTopic);
            Controls.Add(lblBootstrapServer);
            Controls.Add(dgvMessages);
            Controls.Add(lstMessages);
            Controls.Add(btnLoad);
            Controls.Add(btnStopConsumer);
            Controls.Add(btnStartConsumer);
            Controls.Add(txtGroupId);
            Controls.Add(txtTopic);
            Controls.Add(txtBootstrapServer);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMessages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox txtBootstrapServer;
        private TextBox txtTopic;
        private TextBox txtGroupId;
        private Button btnStartConsumer;
        private Button btnStopConsumer;
        private Button btnLoad;
        private ListBox lstMessages;
        private DataGridView dgvMessages;
        private Label lblBootstrapServer;
        private Label lblTopic;
        private Label lblGroupId;
        private Label lblMessages;
        private Label lblDatabase;
        private Label lblSearchUserId;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblKeyword;
        private TextBox txtSearchUserId;
        private TextBox txtKeyword;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
    }
}
