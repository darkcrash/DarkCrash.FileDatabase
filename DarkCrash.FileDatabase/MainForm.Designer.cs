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
            components = new System.ComponentModel.Container();
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
            contextMenuStripFile = new ContextMenuStrip(components);
            computeHashToolStripMenuItem = new ToolStripMenuItem();
            filesOfTheSameSizeToolStripMenuItem = new ToolStripMenuItem();
            openShellToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            toolStripTextBoxCurrentPath = new ToolStripTextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            contextMenuStripFile.SuspendLayout();
            toolStrip1.SuspendLayout();
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
            ToolStripMenuItemLoad.Size = new Size(69, 20);
            ToolStripMenuItemLoad.Text = "LoadData";
            ToolStripMenuItemLoad.Click += ToolStripMenuItemLoad_Click;
            // 
            // ToolStripMenuItemSave
            // 
            ToolStripMenuItemSave.Name = "ToolStripMenuItemSave";
            ToolStripMenuItemSave.Size = new Size(67, 20);
            ToolStripMenuItemSave.Text = "SaveData";
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
            splitContainer1.Location = new Point(0, 49);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeViewDrive);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listViewDirectory);
            splitContainer1.Size = new Size(800, 379);
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
            treeViewDrive.Size = new Size(266, 379);
            treeViewDrive.TabIndex = 0;
            treeViewDrive.AfterExpand += treeViewDrive_AfterExpand;
            treeViewDrive.AfterSelect += treeViewDrive_AfterSelect;
            // 
            // listViewDirectory
            // 
            listViewDirectory.Activation = ItemActivation.OneClick;
            listViewDirectory.AllowColumnReorder = true;
            listViewDirectory.Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderSize, columnHeaderSha1 });
            listViewDirectory.ContextMenuStrip = contextMenuStripFile;
            listViewDirectory.Dock = DockStyle.Fill;
            listViewDirectory.HotTracking = true;
            listViewDirectory.HoverSelection = true;
            listViewDirectory.Location = new Point(0, 0);
            listViewDirectory.MultiSelect = false;
            listViewDirectory.Name = "listViewDirectory";
            listViewDirectory.Size = new Size(530, 379);
            listViewDirectory.TabIndex = 0;
            listViewDirectory.UseCompatibleStateImageBehavior = false;
            listViewDirectory.View = View.Details;
            listViewDirectory.ColumnClick += listViewDirectory_ColumnClick;
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
            // contextMenuStripFile
            // 
            contextMenuStripFile.Items.AddRange(new ToolStripItem[] { computeHashToolStripMenuItem, filesOfTheSameSizeToolStripMenuItem, openShellToolStripMenuItem });
            contextMenuStripFile.Name = "contextMenuStripFile";
            contextMenuStripFile.Size = new Size(184, 92);
            // 
            // computeHashToolStripMenuItem
            // 
            computeHashToolStripMenuItem.Name = "computeHashToolStripMenuItem";
            computeHashToolStripMenuItem.Size = new Size(183, 22);
            computeHashToolStripMenuItem.Text = "Compute Hash";
            computeHashToolStripMenuItem.Click += computeHashToolStripMenuItem_Click;
            // 
            // filesOfTheSameSizeToolStripMenuItem
            // 
            filesOfTheSameSizeToolStripMenuItem.Name = "filesOfTheSameSizeToolStripMenuItem";
            filesOfTheSameSizeToolStripMenuItem.Size = new Size(183, 22);
            filesOfTheSameSizeToolStripMenuItem.Text = "Files of the same size";
            filesOfTheSameSizeToolStripMenuItem.Click += filesOfTheSameSizeToolStripMenuItem_Click;
            // 
            // openShellToolStripMenuItem
            // 
            openShellToolStripMenuItem.Name = "openShellToolStripMenuItem";
            openShellToolStripMenuItem.Size = new Size(183, 22);
            openShellToolStripMenuItem.Text = "Open Shell";
            openShellToolStripMenuItem.Click += openShellToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripTextBoxCurrentPath });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(94, 22);
            toolStripLabel1.Text = "CurrentDirectory";
            // 
            // toolStripTextBoxCurrentPath
            // 
            toolStripTextBoxCurrentPath.AutoSize = false;
            toolStripTextBoxCurrentPath.Name = "toolStripTextBoxCurrentPath";
            toolStripTextBoxCurrentPath.ReadOnly = true;
            toolStripTextBoxCurrentPath.Size = new Size(400, 25);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            contextMenuStripFile.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStripTextBoxCurrentPath;
        private ToolStripLabel toolStripLabel1;
        private ContextMenuStrip contextMenuStripFile;
        private ToolStripMenuItem computeHashToolStripMenuItem;
        private ToolStripMenuItem filesOfTheSameSizeToolStripMenuItem;
        private ToolStripMenuItem openShellToolStripMenuItem;
    }
}
