namespace FBConnectionsTracing
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblRequestKey = new System.Windows.Forms.Label();
            this.txtRequestKey = new System.Windows.Forms.TextBox();
            this.lblLicenseKey = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtLicenseKey = new System.Windows.Forms.MaskedTextBox();
            this.btnGenerateLicenseKey = new System.Windows.Forms.Button();
            this.timerDevelopKeyRepeat = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(105, 6);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(314, 40);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Thời gian dùng thử của bạn đã hết. Hãy nhập khóa bản quyền để tiếp tục sử dụng.\r\n" +
    "Nếu chưa có khóa, hãy liên hệ tác giả Đô Tin Học để nhận khóa.";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRequestKey
            // 
            this.lblRequestKey.AutoSize = true;
            this.lblRequestKey.Location = new System.Drawing.Point(14, 55);
            this.lblRequestKey.Name = "lblRequestKey";
            this.lblRequestKey.Size = new System.Drawing.Size(66, 13);
            this.lblRequestKey.TabIndex = 1;
            this.lblRequestKey.Text = "Mã yêu cầu:";
            // 
            // txtRequestKey
            // 
            this.txtRequestKey.Location = new System.Drawing.Point(105, 52);
            this.txtRequestKey.Name = "txtRequestKey";
            this.txtRequestKey.Size = new System.Drawing.Size(314, 20);
            this.txtRequestKey.TabIndex = 0;
            this.txtRequestKey.TextChanged += new System.EventHandler(this.txtRequestKey_TextChanged);
            this.txtRequestKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRequestKey_KeyDown);
            this.txtRequestKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRequestKey_KeyPress);
            // 
            // lblLicenseKey
            // 
            this.lblLicenseKey.AutoSize = true;
            this.lblLicenseKey.Location = new System.Drawing.Point(14, 81);
            this.lblLicenseKey.Name = "lblLicenseKey";
            this.lblLicenseKey.Size = new System.Drawing.Size(88, 13);
            this.lblLicenseKey.TabIndex = 1;
            this.lblLicenseKey.Text = "Khóa bản quyền:";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(130, 118);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(85, 23);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(221, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.HideSelection = false;
            this.txtLicenseKey.Location = new System.Drawing.Point(105, 81);
            this.txtLicenseKey.Mask = ">AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA";
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.PromptChar = '-';
            this.txtLicenseKey.Size = new System.Drawing.Size(314, 20);
            this.txtLicenseKey.TabIndex = 1;
            this.txtLicenseKey.TextChanged += new System.EventHandler(this.txtLicenseKey_TextChanged);
            // 
            // btnGenerateLicenseKey
            // 
            this.btnGenerateLicenseKey.Enabled = false;
            this.btnGenerateLicenseKey.Location = new System.Drawing.Point(419, 81);
            this.btnGenerateLicenseKey.Name = "btnGenerateLicenseKey";
            this.btnGenerateLicenseKey.Size = new System.Drawing.Size(17, 20);
            this.btnGenerateLicenseKey.TabIndex = 2;
            this.btnGenerateLicenseKey.Text = "G";
            this.btnGenerateLicenseKey.UseVisualStyleBackColor = true;
            this.btnGenerateLicenseKey.Visible = false;
            this.btnGenerateLicenseKey.Click += new System.EventHandler(this.btnGenerateLicenseKey_Click);
            // 
            // timerDevelopKeyRepeat
            // 
            this.timerDevelopKeyRepeat.Interval = 300;
            this.timerDevelopKeyRepeat.Tick += new System.EventHandler(this.timerDevelopKeyRepeat_Tick);
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(437, 167);
            this.Controls.Add(this.btnGenerateLicenseKey);
            this.Controls.Add(this.txtLicenseKey);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblLicenseKey);
            this.Controls.Add(this.txtRequestKey);
            this.Controls.Add(this.lblRequestKey);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RegisterForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblRequestKey;
        private System.Windows.Forms.TextBox txtRequestKey;
        private System.Windows.Forms.Label lblLicenseKey;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox txtLicenseKey;
        private System.Windows.Forms.Button btnGenerateLicenseKey;
        private System.Windows.Forms.Timer timerDevelopKeyRepeat;
    }
}