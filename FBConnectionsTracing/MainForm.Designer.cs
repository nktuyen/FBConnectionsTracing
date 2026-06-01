namespace FBConnectionsTracing
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblFollowed = new System.Windows.Forms.Label();
            this.txtFollowedFile = new System.Windows.Forms.TextBox();
            this.lblMyFollowers = new System.Windows.Forms.Label();
            this.txtMyFollowers = new System.Windows.Forms.TextBox();
            this.btnFollowedFileBrowse = new System.Windows.Forms.Button();
            this.btnMyFollowersBrowse = new System.Windows.Forms.Button();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.txtEndIndex = new System.Windows.Forms.MaskedTextBox();
            this.txtStartIndex = new System.Windows.Forms.MaskedTextBox();
            this.chbHighlightNonFollowed = new System.Windows.Forms.CheckBox();
            this.chbEndIndex = new System.Windows.Forms.CheckBox();
            this.chbStartIndex = new System.Windows.Forms.CheckBox();
            this.chbShowFollowed = new System.Windows.Forms.CheckBox();
            this.ListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyNameContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblList = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExportList = new System.Windows.Forms.Button();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.lvReport = new FBConnectionsTracing.OwnerDrawListView();
            this.colNb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpOptions.SuspendLayout();
            this.ListViewContextMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFollowed
            // 
            this.lblFollowed.AutoSize = true;
            this.lblFollowed.Location = new System.Drawing.Point(13, 28);
            this.lblFollowed.Name = "lblFollowed";
            this.lblFollowed.Size = new System.Drawing.Size(133, 13);
            this.lblFollowed.TabIndex = 0;
            this.lblFollowed.Text = "Những người bạn theo dõi:";
            // 
            // txtFollowedFile
            // 
            this.txtFollowedFile.Location = new System.Drawing.Point(152, 25);
            this.txtFollowedFile.Name = "txtFollowedFile";
            this.txtFollowedFile.Size = new System.Drawing.Size(768, 20);
            this.txtFollowedFile.TabIndex = 0;
            this.txtFollowedFile.TextChanged += new System.EventHandler(this.txtFollowedFile_TextChanged);
            // 
            // lblMyFollowers
            // 
            this.lblMyFollowers.AutoSize = true;
            this.lblMyFollowers.Location = new System.Drawing.Point(13, 54);
            this.lblMyFollowers.Name = "lblMyFollowers";
            this.lblMyFollowers.Size = new System.Drawing.Size(133, 13);
            this.lblMyFollowers.TabIndex = 2;
            this.lblMyFollowers.Text = "Những người theo dõi bạn:";
            // 
            // txtMyFollowers
            // 
            this.txtMyFollowers.Location = new System.Drawing.Point(152, 51);
            this.txtMyFollowers.Name = "txtMyFollowers";
            this.txtMyFollowers.Size = new System.Drawing.Size(768, 20);
            this.txtMyFollowers.TabIndex = 2;
            this.txtMyFollowers.TextChanged += new System.EventHandler(this.txtMyFollowers_TextChanged);
            // 
            // btnFollowedFileBrowse
            // 
            this.btnFollowedFileBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFollowedFileBrowse.Location = new System.Drawing.Point(926, 23);
            this.btnFollowedFileBrowse.Name = "btnFollowedFileBrowse";
            this.btnFollowedFileBrowse.Size = new System.Drawing.Size(100, 23);
            this.btnFollowedFileBrowse.TabIndex = 1;
            this.btnFollowedFileBrowse.Text = "&Chọn";
            this.btnFollowedFileBrowse.UseVisualStyleBackColor = true;
            this.btnFollowedFileBrowse.Click += new System.EventHandler(this.btnFollowedFileBrowse_Click);
            // 
            // btnMyFollowersBrowse
            // 
            this.btnMyFollowersBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyFollowersBrowse.Location = new System.Drawing.Point(926, 51);
            this.btnMyFollowersBrowse.Name = "btnMyFollowersBrowse";
            this.btnMyFollowersBrowse.Size = new System.Drawing.Size(100, 23);
            this.btnMyFollowersBrowse.TabIndex = 3;
            this.btnMyFollowersBrowse.Text = "&Chọn";
            this.btnMyFollowersBrowse.UseVisualStyleBackColor = true;
            this.btnMyFollowersBrowse.Click += new System.EventHandler(this.btnMyFollowersBrowse_Click);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.txtEndIndex);
            this.grpOptions.Controls.Add(this.txtStartIndex);
            this.grpOptions.Controls.Add(this.chbHighlightNonFollowed);
            this.grpOptions.Controls.Add(this.chbEndIndex);
            this.grpOptions.Controls.Add(this.chbStartIndex);
            this.grpOptions.Controls.Add(this.chbShowFollowed);
            this.grpOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOptions.Location = new System.Drawing.Point(152, 78);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(768, 79);
            this.grpOptions.TabIndex = 4;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Tùy chọn";
            // 
            // txtEndIndex
            // 
            this.txtEndIndex.Enabled = false;
            this.txtEndIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndIndex.Location = new System.Drawing.Point(649, 45);
            this.txtEndIndex.Mask = "0000000";
            this.txtEndIndex.Name = "txtEndIndex";
            this.txtEndIndex.Size = new System.Drawing.Size(64, 20);
            this.txtEndIndex.TabIndex = 9;
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Enabled = false;
            this.txtStartIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartIndex.Location = new System.Drawing.Point(649, 22);
            this.txtStartIndex.Mask = "0000000";
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(64, 20);
            this.txtStartIndex.TabIndex = 7;
            // 
            // chbHighlightNonFollowed
            // 
            this.chbHighlightNonFollowed.AutoSize = true;
            this.chbHighlightNonFollowed.Checked = true;
            this.chbHighlightNonFollowed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbHighlightNonFollowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHighlightNonFollowed.Location = new System.Drawing.Point(38, 48);
            this.chbHighlightNonFollowed.Name = "chbHighlightNonFollowed";
            this.chbHighlightNonFollowed.Size = new System.Drawing.Size(193, 17);
            this.chbHighlightNonFollowed.TabIndex = 5;
            this.chbHighlightNonFollowed.Text = "&Bôi đỏ những người không theo dõi";
            this.chbHighlightNonFollowed.UseVisualStyleBackColor = true;
            // 
            // chbEndIndex
            // 
            this.chbEndIndex.AutoSize = true;
            this.chbEndIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEndIndex.Location = new System.Drawing.Point(425, 48);
            this.chbEndIndex.Name = "chbEndIndex";
            this.chbEndIndex.Size = new System.Drawing.Size(178, 17);
            this.chbEndIndex.TabIndex = 8;
            this.chbEndIndex.Text = "Cho đến người có số thứ &tự sau:";
            this.chbEndIndex.UseVisualStyleBackColor = true;
            this.chbEndIndex.CheckedChanged += new System.EventHandler(this.chbEndIndex_CheckedChanged);
            // 
            // chbStartIndex
            // 
            this.chbStartIndex.AutoSize = true;
            this.chbStartIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbStartIndex.Location = new System.Drawing.Point(425, 25);
            this.chbStartIndex.Name = "chbStartIndex";
            this.chbStartIndex.Size = new System.Drawing.Size(225, 17);
            this.chbStartIndex.TabIndex = 6;
            this.chbStartIndex.Text = "Hiển thị bắt đầu từ người có số thứ tự &sau:";
            this.chbStartIndex.UseVisualStyleBackColor = true;
            this.chbStartIndex.CheckedChanged += new System.EventHandler(this.chbStartIndex_CheckedChanged);
            // 
            // chbShowFollowed
            // 
            this.chbShowFollowed.AutoSize = true;
            this.chbShowFollowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowFollowed.Location = new System.Drawing.Point(38, 25);
            this.chbShowFollowed.Name = "chbShowFollowed";
            this.chbShowFollowed.Size = new System.Drawing.Size(208, 17);
            this.chbShowFollowed.TabIndex = 4;
            this.chbShowFollowed.Text = "&Hiển thị cả những người đang theo dõi";
            this.chbShowFollowed.UseVisualStyleBackColor = true;
            // 
            // ListViewContextMenu
            // 
            this.ListViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyNameContextMenuItem});
            this.ListViewContextMenu.Name = "ListViewContextMenu";
            this.ListViewContextMenu.Size = new System.Drawing.Size(123, 26);
            this.ListViewContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ListViewContextMenu_Opening);
            // 
            // copyNameContextMenuItem
            // 
            this.copyNameContextMenuItem.Name = "copyNameContextMenuItem";
            this.copyNameContextMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyNameContextMenuItem.Text = "Sao chép";
            this.copyNameContextMenuItem.Click += new System.EventHandler(this.copyNameContextMenuItem_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText,
            this.StatusProgress});
            this.StatusBar.Location = new System.Drawing.Point(0, 555);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1031, 22);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.TabIndex = 6;
            // 
            // StatusText
            // 
            this.StatusText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StatusText.Name = "StatusText";
            this.StatusText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.StatusText.Size = new System.Drawing.Size(1016, 17);
            this.StatusText.Spring = true;
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusProgress
            // 
            this.StatusProgress.Name = "StatusProgress";
            this.StatusProgress.Size = new System.Drawing.Size(80, 16);
            this.StatusProgress.Visible = false;
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Location = new System.Drawing.Point(84, 163);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(62, 13);
            this.lblList.TabIndex = 7;
            this.lblList.Text = "Danh sách:";
            // 
            // btnReport
            // 
            this.btnReport.Enabled = false;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(926, 163);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 66);
            this.btnReport.TabIndex = 10;
            this.btnReport.Text = "&BÁO CÁO";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnExportList
            // 
            this.btnExportList.Enabled = false;
            this.btnExportList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportList.Location = new System.Drawing.Point(926, 484);
            this.btnExportList.Name = "btnExportList";
            this.btnExportList.Size = new System.Drawing.Size(100, 68);
            this.btnExportList.TabIndex = 11;
            this.btnExportList.Text = "&XUẤT RA TỆP";
            this.btnExportList.UseVisualStyleBackColor = true;
            this.btnExportList.Click += new System.EventHandler(this.btnExportList_Click);
            // 
            // bgw
            // 
            this.bgw.WorkerReportsProgress = true;
            this.bgw.WorkerSupportsCancellation = true;
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // lvReport
            // 
            this.lvReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNb,
            this.colName,
            this.colDesc});
            this.lvReport.ContextMenuStrip = this.ListViewContextMenu;
            this.lvReport.FullRowSelect = true;
            this.lvReport.GridLines = true;
            this.lvReport.HideSelection = false;
            this.lvReport.Location = new System.Drawing.Point(152, 163);
            this.lvReport.MultiSelect = false;
            this.lvReport.Name = "lvReport";
            this.lvReport.OwnerDraw = true;
            this.lvReport.ShowGroups = false;
            this.lvReport.ShowItemToolTips = true;
            this.lvReport.Size = new System.Drawing.Size(768, 389);
            this.lvReport.TabIndex = 5;
            this.lvReport.UseCompatibleStateImageBehavior = false;
            this.lvReport.View = System.Windows.Forms.View.Details;
            this.lvReport.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvReport_DrawColumnHeader);
            this.lvReport.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvReport_DrawItem);
            this.lvReport.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvReport_DrawSubItem);
            this.lvReport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvReport_MouseClick);
            // 
            // colNb
            // 
            this.colNb.Text = "#";
            // 
            // colName
            // 
            this.colName.Text = "Tên";
            this.colName.Width = 500;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Ghi chú";
            this.colDesc.Width = 180;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 577);
            this.Controls.Add(this.btnExportList);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.lvReport);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.btnMyFollowersBrowse);
            this.Controls.Add(this.btnFollowedFileBrowse);
            this.Controls.Add(this.lblMyFollowers);
            this.Controls.Add(this.txtMyFollowers);
            this.Controls.Add(this.txtFollowedFile);
            this.Controls.Add(this.lblFollowed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ListViewContextMenu.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFollowed;
        private System.Windows.Forms.TextBox txtFollowedFile;
        private System.Windows.Forms.Label lblMyFollowers;
        private System.Windows.Forms.TextBox txtMyFollowers;
        private System.Windows.Forms.Button btnFollowedFileBrowse;
        private System.Windows.Forms.Button btnMyFollowersBrowse;
        private System.Windows.Forms.GroupBox grpOptions;
        private OwnerDrawListView lvReport;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolStripProgressBar StatusProgress;
        private System.Windows.Forms.ColumnHeader colNb;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.CheckBox chbShowFollowed;
        private System.Windows.Forms.CheckBox chbHighlightNonFollowed;
        private System.Windows.Forms.CheckBox chbStartIndex;
        private System.Windows.Forms.MaskedTextBox txtStartIndex;
        private System.Windows.Forms.MaskedTextBox txtEndIndex;
        private System.Windows.Forms.CheckBox chbEndIndex;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExportList;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.ContextMenuStrip ListViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyNameContextMenuItem;
    }
}

