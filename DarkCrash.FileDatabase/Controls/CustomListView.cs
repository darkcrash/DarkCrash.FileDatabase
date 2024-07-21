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

namespace DarkCrash.FileDatabase.Controls
{
    public partial class CustomListView : ListView
    {
        public CustomListView() : base()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void SetItems(DirectoryItem directory, bool fullPath)
        {
            Items.Clear();
            Items.AddRange(
                directory.Files.Select(_ =>
                    {
                        var item = new ListViewItem()
                        {
                            Name = _.Name,
                            Text = (fullPath ? _.FullName : _.Name),
                            Tag = _
                        };
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "size", Text = _.Size.ToString(), Tag = _.Size });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "hash", Text = _.Sha256Text, Tag = _.Sha256Text });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "sscnt", Text = _.SameSizeCount.ToString(), Tag = _.SameSizeCount });
                        return item;
                    }).ToArray()
                );
            SortByColumn();

        }

        public void SetItems(IEnumerable<FileItem> files, bool fullPath)
        {
            Items.Clear();
            Items.AddRange(
                files.Select(_ =>
                {
                    var item = new ListViewItem()
                    {
                        Name = _.Name,
                        Text = (fullPath ? _.FullName : _.Name),
                        Tag = _
                    };
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "size", Text = _.Size.ToString(), Tag = _.Size });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "hash", Text = _.Sha256Text, Tag = _.Sha256Text });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Name = "sscnt", Text = _.SameSizeCount.ToString(), Tag = _.SameSizeCount });
                    return item;
                }).ToArray()
                );
            SortByColumn();

        }


        /// <summary>
        /// click from compute hash menu item 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void computeHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewItems = SelectedItems;
            if (viewItems == null) return;
            foreach (ListViewItem viewItem in viewItems)
            {
                var item = viewItem.Tag as Common.Models.FileItem;
                if (item == null) return;
                var subitem = viewItem.SubItems["hash"];
                if (subitem == null) return;

                subitem.Text = "computing ...";
                await item.ComputeHashAsync();
                subitem.Text = item.Sha256Text;

                //var items = DataService.Instance.GetDuplicateFiles(item);
                //if (items.Count() > 1)
                //{
                //    var form = new DuplicateFilesForm(items);
                //    form.Show(this);
                //}
                //else
                //{
                //    items = DataService.Instance.GetSameSizeFiles(item);
                //    if (items.Count() > 1)
                //    {
                //        var form = new DuplicateFilesForm(items);
                //        form.Show(this);
                //    }
                //}
            }
        }

        private void filesOfTheSameSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewItems = SelectedItems;
            if (viewItems == null) return;
            foreach (ListViewItem viewItem in viewItems)
            {
                var item = viewItem.Tag as Common.Models.FileItem;
                if (item == null) return;
                var items = DataService.Instance.GetSameSizeFiles(item);
                var form = new DuplicateFilesForm(items);
                form.Show(this);
            }
        }

        /// <summary>
        /// click from open shell menu item 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewItem = FocusedItem;
            if (viewItem == null) return;
            var item = viewItem.Tag as Common.Models.FileItem;
            if (item == null) return;
            item.OpenShell();

        }

        private Dictionary<int, bool> ColumnStatus = new Dictionary<int, bool>();
        private int SortColumn = 0;

        private void CustomListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortColumn = e.Column;
            if (!ColumnStatus.ContainsKey(SortColumn))
            {
                ColumnStatus.Add(SortColumn, false);
            }
            ColumnStatus[SortColumn] = !ColumnStatus[SortColumn];

            SortByColumn();


        }

        private void SortByColumn()
        {
            if (!ColumnStatus.ContainsKey(SortColumn))
            {
                ColumnStatus.Add(SortColumn, false);
            }

            // sort key first
            Func<ListViewItem, object> func = (_) =>
            {
                if (SortColumn == 1) return long.Parse(_.SubItems[SortColumn].Text);
                if (SortColumn == 3) return int.Parse(_.SubItems[SortColumn].Text);
                return _.SubItems[SortColumn].Text;
            };

            // sort 2
            Func<ListViewItem, object> func2 = (_) =>
            {
                return long.Parse(_.SubItems[1].Text);
            };

            // sort 3
            Func<ListViewItem, object> func3 = (_) =>
            {
                return _.SubItems[0].Text;
            };

            ListViewItem[] items;

            if (ColumnStatus[SortColumn])
            {
                items = Items.Cast<ListViewItem>().OrderBy(func).ThenByDescending(func2).ThenBy(func3).ToArray();
            }
            else
            {
                items = Items.Cast<ListViewItem>().OrderByDescending(func).ThenByDescending(func2).ThenBy(func3).ToArray();
            }

            Items.Clear();
            Items.AddRange(items);
        }

        private void CustomListView_ItemActivate(object sender, EventArgs e)
        {
            var viewItem = FocusedItem;
            if (viewItem == null) return;
            var item = viewItem.Tag as Common.Models.FileItem;
            if (item == null) return;
            var items = DataService.Instance.GetSameSizeFiles(item);
            var form = new DuplicateFilesForm(items);
            form.Show(this);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var viewItems = SelectedItems;
            if (viewItems == null) return;
            foreach (ListViewItem viewItem in viewItems)
            {
                var item = viewItem.Tag as Common.Models.FileItem;
                if (item == null) return;

                if (item.Trash())
                {
                    Items.Remove(viewItem);
                }


            }
        }
    }
}
