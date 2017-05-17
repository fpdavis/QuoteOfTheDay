using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using QuoteOfTheDay.Forms;

namespace QuoteOfTheDay
{
    public partial class frmSettings : Form
    {
        private readonly PluginAppSettings _pas = new PluginAppSettings();

        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _pas.SetString("ShowInBigBox", chkBigBox.Checked.ToString());
            _pas.SetString("ShowInLaunchBox", chkLaunchBox.Checked.ToString());

            _pas.SetString("QOTD_Type", cmbQOTD_Type.SelectedItem.ToString());
            _pas.SetString("LocalFileLocation", txtLocalFileLocation.Text);

            _pas.SetString("FontStyle", new FontConverter().ConvertToInvariantString(fontDialog1.Font));
            _pas.SetString("FontColor", new ColorConverter().ConvertToInvariantString(fontDialog1.Color));
            _pas.SetString("BackgroundColor", new ColorConverter().ConvertToInvariantString(colorDialog1.Color));
            
            _pas.SetString("SecondsToDisplayQuotePerWord", nudSecondsToDisplayQuotePerWord.Text);
            _pas.SetString("BackgroundOpacityPercentage", nudBackgroundOpacityPercentage.Text);
            _pas.SetString("TransparancyAlphaValue", nudTransparancyAlphaValue.Text);
            _pas.SetString("MaxNumberOfLines", nudMaxNumberOfLines.Text);

            _pas.Save();

            btnSave.Enabled = false;
            btnTest.Enabled = true;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            chkLaunchBox.Checked = _pas.GetBoolean("ShowInLaunchBox");
            chkBigBox.Checked = _pas.GetBoolean("ShowInBigBox");

            cmbQOTD_Type.SelectedItem = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_pas.GetString("QOTD_Type"));

            if (!string.IsNullOrWhiteSpace(_pas.GetString("LocalFileLocation")) && File.Exists(_pas.GetString("LocalFileLocation")))
            {
                txtLocalFileLocation.Text = _pas.GetString("LocalFileLocation");
            }
            else
            {
                var assemblyLocation = this.GetType().Assembly.Location;
                if (assemblyLocation != null)
                {
                    txtLocalFileLocation.Text = assemblyLocation.Replace(this.GetType().Assembly.GetName().Name + ".dll", "") + "Quotes.xml";
                }
            }

            fontDialog1.Font = new FontConverter().ConvertFromInvariantString(_pas.GetString("FontStyle")) as Font;
            if (fontDialog1.Font != null)
            {
                txtFontStyle.Text = fontDialog1.Font.Name;
                txtFontStyle.Font = fontDialog1.Font;
            }

            var oColor = new ColorConverter().ConvertFromInvariantString(_pas.GetString("FontColor"));
            if (oColor != null)
            {
                fontDialog1.Color = (Color)oColor;
                txtFontStyle.ForeColor = fontDialog1.Color;
            }

            oColor = new ColorConverter().ConvertFromInvariantString(_pas.GetString("BackgroundColor"));
            if (oColor != null)
            {
                colorDialog1.Color = (Color)oColor;
                txtBackgroundColor.Text = colorDialog1.Color.Name;
                txtBackgroundColor.BackColor = colorDialog1.Color;
                txtFontStyle.BackColor = colorDialog1.Color;

                if (txtBackgroundColor.ForeColor == txtBackgroundColor.BackColor)
                {
                    txtBackgroundColor.ForeColor = fontDialog1.Color;
                }
            }

            nudSecondsToDisplayQuotePerWord.Text = _pas.GetString("SecondsToDisplayQuotePerWord");
            nudBackgroundOpacityPercentage.Text = _pas.GetString("BackgroundOpacityPercentage");
            nudTransparancyAlphaValue.Text = _pas.GetString("TransparancyAlphaValue");
            nudMaxNumberOfLines.Text = _pas.GetString("MaxNumberOfLines");
            
            btnSave.Enabled = false;
            btnTest.Enabled = true;
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnTest.Enabled = false;
        }

        private void CheckIfLocalFile()
        {
            if (cmbQOTD_Type.SelectedItem.ToString() == "Local File")
            {
                lblLocalFile.Enabled = true;
                txtLocalFileLocation.Enabled = true;
                btnOpenFileDialog.Enabled = true;
                btnEditQuoteFile.Enabled = true;
            }
            else
            {
                lblLocalFile.Enabled = false;
                txtLocalFileLocation.Enabled = false;
                btnOpenFileDialog.Enabled = false;
                btnEditQuoteFile.Enabled = false;
            }
        }
        private void btnEditQuoteFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLocalFileLocation.Text))
            {
                System.Diagnostics.Process.Start(txtLocalFileLocation.Text);
            }
        }
        
        private void txtFontStyle_Click(object sender, EventArgs e)
        {
            // See if OK was pressed.
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                // Set TextBox properties.
                txtFontStyle.Text = fontDialog1.Font.Name;
                txtFontStyle.Font = fontDialog1.Font;
                txtFontStyle.ForeColor = fontDialog1.Color;
                
                ValueChanged(sender, e);
            }
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = txtLocalFileLocation.Text;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLocalFileLocation.Text = openFileDialog1.FileName; // Assumes only one file was selected
                CheckIfLocalFile();

                ValueChanged(sender, e);
            }
        }

        private void cmbQOTD_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            ValueChanged(sender, e);
            CheckIfLocalFile();
        }

        private void txtBackgroundHexColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBackgroundColor.Text = colorDialog1.Color.Name;
                txtBackgroundColor.BackColor = colorDialog1.Color;
                txtFontStyle.BackColor = colorDialog1.Color;

                if (txtBackgroundColor.ForeColor == txtBackgroundColor.BackColor)
                {
                    txtBackgroundColor.ForeColor = fontDialog1.Color;
                }

                ValueChanged(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // These two forms could be redefined as one.
            frmQuote oFrmQuote = new frmQuote();
            frmQuoteBackground oFrmQuoteBackground = new frmQuoteBackground();

            oFrmQuoteBackground.Show();
            oFrmQuote.Show();
            oFrmQuoteBackground.Hide();
            oFrmQuote.Hide();
            
            new Qotd().DisplayQuote(oFrmQuote, oFrmQuoteBackground);
        }
    }
}
