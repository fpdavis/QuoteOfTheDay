using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuoteOfTheDay
{
    class Update : IDisposable
    {
        private PluginAppSettings _pas;

        public Update(PluginAppSettings oPluginAppSettings)
        {
            _pas = oPluginAppSettings;
            BeginCheck();
        }
        
        private void BeginCheck()
        {
            string sMyVersionDate = _pas.GetString("VersionDate");
            string sCurrentVersionDate = GetCurrentVersionDate();

            if (!string.IsNullOrWhiteSpace(sCurrentVersionDate) && sMyVersionDate != sCurrentVersionDate)
            {
                if (_pas.GetBoolean("AutomaticUpdates") || MessageBox.Show("A newer version of Quote of the Day is available. Would you like to update?", "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sSaveLocation = this.GetType().Assembly.Location;
                    if (GetCurrentVersion(sSaveLocation + ".newversion"))
                    {
                        try
                        {
                            File.Delete(sSaveLocation + ".previousversion");
                            File.Move(sSaveLocation, sSaveLocation + ".previousversion");
                            File.Move(sSaveLocation + ".newversion", sSaveLocation);

                            if (!_pas.GetBoolean("AutomaticUpdates"))
                            {
                                MessageBox.Show(
                                    "Quote of the Day has been updated. Update will be applied on next restart of LaunchBox/BigBox",
                                    "Update Successful", MessageBoxButtons.OK);
                            }

                            _pas.SetString("VersionDate", sCurrentVersionDate);
                            _pas.Save();

                        }
                        catch (Exception exception)
                        {
                            if (!_pas.GetBoolean("AutomaticUpdates"))
                            {
                                MessageBox.Show(
                                    "Quote of the Day could not be updated. Exception: " + exception.Message,
                                    "Update Unsuccessful", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
            }
            else if (!_pas.GetBoolean("AutomaticUpdates") && string.IsNullOrWhiteSpace(sCurrentVersionDate))
            {
                MessageBox.Show(
                    "A version number could not be found. This may indicate a network issue or a configuration issue. Check VersionUrl in QuoteOfTheDay.dll.config.",
                    "Version not fond", MessageBoxButtons.OK);

            }
            else if (!_pas.GetBoolean("AutomaticUpdates"))
            {
                MessageBox.Show("You are up to date.", "No Update Available", MessageBoxButtons.OK);
            }
        }

        private string GetCurrentVersionDate()
        {
            string sVersionDate = string.Empty;

            byte[] oBytes = null;

            try
            {
                if (!string.IsNullOrWhiteSpace(_pas.GetString("VersionUrl")))
                {
                    oBytes = new WebClient().DownloadData(_pas.GetString("VersionUrl"));
                }

                if (oBytes != null)
                {
                    string sWebResponse = Encoding.UTF8.GetString(oBytes);

                    //<relative-time datetime="2017-05-17T06:59:23Z">May 17, 2017</relative-time>
                    Match match = Regex.Match(sWebResponse, @"<relative-time datetime=""([^""]*)", RegexOptions.IgnoreCase);

                    // Here we check the Match instance.
                    if (match.Success)
                    {
                        // Finally, we get the Group value and display it.
                        sVersionDate = match.Groups[1].Value;
                    }
                }
            }
            catch
            {
            }

            return (sVersionDate);
        }

        private Boolean GetCurrentVersion(string sSaveLocation)
        {
            Boolean bSuccess = false;

            try
            {
                byte[] oBytes = new WebClient().DownloadData(_pas.GetString("VersionUrl").Replace("/blob/", "/raw/"));

                if (oBytes != null && oBytes.Length > 20000)
                {
                    File.WriteAllBytes(sSaveLocation, oBytes);
                    bSuccess = true;
                }
            }
            catch
            {
            }

            return bSuccess;
        }

        public void Dispose()
        {
        }
    }
}
