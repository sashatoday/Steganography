using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace steganography
{
    public partial class UserForm : Form
    {
        enum OperationMode
        {
            Encoding,
            Decoding
        }
        
        private OperationMode currentMode;

        public UserForm()
        {
            InitializeComponent();
            SetMode(OperationMode.Encoding);
        }

        #region Help, About, Exit clicks

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Author: Zhuravleva Aleksandra © 2017");
            AboutProgramForm aboutProgramForm;
            (aboutProgramForm = new AboutProgramForm()).CreateControl();
            aboutProgramForm.ShowDialog();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("The application allows you to encrypt a message into an image and decrypt text from the image back");
            HelpForm helpForm;
            (helpForm = new HelpForm()).CreateControl();
            helpForm.ShowDialog();
        }

        #endregion

        private void SetMode(OperationMode mode)
        {
            currentMode = mode;
            if (mode == OperationMode.Encoding)
            {
                buttonEncodeDecode.Text = "Encode";
                groupBoxStep2.Text = "Write secret message below and click 'Encode'";
            }
            else
            {
                buttonEncodeDecode.Text = "Decode";
                groupBoxStep2.Text = "Click 'Decode' and read secret message below";
            }
        }

        private void radioButtonEncoding_CheckedChanged(object sender, EventArgs e)
        {
            SetMode(OperationMode.Encoding);
        }

        private void radioButtonDecoding_CheckedChanged(object sender, EventArgs e)
        {
            SetMode(OperationMode.Decoding);
        }

    }
}
