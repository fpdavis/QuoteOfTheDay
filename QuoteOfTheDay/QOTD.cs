using System.Text;
using System;
using System.Xml;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices; // For the P/Invoke signatures.
using System.Threading.Tasks;
using QuoteOfTheDay.Forms;

namespace QuoteOfTheDay
{
    public class Qotd : IDisposable
    {
        #region User32 Methods
        [DllImport("user32.dll", EntryPoint = "GetWindowText", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);
        public delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out Qotd.user32Rect lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct user32Rect
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        #endregion

        #region Private Properties
        private frmQuote _oFrmQuote;
        private frmQuoteBackground _oFrmQuoteBackGround;
        private string _QOTD_Type = null;
        private readonly PluginAppSettings _pas = new PluginAppSettings();
        private string QOTD_Type
        {
            get
            {
                if (_QOTD_Type != null) return _QOTD_Type;

                if (!string.IsNullOrWhiteSpace(_pas.GetString("QOTD_Type")))
                {
                    _QOTD_Type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_pas.GetString("QOTD_Type"));
                }
                else
                {
                    _QOTD_Type = "Random";
                }

                return _QOTD_Type;
            }
            set { _QOTD_Type = value; }
        }

        #endregion

        public void DisplayQuote(frmQuote oFrmQuote, frmQuoteBackground oFrmQuoteBackground)
        {
            _oFrmQuote = oFrmQuote;
            _oFrmQuoteBackGround = oFrmQuoteBackground;

            QOTDTypeRandomNormalization();

            string sQuote = string.Empty;

            switch (QOTD_Type)
            {
                case "Bible Gateway Verse":
                    sQuote = GetBibleGatewayQuote();
                    break;
                case "Brainy Quote":
                    sQuote = GetBrainyQuoteQuote();
                    break;
                case "Local File":
                    sQuote = GetLoaclQuote();
                    break;
            }

            ShowQuote(sQuote);
        }

        #region Private Methods
        private void QOTDTypeRandomNormalization()
        {
            if (QOTD_Type == "Random")
            {
                Random oRandom = new Random();
                int iQOTDType = oRandom.Next(3);

                switch (iQOTDType)
                {
                    case 0:
                        QOTD_Type = "Verse";
                        break;
                    case 1:
                        QOTD_Type = "Quote";
                        break;
                    case 2:
                        QOTD_Type = "Local";
                        break;
                }
            }
        }

        /*
         Display Bible Gateway Verse of the Day from rss
         https://www.biblegateway.com/usage/votd/docs/

          BibleVersion is the version to display. 31 is NIV.
          A complete listing of versions can be found here:
          http://www.biblegateway.com/usage/linking/versionslist/
        */
        private string GetBibleGatewayQuote()
        {
            string sQuote = string.Empty;
            
            string sURL = "https://www.biblegateway.com/usage/votd/rss/votd.rdf?" + _pas.GetString("BibleVersion");

            XmlDocument doc1 = new XmlDocument();
            doc1.Load(sURL);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/rss/channel/item");

            if (nodes != null && nodes.Count >= 0)
            {
                XmlNode node = nodes[0];

                string sTitle = node["title"].InnerText;
                sQuote = node["content:encoded"].InnerText;

                sQuote = sQuote.Replace("&ldquo;", "\"");
                sQuote = sQuote.Replace("&rdquo;", "\"");
                sQuote = sQuote.Replace("<br/><br/>", "");
                sQuote = sQuote.Replace("Brought to you by ", " - " + sTitle + " provided by ");
                sQuote = sQuote.Replace("<a href=\"https://www.biblegateway.com\">", "");
                sQuote = sQuote.Replace("</a>", "");
                sQuote = sQuote.Replace("All Rights Reserved.", "");
            }

            return sQuote;
        }

        private string GetBrainyQuoteQuote()
        {
            string sQuote = string.Empty;

            string sURL = "https://feeds.feedburner.com/brainyquote/QUOTEBR";

            XmlDocument doc1 = new XmlDocument();
            doc1.Load(sURL);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/rss/channel/item");

            if (nodes != null && nodes.Count >= 0)
            {
                string sAuthor = nodes[0]["title"].InnerText;
                sQuote = nodes[0]["description"].InnerText;

                sQuote += " - " + sAuthor + " provided by BrainyQuote.com";
            }

            return sQuote;
        }

