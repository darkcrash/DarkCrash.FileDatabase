namespace DarkCrash.FileDatabase.Controls
{
    partial class CustomListView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            imageList = new ImageList(components);
            columnHeaderName = new ColumnHeader();
            columnHeaderSize = new ColumnHeader();
            columnHeaderSha256 = new ColumnHeader();
            contextMenuStripFile = new ContextMenuStrip(components);
            openShellToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            computeHashToolStripMenuItem = new ToolStripMenuItem();
            filesOfTheSameSizeToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            columnHeaderSameSizeCount = new ColumnHeader();
            contextMenuStripFile.SuspendLayout();
            SuspendLayout();
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
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
            // columnHeaderSha256
            // 
            columnHeaderSha256.Text = "SHA2-256";
            columnHeaderSha256.Width = 240;
            // 
            // contextMenuStripFile
            // 
            contextMenuStripFile.Items.AddRange(new ToolStripItem[] { openShellToolStripMenuItem, toolStripSeparator1, computeHashToolStripMenuItem, filesOfTheSameSizeToolStripMenuItem, toolStripSeparator2, deleteToolStripMenuItem });
            contextMenuStripFile.Name = "contextMenuStripFile";
            contextMenuStripFile.Size = new Size(184, 104);
            // 
            // openShellToolStripMenuItem
            // 
            openShellToolStripMenuItem.Name = "openShellToolStripMenuItem";
            openShellToolStripMenuItem.Size = new Size(183, 22);
            openShellToolStripMenuItem.Text = "Open Shell";
            openShellToolStripMenuItem.Click += openShellToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(180, 6);
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
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(180, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(183, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // columnHeaderSameSizeCount
            // 
            columnHeaderSameSizeCount.Text = "SameSizeCount";
            // 
            // CustomListView
            // 
            Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderSize, columnHeaderSha256, columnHeaderSameSizeCount });
            ContextMenuStrip = contextMenuStripFile;
            View = View.Details;
            ColumnClick += CustomListView_ColumnClick;
            ItemActivate += CustomListView_ItemActivate;
            contextMenuStripFile.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderSize;
        private ColumnHeader columnHeaderSha256;
        private ContextMenuStrip contextMenuStripFile;
        private ToolStripMenuItem openShellToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem computeHashToolStripMenuItem;
        private ToolStripMenuItem filesOfTheSameSizeToolStripMenuItem;
        private ColumnHeader columnHeaderSameSizeCount;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}
