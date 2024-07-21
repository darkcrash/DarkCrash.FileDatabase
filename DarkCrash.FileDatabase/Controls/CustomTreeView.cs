using DarkCrash.FileDatabase.Common.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkCrash.FileDatabase.Controls
{
    public partial class CustomTreeView : TreeView
    {
        [ThreadStatic]
        private static StringBuilder sb = new StringBuilder();


        public CustomTreeView() : base()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private string GetPath(TreeNode node)
        {
            if (node == null) return string.Empty;
            var p = node;
            sb.Clear();
            while (true)
            {
                if (p.Parent == null) { break; }
                sb.Insert(0, p.Text);
                p = p.Parent;
                if (p.Parent != null)
                {
                    sb.Insert(0, "\\");
                }
            }
            return sb.ToString();
        }

        private void toolStripMenuItemCreateRecursive_Click(object sender, EventArgs e)
        {
            var nodeTarget = SelectedNode;
            if (nodeTarget == null) return;
            var path = GetPath(nodeTarget);
            if (!System.IO.Directory.Exists(path)) return;
            ItemFactoryService.Instance.CreateRecursiveDirectoryItemsWithoutHash(path);
        }
    }
}