        private string GetLoaclQuote()
        {
            string sURL = null;
            string sQuote = string.Empty;
            string sAuthor = string.Empty;

            if (!string.IsNullOrWhiteSpace(_pas.GetString("LocalFileLocation")))
                {
                    sURL = _pas.GetString("LocalFileLocation");
                }
            else
            {
                var assemblyLocation = this.GetType().Assembly.Location;
                if (assemblyLocation != null)
                {
                    sURL = assemblyLocation.Replace(this.GetType().Assembly.GetName().Name + ".dll", "") + "Quotes.xml";
                }
            }
            
            if (!string.IsNullOrWhiteSpace(sURL) && File.Exists(sURL))
            {
                XmlDocument doc1 = new XmlDocument();
                doc1.Load(sURL);
                XmlElement root = doc1.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("/quotes/item");

                if (nodes != null && nodes.Count >= 0)
                {
                    Random oRandom = new Random();
                    int iItem = oRandom.Next(nodes.Count);
                
                    if (nodes[iItem]["quote"] != null) sQuote = nodes[iItem]["quote"].InnerText;

                    if (nodes[iItem]["author"] != null) sAuthor = nodes[iItem]["author"].InnerText;
                    if (!string.IsNullOrWhiteSpace(sAuthor))
                    {
                        sQuote += " - " + sAuthor;
                    }
                }
            }

            return sQuote;
        }

        private void ShowQuote(string sQuote)
        {
            // Just return if nothing to show
            if (string.IsNullOrWhiteSpace(sQuote)) return;
            
            Color oBackgroundColor = Color.Gray;
            var oColor = new ColorConverter().ConvertFromInvariantString(_pas.GetString("BackgroundColor"));
            if (oColor != null)
            {
                oBackgroundColor = (Color)oColor;
            }
          
            _oFrmQuote.TransparencyKey = oBackgroundColor;
            _oFrmQuote.BackColor = oBackgroundColor;

            var oLaunchboxWindow = FindWindow();

            if (oLaunchboxWindow != IntPtr.Zero)
            {
                Qotd.user32Rect oLaunchBigBoxRectangle;
                GetWindowRect(oLaunchboxWindow, out oLaunchBigBoxRectangle);

                int iBoxWidth = oLaunchBigBoxRectangle.Right - oLaunchBigBoxRectangle.Left;
                int iBoxHeight = oLaunchBigBoxRectangle.Bottom - oLaunchBigBoxRectangle.Top;

                _oFrmQuote.Width = Convert.ToInt32(iBoxWidth * _pas.GetInt("QuoteWidthPercentage") * .01);
                _oFrmQuote.Height = Convert.ToInt32(iBoxHeight * _pas.GetInt("QuoteHeightPercentage") * .01);
                _oFrmQuote.Location = new Point(((iBoxWidth - _oFrmQuote.Width) / 2) + oLaunchBigBoxRectangle.Left, ((iBoxHeight - _oFrmQuote.Height) / 2) + oLaunchBigBoxRectangle.Top);
            }
            else
            {
                _oFrmQuote.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * _pas.GetInt("QuoteWidthPercentage") * .01);
                _oFrmQuote.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * _pas.GetInt("QuoteHeightPercentage") * .01);
                _oFrmQuote.Location = new Point((Screen.PrimaryScreen.Bounds.Width - _oFrmQuote.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - _oFrmQuote.Height) / 2);
            }

            Graphics oGraphics = _oFrmQuote.CreateGraphics();

            float emSize = ((float)_oFrmQuote.Width / _pas.GetInt("MinimumCharactersPerLine"));

            int iFontHeight;
            Font oFont = new FontConverter().ConvertFromInvariantString(_pas.GetString("FontStyle")) as Font;

            if (oFont != null)
            {
                oFont = new Font(oFont.Name, (float)emSize, oFont.Style);
            }
            else
            {
                oFont = new Font(FontFamily.GenericSerif, emSize, FontStyle.Italic); 
            }

            FindBestFitFont(oGraphics, sQuote, _oFrmQuote.ClientRectangle.Size, ref oFont, out iFontHeight);

            // Resize and reposition the form to accomodate the Font height and number of lines
            _oFrmQuote.Top += (_oFrmQuote.Height - iFontHeight) / 2;
            _oFrmQuote.Height = iFontHeight;
            oGraphics.Dispose();

            oGraphics = _oFrmQuote.CreateGraphics();

            // opaque: 0 = invisible, 255 = fully opaque
            //for (int iOpacity = 0; iOpacity < 50; iOpacity++)
            //{
            //    System.Threading.Thread.Sleep(10);
            //    oGraphics.Clear(oForm.TransparencyKey);
            //}

