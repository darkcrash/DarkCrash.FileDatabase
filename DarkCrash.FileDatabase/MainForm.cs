using DarkCrash.FileDatabase.Common.Services;

namespace DarkCrash.FileDatabase
{
    public partial class MainForm : Form
    {
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

        private async void treeViewDrive_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node == null) return;
            if (!System.IO.Directory.Exists(node.Text)) return;
            var factory = Common.Services.ItemFactoryService.Instance;
            var result = await factory.CreateDirectoryItemsWithoutHash(node.Text);
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
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name= "size",  Text = _.Size.ToString() });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "hash",  Text = _.Sha1Text });
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

        private async void listViewDirectory_ItemActivate(object sender, EventArgs e)
        {
            var viewItem = listViewDirectory.FocusedItem;
            if (viewItem == null) return;
            var item = viewItem.Tag as Common.Models.FileItem;
            if (item == null) return;
            var subitem = viewItem.SubItems["hash"];
            if (subitem == null) return;

            await item.ComputeHashAsync();
            DataService.Instance.SaveItem(item);
            subitem.Text = item.Sha1Text;



        }
    }
}
