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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxEnDecSteps.SuspendLayout();
            this.groupBoxStep2.SuspendLayout();
            this.groupBoxStep1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxEnDecSteps
            // 
            this.groupBoxEnDecSteps.Controls.Add(this.radioButtonDecoding);
            this.groupBoxEnDecSteps.Controls.Add(this.radioButtonEncoding);
            this.groupBoxEnDecSteps.Controls.Add(this.groupBoxStep2);
            this.groupBoxEnDecSteps.Controls.Add(this.groupBoxStep1);
            this.groupBoxEnDecSteps.Location = new System.Drawing.Point(25, 11);
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
            this.groupBoxStep2.Text = "Step 2: Write secret message below and click \'Encode\'";
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
            this.groupBoxStep1.Text = "Step 1: Choose an Image";
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
            this.richTextBoxTextData.Location = new System.Drawing.Point(25, 233);
            this.richTextBoxTextData.Name = "richTextBoxTextData";
            this.richTextBoxTextData.Size = new System.Drawing.Size(339, 170);
            this.richTextBoxTextData.TabIndex = 2;
            this.richTextBoxTextData.Text = "";
            // 
            // labelMessageState
            // 
            this.labelMessageState.AutoSize = true;
            this.labelMessageState.Location = new System.Drawing.Point(28, 213);
            this.labelMessageState.Name = "labelMessageState";
            this.labelMessageState.Size = new System.Drawing.Size(86, 13);
            this.labelMessageState.TabIndex = 3;
            this.labelMessageState.Text = "Secret message:";
            // 
            // labelLoadedImage
            // 
            this.labelLoadedImage.AutoEllipsis = true;
            this.labelLoadedImage.Location = new System.Drawing.Point(386, 20);
            this.labelLoadedImage.Name = "labelLoadedImage";
            this.labelLoadedImage.Size = new System.Drawing.Size(500, 13);
            this.labelLoadedImage.TabIndex = 4;
            this.labelLoadedImage.Text = "No image";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(389, 50);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(583, 363);
            this.pictureBoxImage.TabIndex = 5;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(897, 419);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(704, 419);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonHelp.TabIndex = 7;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(801, 419);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(75, 23);
            this.buttonAbout.TabIndex = 8;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(607, 419);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 457);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.labelLoadedImage);
            this.Controls.Add(this.labelMessageState);
            this.Controls.Add(this.richTextBoxTextData);
            this.Controls.Add(this.groupBoxEnDecSteps);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Encryption by Image Steganography";
            this.groupBoxEnDecSteps.ResumeLayout(false);
            this.groupBoxEnDecSteps.PerformLayout();
            this.groupBoxStep2.ResumeLayout(false);
            this.groupBoxStep1.ResumeLayout(false);
            this.groupBoxStep1.PerformLayout();
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
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonEncodeDecode;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.Button buttonReset;
    }
}

