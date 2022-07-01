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
            buttonConvertImage.Enabled = false;
        }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ReadOnlyChecked = true;
            openFileDialog.ShowReadOnly = true;
            openFileDialog.Filter = "*.jpg|*.jpg|*.bmp|*.bmp|*.gif|*.gif|*.png|*.png|*.ico|*.ico";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxChosenImage.Image = Image.FromFile(openFileDialog.FileName);
                    buttonConvertImage.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Could not get the image", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnConvertImage_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = GetChosenExtensionToFilter();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = saveFileDialog.FileName;
                var chosenImage = pictureBoxChosenImage.Image;
                var chosenImageFormat = GetChosenImageFormat();
                SaveConvertedImage(fileName, chosenImage, chosenImageFormat);
            }
            else
            {
                MessageBox.Show("Please select an image", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetChosenExtensionToFilter()
        {
            if (radioJPG.Checked) return "*.jpg|*.jpg";
            else if (radioGIF.Checked) return "*.gif|*.gif";
            else if (radioPNG.Checked) return "*.png|*.png";
            else if (radioBMP.Checked) return "*.bmp|*.bmp";
            else if (radioICON.Checked) return "*.ico|*.ico";
            else return "*.exif|*.exif";
        }

        private ImageFormat GetChosenImageFormat()
        {
            if (radioJPG.Checked) return ImageFormat.Jpeg;
            else if (radioGIF.Checked) return ImageFormat.Gif;
            else if (radioPNG.Checked) return ImageFormat.Png;
            else if (radioBMP.Checked) return ImageFormat.Bmp;
            else if (radioICON.Checked) return ImageFormat.Icon;
            else return ImageFormat.Exif;
        }

        private void SaveConvertedImage(string fileName, Image chosenImage, ImageFormat chosenImageFormat)
        {
            try
            {
                chosenImage.Save(fileName, chosenImageFormat);
                MessageBox.Show("Conversion performed successfully.", "Success!");
            }
            catch
            {
                MessageBox.Show("Could not convert image", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}