namespace KindleClippings
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuDGV1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemSaveToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuDGV2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuDGV1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuDGV2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title});
            this.dataGridView1.ContextMenuStrip = this.contextMenuDGV1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(373, 468);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // title
            // 
            this.title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.title.FillWeight = 370F;
            this.title.HeaderText = "Книги";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Width = 370;
            // 
            // contextMenuDGV1
            // 
            this.contextMenuDGV1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemSaveToFile});
            this.contextMenuDGV1.Name = "contextMenuDGV1";
            this.contextMenuDGV1.Size = new System.Drawing.Size(163, 26);
            // 
            // ItemSaveToFile
            // 
            this.ItemSaveToFile.Name = "ItemSaveToFile";
            this.ItemSaveToFile.Size = new System.Drawing.Size(162, 22);
            this.ItemSaveToFile.Text = "Сохранить как...";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.text});
            this.dataGridView2.ContextMenuStrip = this.contextMenuDGV2;
            this.dataGridView2.Location = new System.Drawing.Point(392, 36);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(720, 468);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // text
            // 
            this.text.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.text.HeaderText = "Цитаты";
            this.text.Name = "text";
            this.text.ReadOnly = true;
            // 
            // contextMenuDGV2
            // 
            this.contextMenuDGV2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemOpen,
            this.ItemCopyToClipboard});
            this.contextMenuDGV2.Name = "contextMenuDGV2";
            this.contextMenuDGV2.Size = new System.Drawing.Size(195, 48);
            // 
            // ItemOpen
            // 
            this.ItemOpen.Name = "ItemOpen";
            this.ItemOpen.Size = new System.Drawing.Size(194, 22);
            this.ItemOpen.Text = "Открыть";
            this.ItemOpen.Click += new System.EventHandler(this.ItemOpen_Click);
            // 
            // ItemCopyToClipboard
            // 
            this.ItemCopyToClipboard.Name = "ItemCopyToClipboard";
            this.ItemCopyToClipboard.Size = new System.Drawing.Size(194, 22);
            this.ItemCopyToClipboard.Text = "Копировать (в буфер)";
            this.ItemCopyToClipboard.Click += new System.EventHandler(this.ItemCopyToClipboard_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1124, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ItemFile
            // 
            this.ItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemFile_Open,
            this.ItemFile_Save,
            this.ItemFile_Exit});
            this.ItemFile.Name = "ItemFile";
            this.ItemFile.Size = new System.Drawing.Size(48, 20);
            this.ItemFile.Text = "Файл";
            // 
            // ItemFile_Open
            // 
            this.ItemFile_Open.Name = "ItemFile_Open";
            this.ItemFile_Open.Size = new System.Drawing.Size(162, 22);
            this.ItemFile_Open.Text = "Открыть";
            this.ItemFile_Open.Click += new System.EventHandler(this.ItemFile_Open_Click);
            // 
            // ItemFile_Save
            // 
            this.ItemFile_Save.Name = "ItemFile_Save";
            this.ItemFile_Save.Size = new System.Drawing.Size(162, 22);
            this.ItemFile_Save.Text = "Сохранить как...";
            // 
            // ItemFile_Exit
            // 
            this.ItemFile_Exit.Name = "ItemFile_Exit";
            this.ItemFile_Exit.Size = new System.Drawing.Size(162, 22);
            this.ItemFile_Exit.Text = "Выход";
            this.ItemFile_Exit.Click += new System.EventHandler(this.ItemFile_Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 517);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "KindleClippings";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuDGV1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuDGV2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn text;
        private System.Windows.Forms.ContextMenuStrip contextMenuDGV2;
        private System.Windows.Forms.ToolStripMenuItem ItemCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem ItemOpen;
        private System.Windows.Forms.ContextMenuStrip contextMenuDGV1;
        private System.Windows.Forms.ToolStripMenuItem ItemSaveToFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ItemFile;
        private System.Windows.Forms.ToolStripMenuItem ItemFile_Open;
        private System.Windows.Forms.ToolStripMenuItem ItemFile_Save;
        private System.Windows.Forms.ToolStripMenuItem ItemFile_Exit;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
    }
}

