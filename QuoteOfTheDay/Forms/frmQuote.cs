using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuoteOfTheDay.Forms;

namespace QuoteOfTheDay
{
    public partial class frmQuote : Form
    {
        public frmQuoteBackground ofrmQuoteBackground { get; set; }
        
        public frmQuote()
        {
            InitializeComponent();
        }

        private void frmQuote_MouseClick(object sender, MouseEventArgs e)
        {
            HideForms();
        }

        private void frmQuote_KeyDown(object sender, KeyEventArgs e)
        {
            HideForms();
        }

        public void ShowAndClose(int iSecondsToDisplay)
        {
            Task.Delay(iSecondsToDisplay).ContinueWith(t => HideForms());

            this.Show();
            ofrmQuoteBackground.SendToBack();
            this.BringToFront();
            this.Activate();
        }

        private void HideForms()
        {
            ofrmQuoteBackground.Hide();
            this.Hide();
        }

    }
}
