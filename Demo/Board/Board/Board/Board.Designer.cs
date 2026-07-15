
namespace Board
{
    partial class Board
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.공지사항ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.열기ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.복사ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.잘라내기ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.도움말ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.공지사항ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 공지사항ToolStripMenuItem
            // 
            this.공지사항ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.보기ToolStripMenuItem,
            this.추가ToolStripMenuItem,
            this.삭제ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.공지사항ToolStripMenuItem.Name = "공지사항ToolStripMenuItem";
            this.공지사항ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.공지사항ToolStripMenuItem.Text = "공지사항";
            // 
            // 보기ToolStripMenuItem
            // 
            this.보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            this.보기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.보기ToolStripMenuItem.Text = "보기";
            // 
            // 추가ToolStripMenuItem
            // 
            this.추가ToolStripMenuItem.Name = "추가ToolStripMenuItem";
            this.추가ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.추가ToolStripMenuItem.Text = "추가";
            // 
            // 삭제ToolStripMenuItem
            // 
            this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.삭제ToolStripMenuItem.Text = "삭제";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripButton,
            this.복사ToolStripButton,
            this.잘라내기ToolStripButton,
            this.toolStripSeparator1,
            this.도움말ToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 열기ToolStripButton
            // 
            this.열기ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.열기ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("열기ToolStripButton.Image")));
            this.열기ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.열기ToolStripButton.Name = "열기ToolStripButton";
            this.열기ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.열기ToolStripButton.Text = "열기";
            // 
            // 복사ToolStripButton
            // 
            this.복사ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.복사ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("복사ToolStripButton.Image")));
            this.복사ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.복사ToolStripButton.Name = "복사ToolStripButton";
            this.복사ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.복사ToolStripButton.Text = "복사";
            // 
            // 잘라내기ToolStripButton
            // 
            this.잘라내기ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.잘라내기ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("잘라내기ToolStripButton.Image")));
            this.잘라내기ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.잘라내기ToolStripButton.Name = "잘라내기ToolStripButton";
            this.잘라내기ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.잘라내기ToolStripButton.Text = "잘라내기";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // 도움말ToolStripButton
            // 
            this.도움말ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.도움말ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("도움말ToolStripButton.Image")));
            this.도움말ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.도움말ToolStripButton.Name = "도움말ToolStripButton";
            this.도움말ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.도움말ToolStripButton.Text = "도움말";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.title,
            this.name,
            this.readCount});
            this.dataGridView1.Location = new System.Drawing.Point(0, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(788, 362);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "번호";
            this.id.Name = "id";
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "제목";
            this.title.Name = "title";
            this.title.Width = 400;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "작성자";
            this.name.Name = "name";
            this.name.Width = 170;
            // 
            // readCount
            // 
            this.readCount.DataPropertyName = "readCount";
            this.readCount.HeaderText = "조회수";
            this.readCount.Name = "readCount";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(629, 417);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "삭제";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(710, 417);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "추가";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Board";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 공지사항ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton 열기ToolStripButton;
        private System.Windows.Forms.ToolStripButton 복사ToolStripButton;
        private System.Windows.Forms.ToolStripButton 잘라내기ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 도움말ToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn readCount;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
    }
}

