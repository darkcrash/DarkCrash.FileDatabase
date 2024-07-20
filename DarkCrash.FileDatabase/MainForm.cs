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
            listViewDirectory.Items.Clear();
            listViewDirectory.Items.AddRange(
                result.Files.Select(_ =>
                {
                    var item = new ListViewItem()
                    {
                        Name = _.Name,
                        Text = _.Name,
                        Tag = _
                    };
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "size", Text = _.Size.ToString(), Tag = _.Size });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "hash", Text = _.Sha1Text, Tag = _.Sha1Text });
                    return item;
                }).ToArray()
                );

        }

        private async void ToolStripMenuItemLoad_Click(object sender, EventArgs e)
        {
            await DataService.Instance.LoadAsync();

        }

        private async void ToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            await DataService.Instance.SaveAsync();
        }

        private void listViewDirectory_ItemActivate(object sender, EventArgs e)
        {
            var viewItem = listViewDirectory.FocusedItem;
            if (viewItem == null) return;
            var item = viewItem.Tag as Common.Models.FileItem;
            if (item == null) return;
            var items = DataService.Instance.GetSameSizeFiles(item);
            var form = new DuplicateFilesForm(items);
            form.Show(this);

        }

        private Dictionary<int, bool> ColumnStatus = new Dictionary<int, bool>();

        private void listViewDirectory_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!ColumnStatus.ContainsKey(e.Column))
            {
                ColumnStatus.Add(e.Column, true);
            }

            Func<ListViewItem, object> func = (_) =>
            {
                if (e.Column == 1) return long.Parse(_.SubItems[e.Column].Text);
                return _.SubItems[e.Column].Text;
            };

            ListViewItem[] items;

            if (ColumnStatus[e.Column])
            {
                items = listViewDirectory.Items.Cast<ListViewItem>().OrderBy(func).ToArray();
            }
            else
            {
                items = listViewDirectory.Items.Cast<ListViewItem>().OrderByDescending(func).ToArray();
            }
            ColumnStatus[e.Column] = !ColumnStatus[e.Column];

            listViewDirectory.Items.Clear();
            listViewDirectory.Items.AddRange(items);
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

        private async void computeHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewItem = listViewDirectory.FocusedItem;
            if (viewItem == null) return;
            var item = viewItem.Tag as Common.Models.FileItem;
            if (item == null) return;
            var subitem = viewItem.SubItems["hash"];
            if (subitem == null) return;

            await item.ComputeHashAsync();
            subitem.Text = item.Sha1Text;

            var items = DataService.Instance.GetDuplicateFiles(item);
            if (items.Count() > 1)
            {
                var form = new DuplicateFilesForm(items);
                form.Show(this);
            }
            else
            {
                items = DataService.Instance.GetSameSizeFiles(item);
                if (items.Count() > 1)
                {
                    var form = new DuplicateFilesForm(items);
                    form.Show(this);
                }
            }
        }

        private void filesOfTheSameSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewItem = listViewDirectory.FocusedItem;
            if (viewItem == null) return;
            var item = viewItem.Tag as Common.Models.FileItem;
            if (item == null) return;
            var items = DataService.Instance.GetSameSizeFiles(item);
            var form = new DuplicateFilesForm(items);
            form.Show(this);
        }

        private void openShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewItem = listViewDirectory.FocusedItem;
            if (viewItem == null) return;
            var item = viewItem.Tag as Common.Models.FileItem;
            if (item == null) return;
            item.OpenShell();

        }
    }
}
