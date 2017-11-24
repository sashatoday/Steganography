using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        private Image originalImage;
        private Image encodedImage;

        public UserForm()
        {
            InitializeComponent();
            SetMode(OperationMode.Encoding);
        }

        #region Help, About, Exit events

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

        #region Mode events

        private void radioButtonEncoding_CheckedChanged(object sender, EventArgs e)
        {
            SetMode(OperationMode.Encoding);
        }

        private void radioButtonDecoding_CheckedChanged(object sender, EventArgs e)
        {
            SetMode(OperationMode.Decoding);
        }

        #endregion

        private string ChooseImageFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            var result = openFileDialog.ShowDialog();
            return result == DialogResult.OK ? openFileDialog.FileName : null;
        }

        private bool LoadImage(string imageFileName)
        {
            try
            {
                originalImage = Image.FromFile(imageFileName);
                pictureBoxImage.Image =
                    ImageProcessing.ResizeImage(pictureBoxImage.Width, pictureBoxImage.Height, Image.FromFile(imageFileName));
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Failed to load image from file!" + Environment.NewLine + "Exception: " + exception.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region Encode/decode steps events

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            string imageFileName = ChooseImageFile();
            textBoxImagePath.Text = imageFileName;
            if (string.IsNullOrWhiteSpace(imageFileName)) return;
            if (!LoadImage(imageFileName)) return;
            buttonEncodeDecode.Enabled = true;
            labelLoadedImage.Text = "Loaded image: " + Path.GetFileName(imageFileName);
        }

        private void buttonEncodeDecode_Click(object sender, EventArgs e)
        {
            /*string imageFileName = textBoxImagePath.Text;
            if (string.IsNullOrWhiteSpace(imageFileName))
            {
                MessageBox.Show(this, "Choose image file name!", "Error");
                buttonEncodeDecode.Enabled = false;
                return;
            }*/

        }

        #endregion
    }

    public static class ImageProcessing
    {
        /// Code taken from https://stackoverflow.com/a/1922086/2523211 
        public static Image ResizeImage(int newWidth, int newHeight, Image imgPhoto)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                                                (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                                                (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
    }
}