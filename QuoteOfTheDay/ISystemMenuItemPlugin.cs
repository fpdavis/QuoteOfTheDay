using System.Drawing;
using Unbroken.LaunchBox.Plugins;

namespace QuoteOfTheDay
{
    public class QOTD_ISystemMenuItemPlugin : ISystemMenuItemPlugin
    {
        public void OnSelected()
        {
            frmSettings ofrmSettings = new frmSettings();
            ofrmSettings.Show();
        }

        public string Caption
        {
            get { return "Quote of the Day Settings"; }
        }

        public Image IconImage
        {
            get { return Properties.Resources.quotes; }
        }

        public bool ShowInLaunchBox
        {
            get { return true; }
        }

        public bool ShowInBigBox
        {
            get { return false; }
        }

        public bool AllowInBigBoxWhenLocked
        {
            get { return false; }
        }
    }
}