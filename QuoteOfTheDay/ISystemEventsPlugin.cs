using System.Threading.Tasks;
using QuoteOfTheDay.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace QuoteOfTheDay
{
    public class QOTD_ISystemEventsPlugin : ISystemEventsPlugin
    {
        private readonly PluginAppSettings _pas = new PluginAppSettings();

        public void OnEventRaised(string eventType)
        {
            if (_pas.GetBoolean("AutomaticUpdates") && (eventType == SystemEventTypes.BigBoxStartupCompleted || eventType == SystemEventTypes.LaunchBoxStartupCompleted))
            {
                using (new Update(_pas));
            }

            if (eventType == SystemEventTypes.BigBoxStartupCompleted && _pas.GetBoolean("ShowInBigBox") || eventType == SystemEventTypes.LaunchBoxStartupCompleted &&  _pas.GetBoolean("ShowInLaunchBox"))
            {
                frmQuote oFrmQuote = new frmQuote();
                frmQuoteBackground oFrmQuoteBackground = new frmQuoteBackground(oFrmQuote);
                oFrmQuote.ofrmQuoteBackground = oFrmQuoteBackground;

                oFrmQuoteBackground.Show();
                oFrmQuote.Show();
                oFrmQuoteBackground.Hide();
                oFrmQuote.Hide();

                Task.Delay((int)1000).ContinueWith(t => new Qotd().DisplayQuote(oFrmQuote, oFrmQuoteBackground, _pas));
            }
        }
    }
}
