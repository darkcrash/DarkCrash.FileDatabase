namespace DarkCrash.FileDatabase
{
    partial class DuplicateFilesForm
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
            components = new System.ComponentModel.Container();
            listViewDirectory = new ListView();
            columnHeaderFullPath = new ColumnHeader();
            columnHeaderSize = new ColumnHeader();
            columnHeaderSha1 = new ColumnHeader();
            contextMenuStripFile = new ContextMenuStrip(components);
            openShellToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            computeHashToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStripFile.SuspendLayout();
            SuspendLayout();
            // 
            // listViewDirectory
            // 
            listViewDirectory.Columns.AddRange(new ColumnHeader[] { columnHeaderFullPath, columnHeaderSize, columnHeaderSha1 });
            listViewDirectory.ContextMenuStrip = contextMenuStripFile;
            listViewDirectory.Dock = DockStyle.Fill;
            listViewDirectory.Location = new Point(0, 0);
            listViewDirectory.Name = "listViewDirectory";
            listViewDirectory.Size = new Size(800, 450);
            listViewDirectory.TabIndex = 1;
            listViewDirectory.UseCompatibleStateImageBehavior = false;
            listViewDirectory.View = View.Details;
            // 
            // columnHeaderFullPath
            // 
            columnHeaderFullPath.Text = "FullPath";
            columnHeaderFullPath.Width = 240;
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
            contextMenuStripFile.Items.AddRange(new ToolStripItem[] { openShellToolStripMenuItem, toolStripSeparator1, computeHashToolStripMenuItem });
            contextMenuStripFile.Name = "contextMenuStripFile";
            contextMenuStripFile.Size = new Size(181, 76);
            // 
            // openShellToolStripMenuItem
            // 
            openShellToolStripMenuItem.Name = "openShellToolStripMenuItem";
            openShellToolStripMenuItem.Size = new Size(180, 22);
            openShellToolStripMenuItem.Text = "Open Shell";
            openShellToolStripMenuItem.Click += openShellToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // computeHashToolStripMenuItem
            // 
            computeHashToolStripMenuItem.Name = "computeHashToolStripMenuItem";
            computeHashToolStripMenuItem.Size = new Size(180, 22);
            computeHashToolStripMenuItem.Text = "Compute Hash";
            computeHashToolStripMenuItem.Click += computeHashToolStripMenuItem_Click;
            // 
            // DuplicateFilesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listViewDirectory);
            Name = "DuplicateFilesForm";
            Text = "DuplicateFilesForm";
            Load += DuplicateFilesForm_Load;
            contextMenuStripFile.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewDirectory;
        private ColumnHeader columnHeaderFullPath;
        private ColumnHeader columnHeaderSize;
        private ColumnHeader columnHeaderSha1;
        private ContextMenuStrip contextMenuStripFile;
        private ToolStripMenuItem computeHashToolStripMenuItem;
        private ToolStripMenuItem openShellToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}