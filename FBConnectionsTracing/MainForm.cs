using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Linq;
using System.Diagnostics;
using System.Web;

namespace FBConnectionsTracing
{
    public partial class MainForm : Form
    {
        private Dictionary<Control, bool> ControlEnabledState { get; set; }
        private int StartIndex { get; set; }
        private int EndIndex { get; set; }
        private string FollowedFile { get; set; }
        private string FollowerFile { get; set; }
        private bool IncludeFollowed { get; set; }
        private bool HighlightNonFollowers { get; set; }


        public MainForm()
        {
            InitializeComponent();
            this.ControlEnabledState = new Dictionary<Control, bool>();
        }

        private void SetControlEnabledState(Control ctrl, bool enabled)
        {
            this.ControlEnabledState[ctrl] = ctrl.Enabled;
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new MethodInvoker(delegate
                {
                    ctrl.Enabled = enabled;
                }));
            }
            else
            {
                ctrl.Enabled = enabled;
            }
        }

        private void RestoreControlEnabledState(Control ctrl)
        {
            if (this.ControlEnabledState.ContainsKey(ctrl))
            {
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(new MethodInvoker(delegate
                    {
                        ctrl.Enabled = this.ControlEnabledState[ctrl];
                    }));
                }
                else
                {
                    ctrl.Enabled = this.ControlEnabledState[ctrl];
                }
            }
        }

        private bool ValidateInput()
        {
            if (txtFollowedFile.TextLength <= 0)
            {
                MessageBox.Show("Vui lòng chọn tệp chứa những người theo dõi bạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFollowedFile.Focus();
                return false;
            }

            if (!System.IO.File.Exists(txtFollowedFile.Text))
            {
                MessageBox.Show(string.Format("Tệp {0} không tồn tại hoặc không thể truy cập!", txtFollowedFile.Text), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFollowedFile.Focus();
                return false;
            }

            if (txtMyFollowers.TextLength <= 0)
            {
                MessageBox.Show("Vui lòng chọn tệp chứa danh sách những người bạn đang theo dõi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMyFollowers.Focus();
                return false;
            }

            if (!System.IO.File.Exists(txtMyFollowers.Text))
            {
                MessageBox.Show(string.Format("Tệp {0} không tồn tại hoặc không thể truy cập!", txtMyFollowers.Text), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMyFollowers.Focus();
                return false;
            }

            this.StartIndex = 0;
            this.EndIndex = 0;
            if (chbStartIndex.Checked)
            {
                this.StartIndex = int.Parse(txtStartIndex.Text);
            }
            if (chbEndIndex.Checked)
            {
                this.EndIndex = int.Parse(txtEndIndex.Text);
            }

            if (this.EndIndex > 0)
            {
                if (this.EndIndex < this.StartIndex)
                {
                    MessageBox.Show("Số thứ tự người kết thúc phải lớn hơn hoặc bằng số thứ tự người bắt đầu!", string.Format("Lỗi {0} < {1}", this.EndIndex, this.StartIndex), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEndIndex.Focus();
                    return false;
                }
            }

            this.FollowedFile = txtFollowedFile.Text;
            this.FollowerFile = txtMyFollowers.Text;
            this.IncludeFollowed = chbShowFollowed.Checked;
            this.HighlightNonFollowers = chbHighlightNonFollowed.Checked;

            return true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} v{1} - Công cụ báo cáo danh sách những người không theo dõi mình trên Facebook - © 2026 Đô Tin Học(dotinhoc198)", ProductName, ProductVersion);
        }

        private void chbStartIndex_CheckedChanged(object sender, EventArgs e)
        {
            txtStartIndex.Enabled = chbStartIndex.Checked;
            if (chbStartIndex.Checked)
            {
                txtStartIndex.Focus();
                txtStartIndex.SelectAll();
            }
        }

        private void chbEndIndex_CheckedChanged(object sender, EventArgs e)
        {
            txtEndIndex.Enabled = chbEndIndex.Checked;
            if (chbEndIndex.Checked)
            {
                txtEndIndex.Focus();
                txtEndIndex.SelectAll();
            }
        }

        private void txtFollowedFile_TextChanged(object sender, EventArgs e)
        {
            btnReport.Enabled = (txtFollowedFile.TextLength > 0) && (txtMyFollowers.TextLength > 0);
        }

        private void txtMyFollowers_TextChanged(object sender, EventArgs e)
        {
            btnReport.Enabled = (txtFollowedFile.TextLength > 0) && (txtMyFollowers.TextLength > 0);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (btnReport.Tag != null)
            {
                if (bgw.IsBusy)
                    bgw.CancelAsync();
                return;
            }

            if (!ValidateInput())
                return;

            if (bgw.IsBusy)
                bgw.CancelAsync();

            bgw.RunWorkerAsync();
        }

        private void bgw_PreDoWork(object sender, DoWorkEventArgs e)
        {
            SetControlEnabledState(txtFollowedFile, false);
            SetControlEnabledState(txtMyFollowers, false);
            SetControlEnabledState(btnFollowedFileBrowse, false);
            SetControlEnabledState(btnMyFollowersBrowse, false);
            SetControlEnabledState(grpOptions, false);
            //SetControlEnabledState(btnReport, false);
            SetControlEnabledState(btnExportList, false);

            if (StatusBar.InvokeRequired)
            {
                StatusBar.Invoke(new MethodInvoker(delegate
                {
                    StatusText.Text = string.Empty;
                    StatusProgress.Value = 0;
                    StatusProgress.Visible = true;
                }));
                
            }
            else
            {
                StatusText.Text = string.Empty;
                StatusProgress.Value = 0;
                StatusProgress.Visible = true;
            }

            if (btnReport.InvokeRequired)
            {
                btnReport.Invoke(new MethodInvoker(delegate
                {
                    btnReport.Tag = bgw;
                    btnReport.Text = "&DỪNG";
                }));
            }
            else
            {
                btnReport.Tag = bgw;
                btnReport.Text = "&DỪNG";
            }

            if (lvReport.InvokeRequired)
            {
                lvReport.Invoke(new MethodInvoker(delegate
                {
                    lvReport.Items.Clear();
                }));
            }
            else
            {
                lvReport.Items.Clear();
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            bgw_PreDoWork(sender, e);
            Dictionary<string, int> followed_peoples = new Dictionary<string, int>();
            Dictionary<string, int> followers_peoples = new Dictionary<string, int>();

            //Những người bạn theo dõi
            HtmlAgilityPack.HtmlDocument followedHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            followedHtmlDoc.Load(this.FollowedFile, Encoding.UTF8);
            HtmlAgilityPack.HtmlNodeCollection followedHtmlNodes = followedHtmlDoc.DocumentNode.SelectNodes("//h2[@class='_2ph_ _a6-h _a6-i']");

            //Những người theo dõi bạn
            HtmlAgilityPack.HtmlDocument followersHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            followersHtmlDoc.Load(this.FollowerFile, Encoding.UTF8);
            HtmlAgilityPack.HtmlNodeCollection followersHtmlNodes = followersHtmlDoc.DocumentNode.SelectNodes("//h2[@class='_2ph_ _a6-h']");

            int total_persons = 0;
            if (followedHtmlNodes != null)
                total_persons += followedHtmlNodes.Count;
            if (followersHtmlNodes != null)
                total_persons += followersHtmlNodes.Count;

            int loaded_persons = 0;

            // Duyệt những người bạn theo dõi
            if (followedHtmlNodes != null)
            {
                string name = string.Empty;
                foreach (HtmlAgilityPack.HtmlNode node in followedHtmlNodes)
                {
                    name = System.Web.HttpUtility.HtmlDecode(node.InnerText);
                    if (followed_peoples.ContainsKey(name))
                        followed_peoples[name]++;
                    else
                        followed_peoples[name] = 1;

                    loaded_persons++;
                    bgw.ReportProgress((int)((float)loaded_persons / (float)total_persons * 50.0));
                }
            }

            //Duyệt những người theo dõi bạn
            if (followersHtmlNodes != null)
            {
                string name = string.Empty;
                foreach (HtmlAgilityPack.HtmlNode node in followersHtmlNodes)
                {
                    name = System.Web.HttpUtility.HtmlDecode(node.InnerText);
                    if (followers_peoples.ContainsKey(name))
                        followers_peoples[name]++;
                    else
                        followers_peoples[name] = 1;

                    loaded_persons++;
                    bgw.ReportProgress((int)((float)loaded_persons / (float)total_persons * 50.0));
                }
            }

            //Tạo report
            int index = 0;
            int start_index = 0;
            int end_index = 0;

            if (this.StartIndex == 0)
                start_index = 1;
            else
                start_index = this.StartIndex;

            if (this.EndIndex == 0)
                end_index = total_persons;
            else
                end_index = this.EndIndex;

            int progress_range = 25;
            int completed_progress = 50;
            if (this.IncludeFollowed)
            {
                loaded_persons = 0;
                foreach (string name in followed_peoples.Keys)
                {
                    if (followers_peoples.ContainsKey(name))
                    {
                        index++;
                        if ((index >= start_index) && (index <= end_index))
                        {
                            if (lvReport.InvokeRequired)
                            {
                                lvReport.Invoke(new MethodInvoker(delegate
                                {
                                    ListViewItem item = lvReport.Items.Add(index.ToString());
                                    item.SubItems.Add(name);
                                    item.SubItems.Add("Đang theo dõi bạn");
                                }));
                            }
                            else
                            {
                                ListViewItem item = lvReport.Items.Add(index.ToString());
                                item.SubItems.Add(name);
                                item.SubItems.Add("Đang theo dõi bạn");
                            }
                        }
                    }

                    loaded_persons++;
                    bgw.ReportProgress((int)((float)loaded_persons / (float)followed_peoples.Count * (float)progress_range) + completed_progress);
                }
            }

            completed_progress += progress_range;
            loaded_persons = 0;
            foreach (string name in followed_peoples.Keys)
            {
                if (!followers_peoples.ContainsKey(name))
                {
                    index++;
                    if ((index >= start_index) && (index <= end_index))
                    {
                        if (lvReport.InvokeRequired)
                        {
                            lvReport.Invoke(new MethodInvoker(delegate
                            {
                                ListViewItem item = lvReport.Items.Add(index.ToString());
                                item.ForeColor = Color.Red;
                                item.SubItems.Add(name);
                                item.SubItems.Add("Chưa theo dõi bạn");
                            }));
                        }
                        else
                        {
                            ListViewItem item = lvReport.Items.Add(index.ToString());
                            item.ForeColor = Color.Red;
                            item.SubItems.Add(name);
                            item.SubItems.Add("Chưa theo dõi bạn");
                        }
                    }
                }

                loaded_persons++;
                bgw.ReportProgress((int)((float)loaded_persons / (float)followed_peoples.Count * (float)progress_range) + completed_progress);
            }
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (StatusBar.InvokeRequired)
            {
                StatusBar.Invoke(new MethodInvoker(delegate
                {
                    StatusProgress.Value = e.ProgressPercentage;
                    StatusText.Text = string.Format("{0} %", e.ProgressPercentage);
                }));
            }
            else
            {
                StatusProgress.Value = e.ProgressPercentage;
                StatusText.Text = string.Format("{0} %", e.ProgressPercentage);
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (/*!e.Cancelled*/true)
            {
                if (StatusBar.InvokeRequired)
                {
                    StatusBar.Invoke(new MethodInvoker(delegate {
                        StatusText.Text = string.Format("Tổng số: {0} người", lvReport.Items.Count);
                        StatusProgress.Visible = false;
                        }));
                }
                else
                {
                    StatusText.Text = string.Format("Tổng số: {0} người", lvReport.Items.Count);
                    StatusProgress.Visible = false;
                }
            }

            RestoreControlEnabledState(txtFollowedFile);
            RestoreControlEnabledState(txtMyFollowers);
            RestoreControlEnabledState(btnFollowedFileBrowse);
            RestoreControlEnabledState(btnMyFollowersBrowse);
            RestoreControlEnabledState(grpOptions);
            //RestoreControlEnabledState(btnReport);
            RestoreControlEnabledState(btnExportList);

            if (btnReport.InvokeRequired)
            {
                btnReport.Invoke(new MethodInvoker(delegate
                {
                    btnReport.Tag = null;
                    btnReport.Text = "&BÁO CÁO";
                }));
            }
            else
            {
                btnReport.Tag = null;
                btnReport.Text = "&BÁO CÁO";
            }

            if (btnExportList.InvokeRequired)
            {
                btnExportList.Invoke(new MethodInvoker(delegate {
                    btnExportList.Enabled = lvReport.Items.Count > 0;
                }));
            }
            else
            {
                btnExportList.Enabled = lvReport.Items.Count > 0;
            }

            if (!e.Cancelled)
            {
                MessageBox.Show("Tạo báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFollowedFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Title = "Chọn tệp danh sách người bạn đang theo dõi";
            dlgOpen.CheckFileExists = true;
            dlgOpen.CheckPathExists = true;
            dlgOpen.Filter = "Tất cả các tệp tin|*.*|Tệp tin định dạng HTML|who_you've_followed.html|Tệp tin định dạng JSON|who_you've_followed.json";
            dlgOpen.FilterIndex = 2;
            dlgOpen.RestoreDirectory = true;
            dlgOpen.FileName = "who_you've_followed";

            if (dlgOpen.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            txtFollowedFile.Text = dlgOpen.FileName;
        }

        private void btnMyFollowersBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Title = "Chọn tệp danh sách người đang theo dõi bạn";
            dlgOpen.CheckFileExists = true;
            dlgOpen.CheckPathExists = true;
            dlgOpen.Filter = "Tất cả các tệp tin|*.*|Tệp tin định dạng HTML|people_who_followed_you.html|Tệp tin định dạng JSON|people_who_followed_you.json";
            dlgOpen.FilterIndex = 2;
            dlgOpen.RestoreDirectory = true;
            dlgOpen.FileName = "people_who_followed_you";

            if (dlgOpen.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            txtMyFollowers.Text = dlgOpen.FileName;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgw.IsBusy)
                bgw.CancelAsync();
        }

        private void btnExportList_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Title = "Xuất danh sách";
            dlgSave.OverwritePrompt = true;
            dlgSave.FileName = "Output";
            dlgSave.Filter = "Tệp tin định dạng HTML|*.html";
            dlgSave.RestoreDirectory = true;

            if (dlgSave.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            System.IO.StreamWriter writer = null;
            string index;
            string name;
            string desc;
            try
            {
                writer = new System.IO.StreamWriter(dlgSave.FileName, false, Encoding.UTF8);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            writer.Write("<html><head><title>Báo cáo</title></head><body><table style='border:solid 1px gray;'><caption><h1>Báo cáo</h1></caption><tr><th>#</th><th style='border-left:solid 1px gray;'>Tên</th><th style='border-left:solid 1px gray;'>Ghi chú</th></tr>");
            foreach (ListViewItem item in lvReport.Items)
            {
                index = item.Text;
                name = item.SubItems[1].Text;
                desc = item.SubItems[2].Text;
                writer.Write(string.Format("<tr><td style='color:{0};border-top:solid 1px gray;'>{1}</td><td onclick='javascript:navigator.clipboard.writeText(this.innerText);this.style.backgroundColor=`yellow`;' style='color:{2};border-top:solid 1px gray;border-left:1px solid gray;'>{3}</td><td style='color:{4};border-top:solid 1px gray;border-left:1px solid gray;'>{5}</td></tr>", ColorTranslator.ToHtml(item.ForeColor), index, ColorTranslator.ToHtml(item.ForeColor), name, ColorTranslator.ToHtml(item.ForeColor), desc));
            }
            writer.Write("</table>");
            writer.Close();
        }

        private void copyNameContextMenuItem_Click(object sender, EventArgs e)
        {
            if (lvReport.SelectedItems.Count <= 0)
                return;

            ListViewItem selItem = lvReport.SelectedItems[0];
            if (selItem == null)
                return;

            try
            {
                string name = selItem.SubItems[1].Text;
                Clipboard.Clear();
                Clipboard.SetText(name);
                selItem.BackColor = Color.Yellow;
            }
            catch (System.Exception)
            {
                ;
            }
        }

        private void ListViewContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (lvReport.SelectedItems.Count <= 0)
                copyNameContextMenuItem.Visible = false;
            else
                copyNameContextMenuItem.Visible = true;
        }

        private void lvReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            if (lvReport.SelectedItems.Count <= 0)
                return;

            ListViewItem selItem = lvReport.SelectedItems[0];
            if (selItem == null)
                return;

            try
            {
                string name = selItem.SubItems[1].Text;
                Clipboard.Clear();
                Clipboard.SetText(name);
                selItem.BackColor = Color.Yellow;
            }
            catch (System.Exception)
            {
                ;
            }
        }

        private void lvReport_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvReport_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvReport_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}