            _oFrmQuoteBackGround.BackColor = oBackgroundColor;
            _oFrmQuoteBackGround.Location = _oFrmQuote.Location;
            _oFrmQuoteBackGround.Width = _oFrmQuote.Width;
            _oFrmQuoteBackGround.Height = _oFrmQuote.Height;
            _oFrmQuoteBackGround.Opacity = _pas.GetInt("BackgroundOpacityPercentage") * .01;

            Color oFontColor = Color.White;
            oColor = new ColorConverter().ConvertFromInvariantString(_pas.GetString("FontColor"));
            if (oColor != null)
            {
                oFontColor = (Color)oColor;
            }

            _oFrmQuoteBackGround.Show();
            _oFrmQuote.Show();
            oGraphics.DrawString(sQuote, oFont, new SolidBrush(Color.FromArgb(_pas.GetInt("TransparancyAlphaValue"), oFontColor)), _oFrmQuote.ClientRectangle);
            _oFrmQuote.BringToFront();
            
            // Form click events to dismiss the dialog
            _oFrmQuote.Click += FrmQuoteClick;
            _oFrmQuoteBackGround.Click += FrmQuoteClick;

            // Handle the escape event - Currently not working
            var btnCancel = new Button();
            btnCancel.Click += FrmQuoteClick;
            _oFrmQuote.CancelButton = btnCancel;
            _oFrmQuoteBackGround.CancelButton = btnCancel;
            Application.OpenForms[_oFrmQuote.Name].Focus();
          
            Task.Delay((int)(_pas.GetDecimal("SecondsToDisplayQuotePerWord") * 1000 * WordCount(ref sQuote))).ContinueWith(t => CloseForm());
        }

        private int WordCount(ref string sString)
        {
            int iWordCount = 0;
            int iIndex = 0;

            while (iIndex < sString.Length)
            {
                // check if current char is part of a word
                while (iIndex < sString.Length && !char.IsWhiteSpace(sString[iIndex]))
                    iIndex++;

                iWordCount++;

                // skip whitespace until next word
                while (iIndex < sString.Length && char.IsWhiteSpace(sString[iIndex]))
                    iIndex++;
            }

            return iWordCount;
        }
        private IntPtr FindWindow()
        {
            IntPtr oFindWindow = new IntPtr();

            string[] asWindowNames = _pas.GetString("WindowNames").ToLower().Replace(" ", "").Split(',');

            Qotd.EnumDelegate filter = delegate (IntPtr hWnd, int lParam)
            {
                StringBuilder strbTitle = new StringBuilder(255);
                Qotd.GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
                string sWindowTitle = strbTitle.ToString().ToLower().Replace(" ", "");

                foreach (var sWindowName in asWindowNames)
                {
                    if (!string.IsNullOrEmpty(sWindowTitle) && sWindowTitle.Contains(sWindowName))
                    {
                        oFindWindow = hWnd;
                    }
                }

                return true;
            };

            Qotd.EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero);
            return oFindWindow;
        }

        private void FrmQuoteClick(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            _oFrmQuote?.Hide();
            _oFrmQuoteBackGround?.Hide();

            if (_oFrmQuote != null)
            {
                _oFrmQuote.Close();
                _oFrmQuote.Dispose();
            }

            if (_oFrmQuoteBackGround != null)
            {
                _oFrmQuoteBackGround.Close();
                _oFrmQuoteBackGround.Dispose();
            }

        }
        private void FindBestFitFont(Graphics oGraphics, String sQuote, Size oAreaSize, ref Font oFont, out int iFontHeight)
        {
            Font oPreviousFont;
            int iMaxNumberOfLines = _pas.GetInt("MaxNumberOfLines");
            int iNumberOfLines;
            SizeF oFontSize;

            // Compute actual size, shrink if needed
            while (true)
            {
                oFontSize = oGraphics.MeasureString(sQuote, oFont);
                iNumberOfLines = (int)Math.Ceiling((oFontSize.Width * 1.1) / oAreaSize.Width); // 1.1 is to add some buffer to the width for trailing white space when sentences wrap.
                iFontHeight = (int)oFontSize.Height * iNumberOfLines;

                // If it fits, back out
                if (iNumberOfLines <= iMaxNumberOfLines && (iFontHeight <= oAreaSize.Height)) { return; }

                // Try a smaller font (90% of old size)
                oPreviousFont = oFont;
                oFont = new Font(oFont.Name, (float)(oFont.Size * .9), oFont.Style);
                oPreviousFont.Dispose();
            }
        }

        #endregion

        public void Dispose()
        {
            _pas.Dispose();
            _QOTD_Type = null;
            _oFrmQuote = null;
        }
    }
}