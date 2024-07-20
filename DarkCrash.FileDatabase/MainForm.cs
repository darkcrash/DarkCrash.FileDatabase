using DarkCrash.FileDatabase.Controls;
using DarkCrash.FileDatabase.Common.Services;
using System.Linq;
using System.Text;

namespace DarkCrash.FileDatabase
{
    public partial class MainForm : Form
    {
        [ThreadStatic]
        private static StringBuilder sb = new StringBuilder();


        public MainForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await DataService.Instance.LoadAsync();

            LoadNode();


        }

        private void LoadNode()
        {
            treeViewDrive.Nodes.Clear();
            var root = new TreeNode(System.Environment.MachineName);
            treeViewDrive.Nodes.Add(root);
            var drives = System.Environment.GetLogicalDrives();
            root.Nodes.AddRange(drives.Select(_ => new TreeNode(_)).ToArray());
            root.Expand();

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
        private void treeViewDrive_AfterExpand(object sender, TreeViewEventArgs e)
        {
            var nodeTarget = e.Node;
            if (nodeTarget == null) return;
            foreach (TreeNode node in nodeTarget.Nodes)
            {
                if (node == null) return;
                var path = GetPath(node);
                if (!System.IO.Directory.Exists(path)) return;
                try
                {
                    var directories = System.IO.Directory.GetDirectories(path);
                    node.Nodes.AddRange(directories.Select(_ => new TreeNode(System.IO.Path.GetFileName(_))).ToArray());
                }
                catch (System.UnauthorizedAccessException) { continue; }
            }
        }

        private void treeViewDrive_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node == null) return;
            var path = GetPath(node);
            if (!System.IO.Directory.Exists(path)) return;
            toolStripTextBoxCurrentPath.Text = path;
            var factory = Common.Services.ItemFactoryService.Instance;
            var result = factory.CreateDirectoryItemsWithoutHash(path);
            listViewDirectory.SetItems(result, false);

        }

        private async void ToolStripMenuItemLoad_Click(object sender, EventArgs e)
        {
            await DataService.Instance.LoadAsync();

        }

        private async void ToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            await DataService.Instance.SaveAsync();
        }

        private bool closed = false;
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closed == false)
            {
                e.Cancel = true;
                this.Enabled = false;
                await DataService.Instance.SaveAsync();
                closed = true;
                this.Close();
            }
        }

    }
}
