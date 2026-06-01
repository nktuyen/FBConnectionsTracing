using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBConnectionsTracing
{
    public partial class RegisterForm : Form
    {
        public string RequestKey { get; set; }
        public string ErrorMessage { get; set; }
        public string LicenceKey { get; set; }
        public bool DeveloperMode { get; set; }
        private long DeveloperKeyRepeatCount { get; set; }

        public RegisterForm()
        {
            InitializeComponent();
            this.RequestKey = string.Empty;
            this.ErrorMessage = string.Empty;
            this.DeveloperKeyRepeatCount = 0;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            if (this.DeveloperMode)
            {
                lblMessage.Text = "Chế độ dành cho nhà phát triển";
                txtRequestKey.ReadOnly = false;
                txtRequestKey.BackColor = Color.White;
                this.Text = "Tạo khóa bản quyền";
                btnRegister.Text = "Kiểm tra";
                btnGenerateLicenseKey.Visible = true;
                txtLicenseKey.ReadOnly = true;
                txtRequestKey.Text = this.RequestKey;
            }
            else
            {
                txtRequestKey.ReadOnly = true;
                txtRequestKey.BackColor = Color.White;
                this.Text = "Đăng ký";
                btnRegister.Text = "Đăng ký";
                btnGenerateLicenseKey.Visible = false;
                txtLicenseKey.ReadOnly = false;

                if (this.RequestKey == string.Empty)
                {
                    txtRequestKey.Text = "(Không có mã yêu cầu)";
                    btnRegister.Enabled = false;
                }
                else
                {
                    txtRequestKey.Text = this.RequestKey;
                    btnRegister.Enabled = true;
                }

                txtLicenseKey.Text = this.LicenceKey;

                if (this.ErrorMessage != null && this.ErrorMessage != string.Empty)
                {
                    lblMessage.Text = this.ErrorMessage;
                    lblMessage.Visible = true;
                }
                else
                {
                    lblMessage.Visible = false;
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtLicenseKey.TextLength <= 0)
            {
                MessageBox.Show("Vui lòng nhập khóa bản quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicenseKey.Focus();
                return;
            }

            if (!LicenseManager.Instance.ValidateLicenseKey(txtLicenseKey.Text.Replace("-", ""), txtRequestKey.Text.Replace("-", ""), LicenseManager.Instance.ProductName))
            {
                MessageBox.Show("Khóa bản quyền không đúng.\nVui lòng nhập khóa khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseKey.Focus();
                return;
            }

            this.LicenceKey = txtLicenseKey.Text;

            if (!this.DeveloperMode)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                MessageBox.Show("Khóa hợp lệ!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtRequestKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!this.DeveloperMode)
                e.Handled = true;
        }

        private void txtRequestKey_KeyDown(object sender, KeyEventArgs e)
        {
            if(!this.DeveloperMode)
                if (!e.Control)
                    e.Handled = true;
        }

        private void txtLicenseKey_TextChanged(object sender, EventArgs e)
        {
            // Lấy vị trí con trỏ hiện tại để tránh bị nhảy con trỏ khi gõ
            int selectionStart = txtLicenseKey.SelectionStart;

            // Kiểm tra xem có ký tự thường nào không
            string currentText = txtLicenseKey.Text;
            string upperText = currentText.ToUpper();

            if (currentText != upperText)
            {
                // Gán lại chuỗi đã được viết hoa
                txtLicenseKey.Text = upperText;

                // Trả con trỏ về đúng vị trí cũ của người dùng
                txtLicenseKey.SelectionStart = selectionStart;
            }
        }

        private void txtRequestKey_TextChanged(object sender, EventArgs e)
        {
            btnGenerateLicenseKey.Enabled = txtRequestKey.TextLength > 0;
        }

        private void btnGenerateLicenseKey_Click(object sender, EventArgs e)
        {
            string seed = string.Format("{0}-{1}", txtRequestKey.Text.Replace("-", ""), LicenseManager.Instance.ProductName);
            string sum = LicenseManager.Instance.ComputeMD5Hash(seed, true);
            txtLicenseKey.Text = sum;
        }

        private void RegisterForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                if (this.DeveloperMode)
                    return;

                if (!timerDevelopKeyRepeat.Enabled)
                {
                    timerDevelopKeyRepeat.Enabled = true;
                    timerDevelopKeyRepeat.Start();
                }
                else
                {
                    timerDevelopKeyRepeat.Stop();
                    timerDevelopKeyRepeat.Start();
                }
                this.DeveloperKeyRepeatCount++;
                if (this.DeveloperKeyRepeatCount >= 5)
                {
                    timerDevelopKeyRepeat.Enabled = false;
                    this.DeveloperKeyRepeatCount = 0;

                    btnGenerateLicenseKey.Visible = true;
                }
            }
        }

        private void timerDevelopKeyRepeat_Tick(object sender, EventArgs e)
        {
            this.DeveloperKeyRepeatCount = 0;
            timerDevelopKeyRepeat.Enabled = false;
            btnGenerateLicenseKey.Visible = false;
        }
    }
}
