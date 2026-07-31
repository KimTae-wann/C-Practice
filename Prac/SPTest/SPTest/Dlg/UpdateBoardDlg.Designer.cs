
namespace SPTest.Dlg
{
    partial class UpdateBoardDlg
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
            this.closeButton = new System.Windows.Forms.Button();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.iDateLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.inputReadCountLabel = new System.Windows.Forms.Label();
            this.readCountLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(680, 377);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(103, 47);
            this.closeButton.TabIndex = 28;
            this.closeButton.Text = "닫기";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(22, 145);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(761, 210);
            this.contentTextBox.TabIndex = 26;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(571, 377);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(103, 47);
            this.updateButton.TabIndex = 27;
            this.updateButton.Text = "수정";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // iDateLabel
            // 
            this.iDateLabel.AutoSize = true;
            this.iDateLabel.Location = new System.Drawing.Point(22, 377);
            this.iDateLabel.Name = "iDateLabel";
            this.iDateLabel.Size = new System.Drawing.Size(53, 12);
            this.iDateLabel.TabIndex = 25;
            this.iDateLabel.Text = "현재시간";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(479, 63);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(304, 21);
            this.passwordTextBox.TabIndex = 24;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Enabled = false;
            this.emailTextBox.Location = new System.Drawing.Point(84, 90);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.ReadOnly = true;
            this.emailTextBox.Size = new System.Drawing.Size(240, 21);
            this.emailTextBox.TabIndex = 23;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(84, 63);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(240, 21);
            this.nameTextBox.TabIndex = 22;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("굴림", 15F);
            this.titleTextBox.Location = new System.Drawing.Point(84, 26);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(699, 30);
            this.titleTextBox.TabIndex = 21;
            // 
            // inputReadCountLabel
            // 
            this.inputReadCountLabel.AutoSize = true;
            this.inputReadCountLabel.Location = new System.Drawing.Point(742, 93);
            this.inputReadCountLabel.Name = "inputReadCountLabel";
            this.inputReadCountLabel.Size = new System.Drawing.Size(41, 12);
            this.inputReadCountLabel.TabIndex = 20;
            this.inputReadCountLabel.Text = "조회수";
            // 
            // readCountLabel
            // 
            this.readCountLabel.AutoSize = true;
            this.readCountLabel.Location = new System.Drawing.Point(560, 93);
            this.readCountLabel.Name = "readCountLabel";
            this.readCountLabel.Size = new System.Drawing.Size(53, 12);
            this.readCountLabel.TabIndex = 19;
            this.readCountLabel.Text = "[조회수]";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(406, 66);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(65, 12);
            this.passwordLabel.TabIndex = 18;
            this.passwordLabel.Text = "[비밀번호]";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(28, 93);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(53, 12);
            this.emailLabel.TabIndex = 17;
            this.emailLabel.Text = "[이메일]";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(28, 66);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 12);
            this.nameLabel.TabIndex = 16;
            this.nameLabel.Text = "[작성자]";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("굴림", 15F);
            this.titleLabel.Location = new System.Drawing.Point(18, 29);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(69, 20);
            this.titleLabel.TabIndex = 15;
            this.titleLabel.Text = "[제목]";
            // 
            // UpdateBoardDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.iDateLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.inputReadCountLabel);
            this.Controls.Add(this.readCountLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "UpdateBoardDlg";
            this.Text = "상세화면";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label iDateLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label inputReadCountLabel;
        private System.Windows.Forms.Label readCountLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}