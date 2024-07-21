namespace DarkCrash.FileDatabase.Controls
{
    partial class CustomTreeView
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
            contextMenuStrip = new ContextMenuStrip(components);
            toolStripMenuItemCreateRecursive = new ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemCreateRecursive });
            contextMenuStrip.Name = "contextMenuStripCreateRecursive";
            contextMenuStrip.Size = new Size(181, 26);
            // 
            // toolStripMenuItemCreateRecursive
            // 
            toolStripMenuItemCreateRecursive.Name = "toolStripMenuItemCreateRecursive";
            toolStripMenuItemCreateRecursive.Size = new Size(180, 22);
            toolStripMenuItemCreateRecursive.Text = "Fetch File Recursive ";
            toolStripMenuItemCreateRecursive.Click += toolStripMenuItemCreateRecursive_Click;
            // 
            // CustomTreeView
            // 
            ContextMenuStrip = contextMenuStrip;
            LineColor = Color.Black;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem toolStripMenuItemCreateRecursive;
    }
}
