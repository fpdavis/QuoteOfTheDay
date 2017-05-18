using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using QuoteOfTheDay.Forms;

namespace QuoteOfTheDay
{
    public partial class frmSettings : Form
    {
        private readonly PluginAppSettings _pas = new PluginAppSettings();
        private frmQuote _oFrmQuote;
        private frmQuoteBackground _oFrmQuoteBackground;

        private int _frmSettingsStartingHeight;
        private int _txtFontStyleStartingHeight;
        private int _txtFontStylePreviousHeight;

        public frmSettings()
        {
            InitializeComponent();
            SetHelpText();
            _frmSettingsStartingHeight = this.Height;
            _txtFontStyleStartingHeight = txtFontStyle.Height;
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

            openFileDialog1.InitialDirectory = Path.GetDirectoryName(txtLocalFileLocation.Text);
            openFileDialog1.FileName = txtLocalFileLocation.Text;

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

            cmbAutomaticUpdates.SelectedItem = _pas.GetBoolean("AutomaticUpdates") ? "On" : "Off";

            btnSave.Enabled = false;
            btnTest.Enabled = true;
            btnCheckForUpdates.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                var oMessageBoxResults = MessageBox.Show("You have unsaved changes. Do you wish to save your changes?",
                    "Save Changes?", MessageBoxButtons.YesNoCancel);

                if (oMessageBoxResults == DialogResult.Cancel) return;

                if (oMessageBoxResults == DialogResult.Yes) btnSave_Click(sender, e);
                else _pas.ReloadConfiguration();
            }

            CloseForms();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StoreSettingsInAppStrings();

            _pas.Save();

            btnSave.Enabled = false;
            btnCheckForUpdates.Enabled = true;
        }

        private void StoreSettingsInAppStrings()
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
            
            _pas.SetString("AutomaticUpdates", cmbAutomaticUpdates.SelectedItem.ToString() == "On" ? "True" : "False");
        }

        private void SetHelpText()
        {
            helpProvider1.SetHelpString(chkBigBox, _pas.GetString("ShowInBigBox_Help").Replace("  ", " "));
            helpProvider1.SetHelpString(chkLaunchBox, _pas.GetString("ShowInLaunchBox_Help").Replace("  ", " "));
            helpProvider1.SetHelpString(cmbQOTD_Type, _pas.GetString("QOTD_Type_Help").Replace("  ", " "));
            helpProvider1.SetHelpString(txtLocalFileLocation, _pas.GetString("LocalFileLocation_Help").Replace("  ", " "));

            helpProvider1.SetHelpString(txtFontStyle, _pas.GetString("FontStyle_Help").Replace("  ", " "));
            helpProvider1.SetHelpString(txtBackgroundColor, _pas.GetString("BackgroundColor_Help").Replace("  ", " "));
            helpProvider1.SetHelpString(nudSecondsToDisplayQuotePerWord, _pas.GetString("SecondsToDisplayQuotePerWord_Help").Replace("  ", " "));
            helpProvider1.SetHelpString(nudBackgroundOpacityPercentage, _pas.GetString("BackgroundOpacityPercentage_Help").Replace("  ", " "));

            helpProvider1.SetHelpString(nudTransparancyAlphaValue, _pas.GetString("TransparancyAlphaValue_Help").Replace("  ", " "));
            helpProvider1.SetHelpString(nudMaxNumberOfLines, _pas.GetString("MaxNumberOfLines_Help").Replace("  ", " "));
            helpProvider1.SetHelpString(cmbAutomaticUpdates, _pas.GetString("AutomaticUpdates_Help").Replace("  ", " "));

        }

        private void ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnCheckForUpdates.Enabled = false;
        }

        private void txtLocalFileLocation_Leave(object sender, EventArgs e)
        {
            if (!File.Exists(txtLocalFileLocation.Text))
            {
                MessageBox.Show("The file specified could not be found!", "File not found error", MessageBoxButtons.OK);
                txtLocalFileLocation.Text = openFileDialog1.FileName;
            }
            else
            {
                ValueChanged(sender, e);
            }
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
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLocalFileLocation.Text = openFileDialog1.FileName; // Assumes only one file was selected

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

        private void txtFontStyle_SizeChanged(object sender, EventArgs e)
        {
            if (txtFontStyle.Height == _txtFontStylePreviousHeight) return;

            _txtFontStylePreviousHeight = txtFontStyle.Height;
            this.Height = _frmSettingsStartingHeight - _txtFontStyleStartingHeight + txtFontStyle.Height;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            StoreSettingsInAppStrings();

            CloseForms();

            _oFrmQuote = new frmQuote();
            _oFrmQuoteBackground = new frmQuoteBackground(_oFrmQuote);

            _oFrmQuote.ofrmQuoteBackground = _oFrmQuoteBackground;

            _oFrmQuoteBackground.Show();
            _oFrmQuote.Show();
            _oFrmQuoteBackground.Hide();
            _oFrmQuote.Hide();

            Task.Delay((int)100).ContinueWith(t => new Qotd().DisplayQuote(_oFrmQuote, _oFrmQuoteBackground, _pas));
        }

        private void CloseForms()
        {
            if (_oFrmQuote != null)
            {
                _oFrmQuote.Close();
                _oFrmQuote.Dispose();
            }

            if (_oFrmQuoteBackground != null)
            {
                _oFrmQuoteBackground.Close();
                _oFrmQuoteBackground.Dispose();
            }
        }

        private void btnCheckForUpdates_Click(object sender, EventArgs e)
        {

           _pas.SetString("AutomaticUpdates", "False");

            new Update(_pas);
        }
        
    }
}
