namespace DarkCrash.FileDatabase
{
    partial class MainForm
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
            TreeNode treeNode1 = new TreeNode("C:");
            TreeNode treeNode2 = new TreeNode("D:");
            TreeNode treeNode3 = new TreeNode("Root", new TreeNode[] { treeNode1, treeNode2 });
            menuStrip1 = new MenuStrip();
            ToolStripMenuItemLoad = new ToolStripMenuItem();
            ToolStripMenuItemSave = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            splitContainer1 = new SplitContainer();
            treeViewDrive = new TreeView();
            listViewDirectory = new ListView();
            columnHeaderName = new ColumnHeader();
            columnHeaderSize = new ColumnHeader();
            columnHeaderSha1 = new ColumnHeader();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemLoad, ToolStripMenuItemSave });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemLoad
            // 
            ToolStripMenuItemLoad.Name = "ToolStripMenuItemLoad";
            ToolStripMenuItemLoad.Size = new Size(65, 20);
            ToolStripMenuItemLoad.Text = "読み込み";
            ToolStripMenuItemLoad.Click += ToolStripMenuItemLoad_Click;
            // 
            // ToolStripMenuItemSave
            // 
            ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
            ToolStripMenuItemSave.Size = new Size(43, 20);
            ToolStripMenuItemSave.Text = "保存";
            ToolStripMenuItemSave.Click += ToolStripMenuItemSave_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeViewDrive);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listViewDirectory);
            splitContainer1.Size = new Size(800, 404);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 2;
            // 
            // treeViewDrive
            // 
            treeViewDrive.Dock = DockStyle.Fill;
            treeViewDrive.Location = new Point(0, 0);
            treeViewDrive.Name = "treeViewDrive";
            treeNode1.Name = "ノード1";
            treeNode1.Text = "C:";
            treeNode2.Name = "ノード2";
            treeNode2.Text = "D:";
            treeNode3.Name = "ノード0";
            treeNode3.Text = "Root";
            treeViewDrive.Nodes.AddRange(new TreeNode[] { treeNode3 });
            treeViewDrive.Size = new Size(266, 404);
            treeViewDrive.TabIndex = 0;
            treeViewDrive.AfterSelect += treeViewDrive_AfterSelect;
            // 
            // listViewDirectory
            // 
            listViewDirectory.Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderSize, columnHeaderSha1 });
            listViewDirectory.Dock = DockStyle.Fill;
            listViewDirectory.Location = new Point(0, 0);
            listViewDirectory.Name = "listViewDirectory";
            listViewDirectory.Size = new Size(530, 404);
            listViewDirectory.TabIndex = 0;
            listViewDirectory.UseCompatibleStateImageBehavior = false;
            listViewDirectory.View = View.Details;
            listViewDirectory.ItemActivate += listViewDirectory_ItemActivate;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 240;
            // 
            // columnHeaderSize
            // 
            columnHeaderSize.Text = "Size";
            columnHeaderSize.TextAlign = HorizontalAlignment.Right;
            columnHeaderSize.Width = 160;
            // 
            // columnHeaderSha1
            // 
            columnHeaderSha1.Text = "Sha1";
            columnHeaderSha1.Width = 240;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItemLoad;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private TreeView treeViewDrive;
        private ListView listViewDirectory;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderSize;
        private ColumnHeader columnHeaderSha1;
        private ToolStripMenuItem ToolStripMenuItemSave;
    }
}
