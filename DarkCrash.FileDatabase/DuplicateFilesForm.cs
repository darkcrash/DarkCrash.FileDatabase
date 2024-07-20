using DarkCrash.FileDatabase.Common.Models;
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

namespace DarkCrash.FileDatabase
{
    /// <summary>
    /// duplicate files form
    /// </summary>
    public partial class DuplicateFilesForm : Form
    {
        /// <summary>
        /// duplicate files
        /// </summary>
        public IEnumerable<FileItem> DuplicateFilesItems { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="items"></param>
        public DuplicateFilesForm(IEnumerable<FileItem> items)
        {
            DuplicateFilesItems = items;
            InitializeComponent();
        }

        /// <summary>
        /// load event,
        /// set to items of ListView
        /// </summary>
        private void DuplicateFilesForm_Load(object sender, EventArgs e)
        {
            listViewDirectory.Items.AddRange(DuplicateFilesItems.Select(_ =>
            {
                var item = new ListViewItem()
                {
                    Name = _.Name,
                    Text = _.FullName,
                    Tag = _
                };
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "size", Text = _.Size.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "hash", Text = _.Sha1Text });
                return item;
            }).ToArray());
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
