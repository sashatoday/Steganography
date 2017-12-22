using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace steganography
{
    public static class ImageProcessing
    {
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
                destX = System.Convert.ToInt16((newWidth - (sourceWidth * nPercent)) / 2);
            }
            else {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight - (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

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

        public static Bitmap EncodeTextToImage(string text, Bitmap imageBitmap)
        {
            int numBitsPerChar = 16;

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

        public static string DecodeTextFromImage(Bitmap imageBitmap)
        {
            int numBitsPerChar = 16;

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
                        if (decodedBinaryString.Length == numBitsPerChar) /*Found a complete char */
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
}
