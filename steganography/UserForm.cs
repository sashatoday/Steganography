using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace steganography {
    public partial class UserForm : Form {
        enum OperationMode {
            Encoding,
            Decoding
        }

        private Image originalImage;
        private Image encodedImage;
        private byte[] encryptionKey;
        private string currentDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public UserForm() {
            InitializeComponent();
            SetMode(OperationMode.Encoding);
        }

        #region Help, About, Exit, Reset events

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            HelpForm helpForm;
            (helpForm = new HelpForm()).CreateControl();
            helpForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutProgramForm aboutProgramForm;
            (aboutProgramForm = new AboutProgramForm()).CreateControl();
            aboutProgramForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void buttonReset_Click(object sender, EventArgs e) {
            buttonEncodeDecode.Enabled = false;
            richTextBoxTextData.Clear();
            labelLoadedImage.Text = "No image";
            labelImageFileSize.Text = "";
            textBoxImagePath.Clear();
            textBoxEncryptionKey.Clear();
            pictureBoxImage.Image = null;
        }

        #endregion

        #region Mode events

        private void SetMode(OperationMode mode) {
            if (mode == OperationMode.Encoding) {
                buttonEncodeDecode.Text = "Encode";
                groupBoxStep2.Text = "Step 2: Write secret message below and click 'Encode'";
            } else {
                buttonEncodeDecode.Text = "Decode";
                groupBoxStep2.Text = "Step 2: Click 'Decode' and read secret message below";
            }
        }

        private void radioButtonEncoding_CheckedChanged(object sender, EventArgs e) {
            SetMode(OperationMode.Encoding);
        }

        private void radioButtonDecoding_CheckedChanged(object sender, EventArgs e) {
            SetMode(OperationMode.Decoding);
        }

        #endregion

        #region Extra private functions

        private string getAppropriateSize(double size) {
            if (size < 1024) {
                return String.Format("{0:0.##} bytes", size);
            } else {
                size /= 1024;
                if (size < 1024) {
                    return String.Format("{0:0.##} Kb", size);
                } else {
                    size /= 1024;
                    if (size < 1024) {
                        return String.Format("{0:0.##} Mb", size);
                    } else {
                        return String.Format("{0:0.##} Gb", size);
                    }

                }
            }
        }

        private string chooseImageFile() {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                InitialDirectory = currentDirectoryPath,
                Filter = "Image Files(*.BMP;*.JPG;*PNG;*.GIF)|*.BMP;*.JPG;*PNG;*.GIF",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                currentDirectoryPath = Path.GetDirectoryName(openFileDialog.FileName);
                return openFileDialog.FileName;
            } else
                return null;
        }

        private long loadImage(string imageFileName) {
            try {
                originalImage = Image.FromFile(imageFileName);
                pictureBoxImage.Image =
                    ImageProcessing.ResizeImage(pictureBoxImage.Width, pictureBoxImage.Height, Image.FromFile(imageFileName));
            } catch (Exception exception) {
                MessageBox.Show("Failed to load image from file!" + Environment.NewLine +
                    Environment.NewLine + "Exception: " + exception.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return new FileInfo(imageFileName).Length;
        }

        private bool saveImage(string imageFileName) {
            var saveFileDialog = new SaveFileDialog {
                InitialDirectory = currentDirectoryPath,
                Filter = "Image Files(*.BMP;*.JPG;*PNG;*.GIF)|*.BMP;*.JPG;*PNG;*.GIF",
                FileName = Path.GetFileNameWithoutExtension(imageFileName) + "_encoded.bmp"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                encodedImage.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                currentDirectoryPath = Path.GetDirectoryName(saveFileDialog.FileName);
                return true;
            } else return false;
        }

        private string encryptText(string text, byte[] key) {
            if (radioButtonAES.Checked) return AES.Encrypt(text, key);
            else return TripleDES.Encrypt(text, key);
        }

        private string decryptText(string text, byte[] key) {
            if (radioButtonAES.Checked) return AES.Decrypt(text, key);
            else return TripleDES.Decrypt(text, key);
        }

        private byte[] computeHashKey(string keyData) {
            byte[] keyBytes = Encoding.ASCII.GetBytes(textBoxEncryptionKey.Text);
            HashAlgorithm hashAlgorithm;
            if (comboBoxHashAlgorithm.Text == "SHA-256") {
                hashAlgorithm = new SHA256CryptoServiceProvider();
                return hashAlgorithm.ComputeHash(keyBytes);
            } else if (comboBoxHashAlgorithm.Text == "SHA-512") {
                hashAlgorithm = new SHA512CryptoServiceProvider();
                return hashAlgorithm.ComputeHash(keyBytes);
            } else {
                hashAlgorithm = new MD5CryptoServiceProvider();
                return hashAlgorithm.ComputeHash(keyBytes);
            }
        }

        #endregion

        #region Encode/decode steps events

        private void buttonBrowse_Click(object sender, EventArgs e) {
            long imageSize;
            string imageFileName = chooseImageFile();

            textBoxImagePath.Text = imageFileName;
            if (string.IsNullOrWhiteSpace(imageFileName)) return;
            imageSize = loadImage(imageFileName);
            if (imageSize == -1) return;

            buttonEncodeDecode.Enabled = true;
            labelLoadedImage.Text = "Loaded image: " + Path.GetFileName(imageFileName);
            labelImageFileSize.Text = "Size: " + getAppropriateSize(imageSize);
        }

        private void buttonEncodeDecode_Click(object sender, EventArgs e) {
            string imageFileName = textBoxImagePath.Text;
            string encryptedData = "";
            string key = textBoxEncryptionKey.Text;

            if (string.IsNullOrWhiteSpace(imageFileName)) {
                MessageBox.Show(this, "Choose an image file name!", "Error");
                buttonEncodeDecode.Enabled = false;
                return;
            }
            if (string.IsNullOrWhiteSpace(key)) {
                MessageBox.Show(this, "Write a key to encrypt text!", "Error");
                return;
            }

            encryptionKey = computeHashKey(key);

            if (radioButtonEncoding.Checked) {
                string textData = richTextBoxTextData.Text;
                if (string.IsNullOrWhiteSpace(textData)) {
                    MessageBox.Show(this, "Write a secret message!", "Error");
                    return;
                }
                try {
                    encryptedData = encryptText(textData, encryptionKey);
                } catch (Exception exception) {
                    MessageBox.Show("Failed to encrypt text!" + Environment.NewLine +
                        Environment.NewLine + "Exception: " + exception.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try {
                    encodedImage = ImageProcessing.EncodeTextToImage(encryptedData, (Bitmap)originalImage.Clone());
                } catch (Exception exception) {
                    MessageBox.Show("Failed to encode text to image!" + Environment.NewLine +
                        Environment.NewLine + "Exception: " + exception.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try {
                    if (!saveImage(imageFileName)) return;
                } catch {
                    MessageBox.Show("Failed to save image!" + Environment.NewLine + Environment.NewLine +
                        "You can not overwrite an image" + Environment.NewLine +
                        "that has already been opened in this program",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } else {
                richTextBoxTextData.Text = "";
                try {
                    encryptedData = ImageProcessing.DecodeTextFromImage((Bitmap)originalImage.Clone());
                } catch (Exception exception) {
                    MessageBox.Show("Failed to decode text from image!" + Environment.NewLine +
                        Environment.NewLine + "Exception: " + exception.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try {
                    richTextBoxTextData.Text = decryptText(encryptedData, encryptionKey);
                } catch (Exception exception) {
                    MessageBox.Show("Failed to decrypt text!" + Environment.NewLine +
                        Environment.NewLine + "Exception: " + exception.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        #endregion
    }
}