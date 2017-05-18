namespace QuoteOfTheDay
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLaunchBox = new System.Windows.Forms.CheckBox();
            this.chkBigBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbQOTD_Type = new System.Windows.Forms.ComboBox();
            this.btnEditQuoteFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudBackgroundOpacityPercentage = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudTransparancyAlphaValue = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.txtBackgroundColor = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudMaxNumberOfLines = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtLocalFileLocation = new System.Windows.Forms.TextBox();
            this.lblLocalFile = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFontStyle = new System.Windows.Forms.TextBox();
            this.nudSecondsToDisplayQuotePerWord = new System.Windows.Forms.NumericUpDown();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCheckForUpdates = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAutomaticUpdates = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackgroundOpacityPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransparancyAlphaValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxNumberOfLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecondsToDisplayQuotePerWord)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(276, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(198, 303);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show In:";
            // 
            // chkLaunchBox
            // 
            this.chkLaunchBox.AutoSize = true;
            this.helpProvider1.SetHelpString(this.chkLaunchBox, "If checked, will show on start of LaunchBox");
            this.chkLaunchBox.Location = new System.Drawing.Point(85, 27);
            this.chkLaunchBox.Name = "chkLaunchBox";
            this.helpProvider1.SetShowHelp(this.chkLaunchBox, true);
            this.chkLaunchBox.Size = new System.Drawing.Size(80, 17);
            this.chkLaunchBox.TabIndex = 2;
            this.chkLaunchBox.Text = "LaunchBox";
            this.chkLaunchBox.UseVisualStyleBackColor = true;
            this.chkLaunchBox.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // chkBigBox
            // 
            this.chkBigBox.AutoSize = true;
            this.helpProvider1.SetHelpString(this.chkBigBox, "If checked, will show on start of BigBox");
            this.chkBigBox.Location = new System.Drawing.Point(169, 27);
            this.chkBigBox.Name = "chkBigBox";
            this.helpProvider1.SetShowHelp(this.chkBigBox, true);
            this.chkBigBox.Size = new System.Drawing.Size(59, 17);
            this.chkBigBox.TabIndex = 3;
            this.chkBigBox.Text = "BigBox";
            this.chkBigBox.UseVisualStyleBackColor = true;
            this.chkBigBox.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type:";
            // 
            // cmbQOTD_Type
            // 
            this.cmbQOTD_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQOTD_Type.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.cmbQOTD_Type, "Specifies where to get the text to display from");
            this.cmbQOTD_Type.Items.AddRange(new object[] {
            "Local File",
            "Brainy Quote",
            "Bible Gateway Verse",
            "Random"});
            this.cmbQOTD_Type.Location = new System.Drawing.Point(85, 55);
            this.cmbQOTD_Type.Name = "cmbQOTD_Type";
            this.helpProvider1.SetShowHelp(this.cmbQOTD_Type, true);
            this.cmbQOTD_Type.Size = new System.Drawing.Size(175, 21);
            this.cmbQOTD_Type.TabIndex = 5;
            this.cmbQOTD_Type.SelectedValueChanged += new System.EventHandler(this.cmbQOTD_Type_SelectedValueChanged);
            // 
            // btnEditQuoteFile
            // 
            this.btnEditQuoteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditQuoteFile.Enabled = false;
            this.btnEditQuoteFile.Location = new System.Drawing.Point(297, 81);
            this.btnEditQuoteFile.Name = "btnEditQuoteFile";
            this.btnEditQuoteFile.Size = new System.Drawing.Size(45, 23);
            this.btnEditQuoteFile.TabIndex = 9;
            this.btnEditQuoteFile.Text = "Edit";
            this.btnEditQuoteFile.UseVisualStyleBackColor = true;
            this.btnEditQuoteFile.Click += new System.EventHandler(this.btnEditQuoteFile_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Background Opacity Percentage:";
            // 
            // nudBackgroundOpacityPercentage
            // 
            this.nudBackgroundOpacityPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBackgroundOpacityPercentage.Location = new System.Drawing.Point(257, 191);
            this.nudBackgroundOpacityPercentage.Name = "nudBackgroundOpacityPercentage";
            this.nudBackgroundOpacityPercentage.Size = new System.Drawing.Size(46, 20);
            this.nudBackgroundOpacityPercentage.TabIndex = 17;
            this.nudBackgroundOpacityPercentage.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(140, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Background Color:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(92, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Transparancy Alpha Value:";
            // 
            // nudTransparancyAlphaValue
            // 
            this.nudTransparancyAlphaValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTransparancyAlphaValue.Location = new System.Drawing.Point(257, 215);
            this.nudTransparancyAlphaValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudTransparancyAlphaValue.Name = "nudTransparancyAlphaValue";
            this.nudTransparancyAlphaValue.Size = new System.Drawing.Size(46, 20);
            this.nudTransparancyAlphaValue.TabIndex = 19;
            this.nudTransparancyAlphaValue.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(227, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Seconds To Display Quote (Per Word):";
            // 
            // txtBackgroundColor
            // 
            this.txtBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackgroundColor.BackColor = System.Drawing.SystemColors.Window;
            this.txtBackgroundColor.Location = new System.Drawing.Point(257, 143);
            this.txtBackgroundColor.Name = "txtBackgroundColor";
            this.txtBackgroundColor.ReadOnly = true;
            this.txtBackgroundColor.Size = new System.Drawing.Size(85, 20);
            this.txtBackgroundColor.TabIndex = 13;
            this.txtBackgroundColor.Click += new System.EventHandler(this.txtBackgroundHexColor_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(92, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Maximum Number Of Lines:";
            // 
            // nudMaxNumberOfLines
            // 
            this.nudMaxNumberOfLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMaxNumberOfLines.Location = new System.Drawing.Point(257, 239);
            this.nudMaxNumberOfLines.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMaxNumberOfLines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxNumberOfLines.Name = "nudMaxNumberOfLines";
            this.nudMaxNumberOfLines.Size = new System.Drawing.Size(46, 20);
            this.nudMaxNumberOfLines.TabIndex = 21;
            this.nudMaxNumberOfLines.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxNumberOfLines.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtLocalFileLocation
            // 
            this.txtLocalFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalFileLocation.Enabled = false;
            this.helpProvider1.SetHelpString(this.txtLocalFileLocation, "");
            this.txtLocalFileLocation.Location = new System.Drawing.Point(85, 82);
            this.txtLocalFileLocation.Name = "txtLocalFileLocation";
            this.helpProvider1.SetShowHelp(this.txtLocalFileLocation, true);
            this.txtLocalFileLocation.Size = new System.Drawing.Size(175, 20);
            this.txtLocalFileLocation.TabIndex = 7;
            this.txtLocalFileLocation.Leave += new System.EventHandler(this.txtLocalFileLocation_Leave);
            // 
            // lblLocalFile
            // 
            this.lblLocalFile.AutoSize = true;
            this.lblLocalFile.Enabled = false;
            this.lblLocalFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalFile.Location = new System.Drawing.Point(19, 85);
            this.lblLocalFile.Name = "lblLocalFile";
            this.lblLocalFile.Size = new System.Drawing.Size(66, 13);
            this.lblLocalFile.TabIndex = 6;
            this.lblLocalFile.Text = "Local File:";
            // 
            // fontDialog1
            // 
            this.fontDialog1.ShowColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(184, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Font Style:";
            // 
            // txtFontStyle
            // 
            this.txtFontStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFontStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtFontStyle.Location = new System.Drawing.Point(257, 120);
            this.txtFontStyle.Name = "txtFontStyle";
            this.txtFontStyle.ReadOnly = true;
            this.txtFontStyle.Size = new System.Drawing.Size(85, 20);
            this.txtFontStyle.TabIndex = 11;
            this.txtFontStyle.Click += new System.EventHandler(this.txtFontStyle_Click);
            this.txtFontStyle.SizeChanged += new System.EventHandler(this.txtFontStyle_SizeChanged);
            // 
            // nudSecondsToDisplayQuotePerWord
            // 
            this.nudSecondsToDisplayQuotePerWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSecondsToDisplayQuotePerWord.DecimalPlaces = 1;
            this.nudSecondsToDisplayQuotePerWord.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSecondsToDisplayQuotePerWord.Location = new System.Drawing.Point(257, 167);
            this.nudSecondsToDisplayQuotePerWord.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSecondsToDisplayQuotePerWord.Name = "nudSecondsToDisplayQuotePerWord";
            this.nudSecondsToDisplayQuotePerWord.Size = new System.Drawing.Size(46, 20);
            this.nudSecondsToDisplayQuotePerWord.TabIndex = 15;
            this.nudSecondsToDisplayQuotePerWord.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.nudSecondsToDisplayQuotePerWord.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFileDialog.Enabled = false;
            this.btnOpenFileDialog.Location = new System.Drawing.Point(266, 81);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(25, 23);
            this.btnOpenFileDialog.TabIndex = 8;
            this.btnOpenFileDialog.Text = "...";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(120, 303);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 23;
            this.btnTest.Text = "&Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCheckForUpdates
            // 
            this.btnCheckForUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckForUpdates.Location = new System.Drawing.Point(12, 303);
            this.btnCheckForUpdates.Name = "btnCheckForUpdates";
            this.btnCheckForUpdates.Size = new System.Drawing.Size(105, 23);
            this.btnCheckForUpdates.TabIndex = 22;
            this.btnCheckForUpdates.Text = "Check for &Updates";
            this.btnCheckForUpdates.UseVisualStyleBackColor = true;
            this.btnCheckForUpdates.Click += new System.EventHandler(this.btnCheckForUpdates_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(134, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Automatic Updates:";
            // 
            // cmbAutomaticUpdates
            // 
            this.cmbAutomaticUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAutomaticUpdates.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.cmbAutomaticUpdates, "Specifies where to get the text to display from");
            this.cmbAutomaticUpdates.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.cmbAutomaticUpdates.Location = new System.Drawing.Point(257, 264);
            this.cmbAutomaticUpdates.Name = "cmbAutomaticUpdates";
            this.helpProvider1.SetShowHelp(this.cmbAutomaticUpdates, true);
            this.cmbAutomaticUpdates.Size = new System.Drawing.Size(46, 21);
            this.cmbAutomaticUpdates.TabIndex = 27;
            this.cmbAutomaticUpdates.SelectedIndexChanged += new System.EventHandler(this.ValueChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(363, 338);
            this.Controls.Add(this.cmbAutomaticUpdates);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCheckForUpdates);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOpenFileDialog);
            this.Controls.Add(this.nudSecondsToDisplayQuotePerWord);
            this.Controls.Add(this.txtFontStyle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblLocalFile);
            this.Controls.Add(this.txtLocalFileLocation);
            this.Controls.Add(this.nudMaxNumberOfLines);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBackgroundColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudTransparancyAlphaValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudBackgroundOpacityPercentage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEditQuoteFile);
            this.Controls.Add(this.cmbQOTD_Type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkBigBox);
            this.Controls.Add(this.chkLaunchBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quote of the Day Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBackgroundOpacityPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransparancyAlphaValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxNumberOfLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecondsToDisplayQuotePerWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLaunchBox;
        private System.Windows.Forms.CheckBox chkBigBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbQOTD_Type;
        private System.Windows.Forms.Button btnEditQuoteFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBackgroundOpacityPercentage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudTransparancyAlphaValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox txtBackgroundColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudMaxNumberOfLines;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtLocalFileLocation;
        private System.Windows.Forms.Label lblLocalFile;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFontStyle;
        private System.Windows.Forms.NumericUpDown nudSecondsToDisplayQuotePerWord;
        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnCheckForUpdates;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAutomaticUpdates;
    }
}