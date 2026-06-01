using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBConnectionsTracing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LicenseManager.Instance.LoadLicenseInformation();
            if (LicenseManager.Instance.LicenseType == LicenseType.Trial)
            {
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan elapsedTime = DateTime.UtcNow - epoch;
                TimeSpan installedTime = new TimeSpan((int)LicenseManager.Instance.InstalledDate, 0, 0, 0);
                long usedDays = (long)((elapsedTime - installedTime).TotalDays);
                if (usedDays >= LicenseManager.Instance.TrialDays)
                {
                    RegisterForm frm = new RegisterForm();
                    frm.ErrorMessage = string.Format("Thời gian dùng thử {0} của bạn đã hết.\nVui lòng nhập khóa bản quyền để tiếp tục sử dụng.\nLiên hệ Đô Tin Học(@dotinhoc198) để nhận khóa.", LicenseManager.Instance.TrialDays);
                    frm.RequestKey = LicenseManager.Instance.GetMachineUniqueIndentifier(true);
                    if(frm.ShowDialog() != DialogResult.OK)
                        return;

                    LicenseManager.Instance.SetLicenseKey(frm.LicenceKey);
                }
            }
            else if (LicenseManager.Instance.LicenseType == LicenseType.Unlicensed)
            {
                RegisterForm frm = new RegisterForm();
                frm.ErrorMessage = string.Format("Khóa bản quyền hiện tại của bạn không hợp lệ.\nVui lòng nhập khóa hợp lệ để tiếp tục sử dụng\nLiên hệ Đô Tin Học(@dotinhoc198) nếu cần trợ giúp.", LicenseManager.Instance.LicenseKey);
                frm.RequestKey = LicenseManager.Instance.GetMachineUniqueIndentifier(true);
                frm.LicenceKey = LicenseManager.Instance.LicenseKey;
                if (frm.ShowDialog() != DialogResult.OK)
                    return;

                LicenseManager.Instance.SetLicenseKey(frm.LicenceKey);
            }

            Application.Run(new MainForm());
        }
    }
}
