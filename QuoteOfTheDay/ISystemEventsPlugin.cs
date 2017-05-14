using System.Threading.Tasks;
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
                Task.Delay((int)1000).ContinueWith(t => new Qotd().DisplayQuote());
            }
        }
    }
}
