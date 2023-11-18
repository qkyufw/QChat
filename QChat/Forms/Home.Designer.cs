
namespace QChat.Forms
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.myCreateBtn = new System.Windows.Forms.Button();
            this.chatBtnPanl = new System.Windows.Forms.FlowLayoutPanel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.msgTextBox2 = new System.Windows.Forms.RichTextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.roomLabel = new System.Windows.Forms.Label();
            this.msgTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.messagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftPanel.Controls.Add(this.myCreateBtn);
            this.leftPanel.Controls.Add(this.chatBtnPanl);
            this.leftPanel.Controls.Add(this.searchBtn);
            this.leftPanel.Controls.Add(this.searchTextBox);
            this.leftPanel.Controls.Add(this.userNameLabel);
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(197, 618);
            this.leftPanel.TabIndex = 0;
            // 
            // myCreateBtn
            // 
            this.myCreateBtn.Location = new System.Drawing.Point(5, 561);
            this.myCreateBtn.Name = "myCreateBtn";
            this.myCreateBtn.Size = new System.Drawing.Size(180, 40);
            this.myCreateBtn.TabIndex = 4;
            this.myCreateBtn.Text = "新建聊天";
            this.myCreateBtn.UseVisualStyleBackColor = true;
            this.myCreateBtn.Click += new System.EventHandler(this.myCreateBtn_Click);
            // 
            // chatBtnPanl
            // 
            this.chatBtnPanl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.chatBtnPanl.Location = new System.Drawing.Point(5, 53);
            this.chatBtnPanl.Name = "chatBtnPanl";
            this.chatBtnPanl.Size = new System.Drawing.Size(186, 502);
            this.chatBtnPanl.TabIndex = 3;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(151, 25);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(43, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "查找";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(5, 25);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(143, 21);
            this.searchTextBox.TabIndex = 1;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(3, 9);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(29, 12);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "name";
            this.userNameLabel.Click += new System.EventHandler(this.userNameLabel_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightPanel.Controls.Add(this.messagePanel);
            this.rightPanel.Controls.Add(this.sendBtn);
            this.rightPanel.Controls.Add(this.roomLabel);
            this.rightPanel.Controls.Add(this.msgTextBox1);
            this.rightPanel.Location = new System.Drawing.Point(197, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(695, 618);
            this.rightPanel.TabIndex = 1;
            // 
            // messagePanel
            // 
            this.messagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messagePanel.Controls.Add(this.msgTextBox2);
            this.messagePanel.Location = new System.Drawing.Point(7, 53);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(685, 354);
            this.messagePanel.TabIndex = 5;
            // 
            // msgTextBox2
            // 
            this.msgTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgTextBox2.Location = new System.Drawing.Point(0, 0);
            this.msgTextBox2.Name = "msgTextBox2";
            this.msgTextBox2.ReadOnly = true;
            this.msgTextBox2.Size = new System.Drawing.Size(685, 354);
            this.msgTextBox2.TabIndex = 4;
            this.msgTextBox2.Text = "";
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sendBtn.Location = new System.Drawing.Point(603, 569);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(80, 30);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "发送";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roomLabel.Location = new System.Drawing.Point(7, 13);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(134, 27);
            this.roomLabel.TabIndex = 2;
            this.roomLabel.Text = "欢迎使用~";
            this.roomLabel.Click += new System.EventHandler(this.roomLabel_Click);
            this.roomLabel.MouseEnter += new System.EventHandler(this.roomLabel_MouseEnter);
            // 
            // msgTextBox1
            // 
            this.msgTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.msgTextBox1.Location = new System.Drawing.Point(7, 413);
            this.msgTextBox1.Name = "msgTextBox1";
            this.msgTextBox1.Size = new System.Drawing.Size(685, 142);
            this.msgTextBox1.TabIndex = 0;
            this.msgTextBox1.Text = "";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 618);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(908, 657);
            this.Name = "Home";
            this.Text = "QChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.messagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        public System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button myCreateBtn;
        private System.Windows.Forms.FlowLayoutPanel chatBtnPanl;
        private System.Windows.Forms.Button sendBtn;
        public System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.RichTextBox msgTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox msgTextBox2;
        private System.Windows.Forms.Panel messagePanel;
    }
}