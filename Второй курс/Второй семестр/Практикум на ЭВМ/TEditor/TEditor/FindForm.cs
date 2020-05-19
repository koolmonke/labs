using System;
using System.Windows.Forms;
using TEditor.Utils;

namespace TEditor
{
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
        }
        private void SearchForm_Shown(object sender, EventArgs e) // Событие при открытии формы поиска и замены
        {
            tbFind.Focus();
        }

        int findCutLength = 0; // На сколько символов обрезаем текст для поиска

        private void tbFind_TextChanged(object sender, EventArgs e) // Cобытие при изменении текста в tbFind
        {
            findCutLength = 0;
        }

        private void tbReplace_TextChanged(object sender, EventArgs e) // Событие при изменении текста в tbReplace
        {
            findCutLength = 0;
        }

        private void cbReg_CheckStateChanged(object sender, EventArgs e) // Событие при изменении статуса cbReg
        {
            findCutLength = 0;
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e) // Событие при закрытии формы (до закрытия)
        {
            findCutLength = 0;
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            var main = this.Owner as Form1;
            if (main != null)
            {
                if (cbReg.CheckState == CheckState.Checked)
                {
                    TextUtils.FindRichTextBox(ref main.MainTextBox, tbFind.Text, ref findCutLength, true);
                }
                else
                {
                    TextUtils.FindRichTextBox(ref main.MainTextBox, tbFind.Text, ref findCutLength, false);
                }
            }
        }

        private void btReplace_Click(object sender, EventArgs e)
        {
            var main = this.Owner as Form1;
            if (main != null)
            {
                if (cbReg.CheckState == CheckState.Checked)
                {
                    TextUtils.ReplaceRichTextBox(ref main.MainTextBox, tbFind.Text, tbReplace.Text, ref findCutLength, true);
                }
                else
                {
                    TextUtils.ReplaceRichTextBox(ref main.MainTextBox, tbFind.Text, tbReplace.Text, ref findCutLength, false);
                }
            }
        }

        private void btReplaceAll_Click(object sender, EventArgs e)
        {
            var main = this.Owner as Form1;
            if (main != null)
            {
                if (cbReg.CheckState == CheckState.Checked)
                {
                    TextUtils.ReplaceAllRichTextBox(ref main.MainTextBox, tbFind.Text, tbReplace.Text, true);
                }
                else
                {
                    TextUtils.ReplaceAllRichTextBox(ref main.MainTextBox, tbFind.Text, tbReplace.Text, false);
                }
            }

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

