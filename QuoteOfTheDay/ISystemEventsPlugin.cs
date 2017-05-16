using System.Threading.Tasks;
using QuoteOfTheDay.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace QuoteOfTheDay
{
    public class QOTD_ISystemEventsPlugin : ISystemEventsPlugin
    {
        public void OnEventRaised(string eventType)
        {
            if (eventType == SystemEventTypes.BigBoxStartupCompleted || eventType == SystemEventTypes.LaunchBoxStartupCompleted)
            {
                // These two forms could be redefined as one.
                frmQuote oFrmQuote = new frmQuote();
                frmQuoteBackground oFrmQuoteBackground = new frmQuoteBackground();

                oFrmQuoteBackground.Show();
                oFrmQuote.Show();
                oFrmQuoteBackground.Hide();
                oFrmQuote.Hide();

                Task.Delay((int)1000).ContinueWith(t => new Qotd().DisplayQuote(oFrmQuote, oFrmQuoteBackground));
            }
        }
    }
}
