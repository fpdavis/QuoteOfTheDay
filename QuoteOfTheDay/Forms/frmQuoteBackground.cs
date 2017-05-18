using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuoteOfTheDay.Forms
{
    public partial class frmQuoteBackground : Form
    {
        private frmQuote _frmQuote;
  
        public frmQuoteBackground(frmQuote frmQuote)
        {
            _frmQuote = frmQuote;
            InitializeComponent();
        }

        private void frmQuoteBackground_MouseClick(object sender, MouseEventArgs e)
        {
            _frmQuote.Hide();
            this.Hide();
        }

        private void frmQuoteBackground_KeyDown(object sender, KeyEventArgs e)
        {
            _frmQuote.Hide();
            this.Hide();
        }
    }
}
