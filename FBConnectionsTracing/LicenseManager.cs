using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace FBConnectionsTracing
{
    public enum LicenseType
    {
        Trial = 0,
        Unlicensed = 1,
        Licensed = 2
    };

    public class LicenseManager
    {
        public long InstalledDate { get; private set; }
        public LicenseType LicenseType { get; private set; }
        public string LicenseKey { get; private set; }
        private string RegistryPath { get; set; }
        private static LicenseManager _instance = null;
        public string ProductName { get; private set; }

        public long TrialDays
        {
            get
            {
                return 30;
            }
        }

        public static LicenseManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LicenseManager();
                return _instance;
            }
        }

        private LicenseManager()
        {
            Assembly myAssembly = null;
            this.RegistryPath = string.Empty;
            ProductName = string.Empty;

            try
            {
                myAssembly = Assembly.GetExecutingAssembly();
            }
            catch (System.Exception)
            {
                myAssembly = null;
            }

            if (myAssembly != null)
            {
                FileVersionInfo fileVer = null;
                try
                {
                    fileVer = FileVersionInfo.GetVersionInfo(myAssembly.Location);
                }
                catch (System.Exception)
                {
                    fileVer = null;
                }

                if (fileVer != null)
                {
                    this.ProductName = fileVer.ProductName;
                    this.RegistryPath = string.Format("SOFTWARE\\{0}\\{1}", fileVer.CompanyName, fileVer.ProductName);
                }
            }

            if (this.RegistryPath == string.Empty)
                this.RegistryPath = string.Format("SOFTWARE\\NKTUYEN\\FBConnectionsTracing");

            if (this.ProductName == string.Empty)
                this.ProductName = "FBConnectionsTracing";
        }


        private string ComputeSha256Hash(string rawData, bool dash)
        {
            // 1. Create a SHA256 instance
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // 2. Convert the input string to a byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // 3. Convert byte array to a readable hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                string res = builder.ToString().ToUpper();
                if (dash)
                    res = string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}", res.Substring(0, 8), res.Substring(8,8), res.Substring(16, 8), res.Substring(24, 8), res.Substring(32, 8), res.Substring(40, 8), res.Substring(48, 8), res.Substring(56, 8));
                return res;
            }
        }

        public string ComputeMD5Hash(string rawData, bool dash)
        {
            // 1. Create a MD5 instance
            using (MD5 md5 = MD5.Create())
            {
                // 2. Convert the input string to a byte array
                byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // 3. Convert byte array to a readable hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                string res = builder.ToString().ToUpper();
                if (dash)
                    res = string.Format("{0}-{1}-{2}-{3}-{4}", res.Substring(0, 8), res.Substring(8, 4), res.Substring(12, 4), res.Substring(16, 4), res.Substring(20, 12));
                return res;
            }
        }

        public string GetMachineUniqueIndentifier(bool dash)
        {
            StringBuilder builder = new StringBuilder();
            RegistryKey cryptoKey = null;

            try
            {
                cryptoKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography");
            }
            catch (System.Exception)
            {
                cryptoKey = null;
            }

            if (cryptoKey != null)
            {
                try
                {
                    object oMachineGuid = cryptoKey.GetValue("MachineGuid");
                    if (oMachineGuid != null)
                        builder.Append((string)oMachineGuid);
                }
                catch (System.Exception)
                {

                }
                cryptoKey.Close();
            }

            RegistryKey windowsVersionKey = null;
            try
            {
                windowsVersionKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            }
            catch (System.Exception)
            {
                windowsVersionKey = null;
            }
            if (windowsVersionKey != null)
            {
                string productName = string.Empty;
                string displayVersion = string.Empty;

                try
                {
                    object oProductName = windowsVersionKey.GetValue("ProductName");
                    if (oProductName != null)
                       productName = (string)oProductName;
                }
                catch (System.Exception)
                {

                }

                try
                {
                    object oDisplayVersion = windowsVersionKey.GetValue("DisplayVersion");
                    if (oDisplayVersion != null)
                        displayVersion = (string)oDisplayVersion;
                }
                catch (System.Exception)
                {

                }

                if (productName != string.Empty)
                {
                    if (displayVersion != string.Empty)
                        builder.Append(string.Format("{0} {1}", productName, displayVersion));
                    else
                        builder.Append(productName);
                }
            }

            builder.Append(Environment.UserName);

            return ComputeSha256Hash(builder.ToString(), dash);
        }

        public bool ValidateLicenseKey(string licenseKey, string requestCode, string productName)
        {
            if (licenseKey == null || licenseKey == string.Empty)
                return false;

            if (requestCode == null || requestCode == string.Empty)
                return false;

            string seed = string.Format("{0}-{1}", requestCode.Replace("-", ""), productName);
            string sum = ComputeMD5Hash(seed, false);

            return sum.CompareTo(licenseKey.Replace("-", "")) == 0;
        }

        public bool LoadLicenseInformation()
        {
            RegistryKey mainRegKey = null;
            try
            {
                mainRegKey = Registry.CurrentUser.CreateSubKey(this.RegistryPath,  RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                mainRegKey = null;
            }
            if (mainRegKey == null)
                return false;

            string[] valueNames = mainRegKey.GetValueNames();
            this.InstalledDate = 0;
            if (valueNames.Contains("InstalledDate"))
            {
                RegistryValueKind regKind = mainRegKey.GetValueKind("InstalledDate");
                if (regKind != RegistryValueKind.QWord)
                {
                    mainRegKey.DeleteValue("InstalledDate");
                    mainRegKey.SetValue("InstalledDate", 0, RegistryValueKind.QWord);
                }
                else
                {
                    object oInstalledDate = mainRegKey.GetValue("InstalledDate");
                    if (oInstalledDate != null)
                    {
                        this.InstalledDate = (long)oInstalledDate;
                    }
                }
            }
            else
            {
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan elapsedTime = DateTime.UtcNow - epoch;
                mainRegKey.SetValue("InstalledDate", (long)elapsedTime.TotalDays, RegistryValueKind.QWord);
               this.InstalledDate = (long)elapsedTime.TotalDays;
            }

            this.LicenseKey = string.Empty;
            if (valueNames.Contains("LicenseKey"))
            {
                try
                {
                    RegistryValueKind regKind = mainRegKey.GetValueKind("LicenseKey");
                    if (regKind != RegistryValueKind.String)
                    {
                        mainRegKey.DeleteValue("LicenseKey");
                        mainRegKey.SetValue("LicenseKey", string.Empty);
                    }
                    else
                    {
                        object oLicenseKey = mainRegKey.GetValue("LicenseKey");
                        if (oLicenseKey != null)
                        {
                            this.LicenseKey = (string)oLicenseKey;
                        }
                    }
                }
                catch (System.Exception)
                {

                }
            }

            if (this.LicenseKey == string.Empty)
            {
                this.LicenseType = FBConnectionsTracing.LicenseType.Trial;
            }
            else
            {
                string requestKey = GetMachineUniqueIndentifier(true);
                if (!ValidateLicenseKey(this.LicenseKey.Replace("-", ""), requestKey.Replace("-", ""), this.ProductName))
                {
                    this.LicenseType = FBConnectionsTracing.LicenseType.Unlicensed;
                }
                else
                {
                    this.LicenseType = FBConnectionsTracing.LicenseType.Licensed;
                }
            }

            return true;
        }

        public void SetLicenseKey(string newKey)
        {
            this.LicenseKey = newKey;

            RegistryKey mainRegKey = null;
            try
            {
                mainRegKey = Registry.CurrentUser.CreateSubKey(this.RegistryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                mainRegKey = null;
            }
            if (mainRegKey == null)
                return;

            try
            {
                mainRegKey.SetValue("LicenseKey", this.LicenseKey, RegistryValueKind.String);
            }
            catch (System.Exception)
            {

            }
        }
    }
}
