namespace QChat.Forms
{
    partial class CreateRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRoom));
            this.crtBtn = new System.Windows.Forms.Button();
            this.crtTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // crtBtn
            // 
            this.crtBtn.Location = new System.Drawing.Point(72, 76);
            this.crtBtn.Name = "crtBtn";
            this.crtBtn.Size = new System.Drawing.Size(75, 23);
            this.crtBtn.TabIndex = 1;
            this.crtBtn.Text = "创建群聊";
            this.crtBtn.UseVisualStyleBackColor = true;
            this.crtBtn.Click += new System.EventHandler(this.crtBtn_Click);
            // 
            // crtTextBox
            // 
            this.crtTextBox.Location = new System.Drawing.Point(62, 49);
            this.crtTextBox.Name = "crtTextBox";
            this.crtTextBox.Size = new System.Drawing.Size(100, 21);
            this.crtTextBox.TabIndex = 2;
            this.crtTextBox.Text = "请输入群聊名称";
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 161);
            this.Controls.Add(this.crtTextBox);
            this.Controls.Add(this.crtBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button crtBtn;
        private System.Windows.Forms.TextBox crtTextBox;
    }
}