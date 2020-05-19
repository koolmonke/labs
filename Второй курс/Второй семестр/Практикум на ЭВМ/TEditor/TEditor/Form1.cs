using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RTFDefaultFont = MainTextBox.Font;
        }

        private readonly Font RTFDefaultFont;
        private const string FileNameExtFilter = "RTF файл (*.rtf)|*.rtf|Текстовый файл (*.txt)|*.txt|Все файлы (*.*)|*.*";
        private const string rtf = ".rtf";

        #region Работа с файлом

        private Utils.File FileHandler = null;

        private void новыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileHandler = null;
            this.Text = "Новый файл - Notepad--";
            MainTextBox.Clear();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = FileNameExtFilter,
                RestoreDirectory = true,
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileHandler = new Utils.File(openFileDialog.FileName);
                    if (Path.GetExtension(FileHandler.FileName).ToLower() == rtf)
                        MainTextBox.Rtf = FileHandler.Content;
                    else
                        MainTextBox.Text = FileHandler.Content;

                    this.Text = $"{Path.GetFileName(FileHandler.FileName)} - Notepad--";
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileHandler is null)
                сохранитьКакToolStripMenuItem_Click(sender, e);
            else
                FileHandler.Content = Path.GetExtension(FileHandler.FileName).ToLower() == rtf ?
                                          MainTextBox.Rtf : MainTextBox.Text;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = FileNameExtFilter,
                RestoreDirectory = true,
                FileName = "Новый файл",
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileHandler = new Utils.File(
                        saveFileDialog.FileName,
                        Path.GetExtension(saveFileDialog.FileName).ToLower() == rtf ? MainTextBox.Rtf : MainTextBox.Text);
                    this.Text = $"{Path.GetFileName(FileHandler.FileName)} - Notepad--";
                }
            }
        }
        #endregion

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm findText = new FindForm { Owner = this };
            findText.Show();
        }

        private void ОтменитьToolStripMenuItem_Click(object sender, EventArgs e) => MainTextBox.Undo();

        private void ВырезатьToolStripMenuItem_Click(object sender, EventArgs e) => MainTextBox.Cut();

        private void КопироватьToolStripMenuItem_Click(object sender, EventArgs e) => MainTextBox.Copy();

        private void ВставитьToolStripMenuItem_Click(object sender, EventArgs e) => MainTextBox.Paste();

        private void УдалитьToolStripMenuItem_Click(object sender, EventArgs e) => SendKeys.Send("{DELETE}");

        private void ВыделитьВсеToolStripMenuItem_Click(object sender, EventArgs e) => MainTextBox.SelectAll();

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void ШрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    MainTextBox.SelectionFont = fontDialog.Font;
                }
            }
        }

        private void вернутьПоУмолчаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTextBox.Font = RTFDefaultFont;
            MainTextBox.ZoomFactor = 1f;
        }
    }
}