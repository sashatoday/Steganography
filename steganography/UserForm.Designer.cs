namespace steganography
{
    partial class UserForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.groupBoxEnDecSteps = new System.Windows.Forms.GroupBox();
            this.radioButtonDecoding = new System.Windows.Forms.RadioButton();
            this.radioButtonEncoding = new System.Windows.Forms.RadioButton();
            this.groupBoxStep2 = new System.Windows.Forms.GroupBox();
            this.buttonEncodeDecode = new System.Windows.Forms.Button();
            this.groupBoxStep1 = new System.Windows.Forms.GroupBox();
            this.textBoxImagePath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.richTextBoxTextData = new System.Windows.Forms.RichTextBox();
            this.labelMessageState = new System.Windows.Forms.Label();
            this.labelLoadedImage = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxEncryptionKey = new System.Windows.Forms.TextBox();
            this.labelEncryptionKey = new System.Windows.Forms.Label();
            this.labelTextAlgorithm = new System.Windows.Forms.Label();
            this.radioButtonAES = new System.Windows.Forms.RadioButton();
            this.radioButton3DES = new System.Windows.Forms.RadioButton();
            this.labelHashAlgorithm = new System.Windows.Forms.Label();
            this.comboBoxHashAlgorithm = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxEnDecSteps.SuspendLayout();
            this.groupBoxStep2.SuspendLayout();
            this.groupBoxStep1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxEnDecSteps
            // 
            this.groupBoxEnDecSteps.Controls.Add(this.radioButtonDecoding);
            this.groupBoxEnDecSteps.Controls.Add(this.radioButtonEncoding);
            this.groupBoxEnDecSteps.Controls.Add(this.groupBoxStep2);
            this.groupBoxEnDecSteps.Controls.Add(this.groupBoxStep1);
            this.groupBoxEnDecSteps.Location = new System.Drawing.Point(25, 57);
            this.groupBoxEnDecSteps.Name = "groupBoxEnDecSteps";
            this.groupBoxEnDecSteps.Size = new System.Drawing.Size(339, 187);
            this.groupBoxEnDecSteps.TabIndex = 0;
            this.groupBoxEnDecSteps.TabStop = false;
            // 
            // radioButtonDecoding
            // 
            this.radioButtonDecoding.AutoSize = true;
            this.radioButtonDecoding.Location = new System.Drawing.Point(107, 17);
            this.radioButtonDecoding.Name = "radioButtonDecoding";
            this.radioButtonDecoding.Size = new System.Drawing.Size(71, 17);
            this.radioButtonDecoding.TabIndex = 2;
            this.radioButtonDecoding.TabStop = true;
            this.radioButtonDecoding.Text = "Decoding";
            this.radioButtonDecoding.UseVisualStyleBackColor = true;
            this.radioButtonDecoding.CheckedChanged += new System.EventHandler(this.radioButtonDecoding_CheckedChanged);
            // 
            // radioButtonEncoding
            // 
            this.radioButtonEncoding.AutoSize = true;
            this.radioButtonEncoding.Checked = true;
            this.radioButtonEncoding.Location = new System.Drawing.Point(18, 17);
            this.radioButtonEncoding.Name = "radioButtonEncoding";
            this.radioButtonEncoding.Size = new System.Drawing.Size(70, 17);
            this.radioButtonEncoding.TabIndex = 2;
            this.radioButtonEncoding.TabStop = true;
            this.radioButtonEncoding.Text = "Encoding";
            this.radioButtonEncoding.UseVisualStyleBackColor = true;
            this.radioButtonEncoding.CheckedChanged += new System.EventHandler(this.radioButtonEncoding_CheckedChanged);
            // 
            // groupBoxStep2
            // 
            this.groupBoxStep2.Controls.Add(this.buttonEncodeDecode);
            this.groupBoxStep2.Location = new System.Drawing.Point(6, 110);
            this.groupBoxStep2.Name = "groupBoxStep2";
            this.groupBoxStep2.Size = new System.Drawing.Size(327, 67);
            this.groupBoxStep2.TabIndex = 1;
            this.groupBoxStep2.TabStop = false;
            this.groupBoxStep2.Text = "Step 2: Write a secret message below and click \'Encode\'";
            // 
            // buttonEncodeDecode
            // 
            this.buttonEncodeDecode.Enabled = false;
            this.buttonEncodeDecode.Location = new System.Drawing.Point(10, 29);
            this.buttonEncodeDecode.Name = "buttonEncodeDecode";
            this.buttonEncodeDecode.Size = new System.Drawing.Size(57, 23);
            this.buttonEncodeDecode.TabIndex = 0;
            this.buttonEncodeDecode.Text = "Encode";
            this.buttonEncodeDecode.UseVisualStyleBackColor = true;
            this.buttonEncodeDecode.Click += new System.EventHandler(this.buttonEncodeDecode_Click);
            // 
            // groupBoxStep1
            // 
            this.groupBoxStep1.Controls.Add(this.textBoxImagePath);
            this.groupBoxStep1.Controls.Add(this.buttonBrowse);
            this.groupBoxStep1.Location = new System.Drawing.Point(6, 41);
            this.groupBoxStep1.Name = "groupBoxStep1";
            this.groupBoxStep1.Size = new System.Drawing.Size(327, 62);
            this.groupBoxStep1.TabIndex = 0;
            this.groupBoxStep1.TabStop = false;
            this.groupBoxStep1.Text = "Step 1: Choose an image";
            // 
            // textBoxImagePath
            // 
            this.textBoxImagePath.Location = new System.Drawing.Point(74, 25);
            this.textBoxImagePath.Name = "textBoxImagePath";
            this.textBoxImagePath.Size = new System.Drawing.Size(243, 20);
            this.textBoxImagePath.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(10, 23);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(57, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // richTextBoxTextData
            // 
            this.richTextBoxTextData.Location = new System.Drawing.Point(25, 279);
            this.richTextBoxTextData.Name = "richTextBoxTextData";
            this.richTextBoxTextData.Size = new System.Drawing.Size(339, 170);
            this.richTextBoxTextData.TabIndex = 2;
            this.richTextBoxTextData.Text = "";
            // 
            // labelMessageState
            // 
            this.labelMessageState.AutoSize = true;
            this.labelMessageState.Location = new System.Drawing.Point(28, 259);
            this.labelMessageState.Name = "labelMessageState";
            this.labelMessageState.Size = new System.Drawing.Size(86, 13);
            this.labelMessageState.TabIndex = 3;
            this.labelMessageState.Text = "Secret message:";
            // 
            // labelLoadedImage
            // 
            this.labelLoadedImage.AutoEllipsis = true;
            this.labelLoadedImage.Location = new System.Drawing.Point(386, 66);
            this.labelLoadedImage.Name = "labelLoadedImage";
            this.labelLoadedImage.Size = new System.Drawing.Size(500, 13);
            this.labelLoadedImage.TabIndex = 4;
            this.labelLoadedImage.Text = "No image";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(25, 28);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxEncryptionKey
            // 
            this.textBoxEncryptionKey.Location = new System.Drawing.Point(150, 503);
            this.textBoxEncryptionKey.Name = "textBoxEncryptionKey";
            this.textBoxEncryptionKey.Size = new System.Drawing.Size(214, 20);
            this.textBoxEncryptionKey.TabIndex = 10;
            // 
            // labelEncryptionKey
            // 
            this.labelEncryptionKey.AutoSize = true;
            this.labelEncryptionKey.Location = new System.Drawing.Point(23, 506);
            this.labelEncryptionKey.Name = "labelEncryptionKey";
            this.labelEncryptionKey.Size = new System.Drawing.Size(122, 13);
            this.labelEncryptionKey.TabIndex = 11;
            this.labelEncryptionKey.Text = "Enter an encryption key:";
            // 
            // labelTextAlgorithm
            // 
            this.labelTextAlgorithm.AutoSize = true;
            this.labelTextAlgorithm.Location = new System.Drawing.Point(22, 474);
            this.labelTextAlgorithm.Name = "labelTextAlgorithm";
            this.labelTextAlgorithm.Size = new System.Drawing.Size(182, 13);
            this.labelTextAlgorithm.TabIndex = 12;
            this.labelTextAlgorithm.Text = "Text encryption/decryption algorithm:";
            // 
            // radioButtonAES
            // 
            this.radioButtonAES.AutoSize = true;
            this.radioButtonAES.Checked = true;
            this.radioButtonAES.Location = new System.Drawing.Point(210, 472);
            this.radioButtonAES.Name = "radioButtonAES";
            this.radioButtonAES.Size = new System.Drawing.Size(46, 17);
            this.radioButtonAES.TabIndex = 13;
            this.radioButtonAES.TabStop = true;
            this.radioButtonAES.Text = "AES";
            this.radioButtonAES.UseVisualStyleBackColor = true;
            // 
            // radioButton3DES
            // 
            this.radioButton3DES.AutoSize = true;
            this.radioButton3DES.Location = new System.Drawing.Point(273, 472);
            this.radioButton3DES.Name = "radioButton3DES";
            this.radioButton3DES.Size = new System.Drawing.Size(53, 17);
            this.radioButton3DES.TabIndex = 14;
            this.radioButton3DES.Text = "3DES";
            this.radioButton3DES.UseVisualStyleBackColor = true;
            // 
            // labelHashAlgorithm
            // 
            this.labelHashAlgorithm.AutoSize = true;
            this.labelHashAlgorithm.Location = new System.Drawing.Point(23, 537);
            this.labelHashAlgorithm.Name = "labelHashAlgorithm";
            this.labelHashAlgorithm.Size = new System.Drawing.Size(77, 13);
            this.labelHashAlgorithm.TabIndex = 15;
            this.labelHashAlgorithm.Text = "Hash algorithm";
            // 
            // comboBoxHashAlgorithm
            // 
            this.comboBoxHashAlgorithm.FormattingEnabled = true;
            this.comboBoxHashAlgorithm.Items.AddRange(new object[] {
            "SHA-256",
            "SHA-512",
            "MD5"});
            this.comboBoxHashAlgorithm.Location = new System.Drawing.Point(127, 534);
            this.comboBoxHashAlgorithm.Name = "comboBoxHashAlgorithm";
            this.comboBoxHashAlgorithm.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHashAlgorithm.TabIndex = 16;
            this.comboBoxHashAlgorithm.Text = "SHA-256";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 26);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(389, 96);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(583, 410);
            this.pictureBoxImage.TabIndex = 5;
            this.pictureBoxImage.TabStop = false;
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.menuToolStripMenuItem.BackgroundImage = global::steganography.Properties.Resources.Без_названия;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Padding = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 576);
            this.Controls.Add(this.comboBoxHashAlgorithm);
            this.Controls.Add(this.labelHashAlgorithm);
            this.Controls.Add(this.radioButton3DES);
            this.Controls.Add(this.radioButtonAES);
            this.Controls.Add(this.labelTextAlgorithm);
            this.Controls.Add(this.labelEncryptionKey);
            this.Controls.Add(this.textBoxEncryptionKey);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.labelLoadedImage);
            this.Controls.Add(this.labelMessageState);
            this.Controls.Add(this.richTextBoxTextData);
            this.Controls.Add(this.groupBoxEnDecSteps);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Encryption by Image Steganography";
            this.groupBoxEnDecSteps.ResumeLayout(false);
            this.groupBoxEnDecSteps.PerformLayout();
            this.groupBoxStep2.ResumeLayout(false);
            this.groupBoxStep1.ResumeLayout(false);
            this.groupBoxStep1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonEncoding;
        private System.Windows.Forms.GroupBox groupBoxStep2;
        private System.Windows.Forms.GroupBox groupBoxStep1;
        private System.Windows.Forms.RadioButton radioButtonDecoding;
        private System.Windows.Forms.GroupBox groupBoxEnDecSteps;
        private System.Windows.Forms.RichTextBox richTextBoxTextData;
        private System.Windows.Forms.Label labelMessageState;
        private System.Windows.Forms.Label labelLoadedImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonEncodeDecode;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxEncryptionKey;
        private System.Windows.Forms.Label labelEncryptionKey;
        private System.Windows.Forms.Label labelTextAlgorithm;
        private System.Windows.Forms.RadioButton radioButtonAES;
        private System.Windows.Forms.RadioButton radioButton3DES;
        private System.Windows.Forms.Label labelHashAlgorithm;
        private System.Windows.Forms.ComboBox comboBoxHashAlgorithm;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

