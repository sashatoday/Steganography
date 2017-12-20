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

        #region Help, About, Exit, Reset events

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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            buttonEncodeDecode.Enabled = false;
            richTextBoxTextData.Clear();
            labelLoadedImage.Text = "No image";
            textBoxImagePath.Clear();
            pictureBoxImage.Image = null;
        }

        #endregion

        #region Mode events

        private void SetMode(OperationMode mode)
        {
            currentMode = mode;
            if (mode == OperationMode.Encoding)
            {
                buttonEncodeDecode.Text = "Encode";
                groupBoxStep2.Text = "Step 2: Write secret message below and click 'Encode'";
            }
            else
            {
                buttonEncodeDecode.Text = "Decode";
                groupBoxStep2.Text = "Step 2: Click 'Decode' and read secret message below";
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

        #endregion

        #region Browse functions

        private string ChooseImageFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Filter = "Image Files(*.BMP;*.JPG;*PNG)|*.BMP;*.JPG;*PNG",
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

        #endregion

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
            string imageFileName = textBoxImagePath.Text;
            string textData = richTextBoxTextData.Text;
            if (string.IsNullOrWhiteSpace(imageFileName))
            {
                MessageBox.Show(this, "Choose image file name!", "Error");
                buttonEncodeDecode.Enabled = false;
                return;
            }
            if (currentMode == OperationMode.Encoding)
            {
                if (string.IsNullOrWhiteSpace(textData))
                {
                    MessageBox.Show(this, "Write a secret message!", "Error");
                    return;
                }
                encodedImage = ImageProcessing.EncodeTextToImage(textData, (Bitmap)originalImage.Clone());

                var saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    Filter = @"Image Files(*.BMP;)|*.BMP",
                    FileName = Path.GetFileNameWithoutExtension(imageFileName) + "_encoded.bmp"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    encodedImage.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                }
            }
            else
            {
                richTextBoxTextData.Text = ImageProcessing.DecodeTextFromImage((Bitmap)originalImage.Clone());
            }
        }

        #endregion
    }

    #region class ImageProcessing

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

        public static Color ColorFromByteArray(byte[] bytes)
        {
            return Color.FromArgb(bytes[0], bytes[1], bytes[2]);
        }

        private static byte[] ByteArrayFromColor(Color pixel)
        {
            return new[] { pixel.R, pixel.G, pixel.B };
        }

        private static byte[] PixelToMaskedByteArray(Color pixel)
        {
            return ByteArrayFromColor(pixel).Select(b => (byte)(b & 0xFE)).ToArray();
        }

        private static string CharToBinaryString(char c, int len)
        {
            var bitsString = Convert.ToString(c, 2); //Converting the char with base-2 to a binary string
            return bitsString.PadLeft(len).Replace(' ', '0'); //Padding with up to len '0' bits on the left (with len=8: '110101' --> '00110101')
        }

        /// <summary>
        /// Manipulate the image by changing each pixel's least significant bit (LSB) to hold a single bit from the given text string
        /// 
        /// Currently only works with ASCII charachters
        /// The algorithm overview:
        ///     Given an image and a text string (char array), we will go over the image and bit by bit 
        ///      we will copy bits from the text string and replace the LSB a each bytes of the pixel.
        ///      This means that for each pixel in the image we hide 3 bits from the input string (Assuming RGB format)
        /// The algorithm in practice:
        ///     Do:
        ///         Point to first bit of the string.
        ///         Go over each pixel of the image (Each pixel consists of 3 bytes: R,G,B)
        ///             If string pointer points to end of the string:
        ///                 Continue to next pixel
        ///             Else:
        ///                 Take the next 3 bits from the string (from where the pointer is pointing) and place them in the LSB of 
        ///                  the R, G and B bytes of the pixel (in that order)
        ///                 Advance the string pointer to next 3 bits
        ///     Until all text bits were placed in pixels and a trailing '\0' char was place in the trailing pixels or all pixels have be traversed
        /// </summary>
        /// <param name="text">Given text to hide in image</param>
        /// <param name="imageBitmap">The image in which text should be hidden</param>
        /// <returns>Image containing the hidden text</returns>
        public static Bitmap EncodeTextToImage(string text, Bitmap imageBitmap)
        {
            int numBitsPerChar = 8;
            numBitsPerChar = 16;

            int charIndexInText = 0; //A pointer to the character (from the text string) that we are currently hiding 
            string currentCharFromTextBinaryString = CharToBinaryString(text[0], numBitsPerChar); //a binary-string that represents the bits of the charachter we are currently hiding

            //Go over each pixel in the image
            for (int i = 0; i < imageBitmap.Height; i++)
            {
                for (int j = 0; j < imageBitmap.Width; j++)
                {
                    //Clear the LSB for all bytes of the pixel
                    byte[] maskedPixel = PixelToMaskedByteArray(imageBitmap.GetPixel(j, i));

                    //For each pixel write 3 bits from the text string and write to LSB of the pixel's bytes
                    for (int k = 0; k < maskedPixel.Length; k++)
                    {
                        //If we have read an entire character from the text (taken 8 bits, assuming ASCII), 
                        //then we can move to the next character
                        if (currentCharFromTextBinaryString == string.Empty)
                        {
                            //Since at this point we've read an entire character- if we have read all text 
                            // then we have also written a '\0' to the image (to indicate complete end of hidden text)
                            if (charIndexInText == text.Length)
                            {
                                if (k > 0)
                                {
                                    //In case we have changed only some of the bits while writing '\0', we need to make sure they will be written
                                    imageBitmap.SetPixel(j, i, ColorFromByteArray(maskedPixel));
                                }
                                return imageBitmap; //all text was wrriten with the addition of '\0'
                            }
                            //We've finished hiding a single char from the string, advance to next one
                            charIndexInText++;
                            //If the last chararcter was hidden, start writing zeros
                            currentCharFromTextBinaryString = charIndexInText < text.Length
                                ? CharToBinaryString(text[charIndexInText], numBitsPerChar) //Read next charachter
                                : CharToBinaryString('\0', numBitsPerChar);                 //Write null termination (0)
                        }

                        //Set LSB to hold bit number  (maskedPixel's LSB is zero so we simply add a bit to it (either 1 or 0)
                        maskedPixel[k] += Convert.ToByte(Convert.ToInt32(currentCharFromTextBinaryString[0].ToString(), 2));
                        //remove the first bit from the binary-string (We're actually writing the bits in reverse order)
                        currentCharFromTextBinaryString = currentCharFromTextBinaryString.Substring(1);
                    }
                    //Write the edited pixel back to the image
                    imageBitmap.SetPixel(j, i, ColorFromByteArray(maskedPixel));
                }
            }
            return imageBitmap;
        }

        /// <summary>
        /// Extracts hidden text from an image with encoded text in the pixels
        /// 
        /// The Algorithm for extracting the text is the reverse of the Encoding process.
        /// For each pixel in the image, go over each byte of the pixel, take the LSB from the pixel's bytes and concatante them while keeping order: R, G, B.
        /// Keep concatanating bits until the number of bits per text character has reached, and conver these N bits to a single char. Store this char in an array of chars (E.g string).
        /// </summary>
        /// <param name="imageBitmap">An image containing encoded text</param>
        /// <returns>The hidden text from the image</returns>
        public static string DecodeTextFromImage(Bitmap imageBitmap)
        {
            int numBitsPerChar = 8;
            numBitsPerChar = 16;

            string decodedText = string.Empty;
            string decodedBinaryString = string.Empty;

            //Go over each pixel in the image
            for (int i = 0; i < imageBitmap.Height; i++)
            {
                for (int j = 0; j < imageBitmap.Width; j++)
                {
                    byte[] pixel = ByteArrayFromColor(imageBitmap.GetPixel(j, i));

                    //For each pixel we need to read 3 bits from the text string and write to LSB of the pixels
                    foreach (byte b in pixel)
                    {
                        if (decodedBinaryString.Length == numBitsPerChar) //Found a complete char
                        {
                            //Convert the collected bits to a char
                            char decodedChar = Convert.ToChar(Convert.ToInt32(decodedBinaryString, 2));
                            if (decodedChar == '\0')
                            {
                                //Found the trailing zeros that indicate end of text
                                return decodedText; //no need to push this character (string does it itself)
                            }
                            //Append the newly found char to the resulting string
                            decodedText += decodedChar;
                            decodedBinaryString = string.Empty; //reset binary string
                        }
                        //Collect the LSB of the byte of the pixel
                        decodedBinaryString += b & 0x1;
                    }
                }
            }
            //We might have read all the image without finding a trailing null termination char, so return whatever we found
            return decodedText;
        }
    }

    #endregion
}