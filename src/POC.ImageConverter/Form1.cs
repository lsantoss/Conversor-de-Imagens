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
            btnConverterImagem.Enabled = false;
        }

        private void btnEscolherImagem_Click(object sender, EventArgs e)
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
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    btnConverterImagem.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Não foi possível obter a imagem", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConverterImagem_Click(object sender, EventArgs e)
        {
            Image imagemConvertida = pictureBox.Image;
            saveFileDialog.Filter = FiltroExtensao();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (radioJPG.Checked)
                    {
                        imagemConvertida.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                    }
                    else if (radioGIF.Checked)
                    {
                        imagemConvertida.Save(saveFileDialog.FileName, ImageFormat.Gif);
                    }
                    else if (radioPNG.Checked)
                    {
                        imagemConvertida.Save(saveFileDialog.FileName, ImageFormat.Png);
                    }
                    else if (radioBMP.Checked)
                    {
                        imagemConvertida.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                    }
                    else if (radioICON.Checked)
                    {
                        imagemConvertida.Save(saveFileDialog.FileName, ImageFormat.Icon);
                    }
                    else if (radioEXIF.Checked)
                    {
                        imagemConvertida.Save(saveFileDialog.FileName, ImageFormat.Exif);
                    }

                    MessageBox.Show("Conversão realizada com sucesso.", "Sucesso!");
                }
                catch
                {
                    MessageBox.Show("Não é possivel converter a imagem", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("A imagem não é válida", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string FiltroExtensao()
        {
            if (radioJPG.Checked) return "*.jpg|*.jpg";
            if (radioGIF.Checked) return "*.gif|*.gif";
            if (radioPNG.Checked) return "*.png|*.png";
            if (radioBMP.Checked) return "*.bmp|*.bmp";
            if (radioICON.Checked) return "*.ico|*.ico";
            if (radioEXIF.Checked) return "*.exif|*.exif";
            return string.Empty;
        }
    }
}