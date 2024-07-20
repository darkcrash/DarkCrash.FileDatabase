using DarkCrash.FileDatabase.Controls;

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
            listViewDirectory = new CustomListView();
            SuspendLayout();
            // 
            // listViewDirectory
            // 
            listViewDirectory.Dock = DockStyle.Fill;
            listViewDirectory.Location = new Point(0, 0);
            listViewDirectory.Name = "listViewDirectory";
            listViewDirectory.Size = new Size(800, 450);
            listViewDirectory.TabIndex = 1;
            listViewDirectory.UseCompatibleStateImageBehavior = false;
            listViewDirectory.View = View.Details;
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
            ResumeLayout(false);
        }

        #endregion

        private CustomListView listViewDirectory;
    }
}