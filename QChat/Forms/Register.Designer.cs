
namespace QChat.Forms
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.pwdLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.pwdCLabel = new System.Windows.Forms.Label();
            this.nameLable = new System.Windows.Forms.Label();
            this.pwdCTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pwdLabel
            // 
            this.pwdLabel.AutoSize = true;
            this.pwdLabel.Location = new System.Drawing.Point(138, 158);
            this.pwdLabel.Name = "pwdLabel";
            this.pwdLabel.Size = new System.Drawing.Size(29, 12);
            this.pwdLabel.TabIndex = 11;
            this.pwdLabel.Text = "密码";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(138, 131);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(29, 12);
            this.emailLabel.TabIndex = 10;
            this.emailLabel.Text = "邮箱";
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Location = new System.Drawing.Point(197, 155);
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.PasswordChar = 'O';
            this.pwdTextBox.Size = new System.Drawing.Size(158, 21);
            this.pwdTextBox.TabIndex = 3;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(197, 128);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(158, 21);
            this.emailTextBox.TabIndex = 2;
            // 
            // pwdCLabel
            // 
            this.pwdCLabel.AutoSize = true;
            this.pwdCLabel.Location = new System.Drawing.Point(138, 185);
            this.pwdCLabel.Name = "pwdCLabel";
            this.pwdCLabel.Size = new System.Drawing.Size(53, 12);
            this.pwdCLabel.TabIndex = 15;
            this.pwdCLabel.Text = "确认密码";
            // 
            // nameLable
            // 
            this.nameLable.AutoSize = true;
            this.nameLable.Location = new System.Drawing.Point(138, 104);
            this.nameLable.Name = "nameLable";
            this.nameLable.Size = new System.Drawing.Size(41, 12);
            this.nameLable.TabIndex = 14;
            this.nameLable.Text = "用户名";
            // 
            // pwdCTextBox
            // 
            this.pwdCTextBox.Location = new System.Drawing.Point(197, 182);
            this.pwdCTextBox.Name = "pwdCTextBox";
            this.pwdCTextBox.PasswordChar = 'O';
            this.pwdCTextBox.Size = new System.Drawing.Size(158, 21);
            this.pwdCTextBox.TabIndex = 4;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(197, 101);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(158, 21);
            this.nameTextBox.TabIndex = 1;
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(235, 209);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 5;
            this.registerBtn.Text = "确认注册";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // Register
            // 
            this.AcceptButton = this.registerBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 321);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.pwdCLabel);
            this.Controls.Add(this.nameLable);
            this.Controls.Add(this.pwdCTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.pwdLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.pwdTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(520, 360);
            this.MinimumSize = new System.Drawing.Size(520, 360);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Qchat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pwdLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label pwdCLabel;
        private System.Windows.Forms.Label nameLable;
        private System.Windows.Forms.TextBox pwdCTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button registerBtn;
    }
}