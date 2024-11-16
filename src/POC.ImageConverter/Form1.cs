using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace POC.ImageConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBoxSecondStep.Enabled = false;
            groupBoxThirdStep.Enabled = false;
        }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ReadOnlyChecked = true;
            openFileDialog.ShowReadOnly = true;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.ico;*.gif;*.tiff;*.wmf;*.emf;*.exif;*.heic;*.heif;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxChosenImage.Image = Image.FromFile(openFileDialog.FileName);
                    groupBoxSecondStep.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Could not get the image", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxThirdStep.Enabled = true;
        }

        private void BtnConvertImage_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = GetFileExtensionToConvert();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                SaveImage(saveFileDialog.FileName);
            else
                MessageBox.Show("Please select an image", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private string GetFileExtensionToConvert()
        {
            if (radioButtonJPG.Checked) return "*.jpg|*.jpg";
            else if (radioButtonPNG.Checked) return "*.png|*.png";
            else if (radioButtonBMP.Checked) return "*.bmp|*.bmp";
            else if (radioButtonICON.Checked) return "*.ico|*.ico";
            else if (radioButtonGIF.Checked) return "*.gif|*.gif";
            else if (radioButtonTIFF.Checked) return "*.tiff|*.tiff";
            else if (radioButtonWMF.Checked) return "*.wmf|*.wmf";
            else if (radioButtonEMF.Checked) return "*.emf|*.emf";
            else if (radioButtonEXIF.Checked) return "*.exif|*.exif";
            else throw new Exception("Invalid image extension.");
        }

        private void SaveImage(string fileName)
        {
            try
            {
                var chosenImageFormat = GetImageFormatConvert();
                var chosenImage = pictureBoxChosenImage.Image;
                chosenImage.Save(fileName, chosenImageFormat);

                MessageBox.Show("Conversion performed successfully.", "Success!");
            }
            catch
            {
                MessageBox.Show("Could not convert image", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ImageFormat GetImageFormatConvert()
        {
            if (radioButtonJPG.Checked) return ImageFormat.Jpeg;
            else if (radioButtonPNG.Checked) return ImageFormat.Png;
            else if (radioButtonBMP.Checked) return ImageFormat.Bmp;
            else if (radioButtonICON.Checked) return ImageFormat.Icon;
            else if (radioButtonGIF.Checked) return ImageFormat.Gif;
            else if (radioButtonTIFF.Checked) return ImageFormat.Tiff;
            else if (radioButtonWMF.Checked) return ImageFormat.Wmf;
            else if (radioButtonEMF.Checked) return ImageFormat.Emf;
            else if (radioButtonEXIF.Checked) return ImageFormat.Exif;
            else throw new Exception("Invalid image format.");
        }
    }
}