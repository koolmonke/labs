using System;
using System.Linq;
using System.Windows.Forms;

namespace TEditor.Utils
{
    internal class TextUtils
    {
        // Метод поиска текста в RichRichTextBox
        // Для использования создаем в форме поиска глобальную переменную 
        // типа int = 0 для стартовой позиции поиска,
        // передаем в метод ссылки на RichRichTextBox'ы с исходным и искомым текстами,
        // а также необходимо указать, учитывать ли регистр букв при поиске (True - учитывать, False - не учитывать)

        public static int FindRichTextBox(ref RichTextBox RichTextBox, string findText, ref int findCutLength, bool register)
        {
            // Поиск с учетом регистра
            if (register == true)
            {
                if (RichTextBox.Text.Contains(findText))
                {
                    // Заносим текст в переменную string, удаляем из него уже пройденный 
                    // текст (findCutLength) в переменной nextText
                    string text = RichTextBox.Text;
                    string nextText = text.Remove(0, findCutLength);
                    // Ищем в nextText
                    int resultPosition = nextText.IndexOf(findText);
                    // Если искомое выражение найдено - выделяем его, добавляем его позицию и длину 
                    // к значению пройденного текста (findCutLenght)
                    if (resultPosition != -1)
                    {
                        RichTextBox.Select(resultPosition + findCutLength, findText.Length);
                        RichTextBox.ScrollToCaret();
                        RichTextBox.Focus();
                        findCutLength += findText.Length + resultPosition;
                    }
                    // Если попытка поиска не первая, и больше совпадений в тексте нет - обнуляем
                    // значение пройденного текста и начинаем поиск сначала
                    else if (resultPosition == -1 && findCutLength != 0)
                    {
                        findCutLength = 0;
                        return FindRichTextBox(ref RichTextBox, findText, ref findCutLength, register);
                    }
                }
                else
                {
                    findCutLength = 0;
                    MessageBox.Show("По вашему запросу ничего не нашлось.", "Совпадений не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Поиск без учета регистра
            else if (register == false)
            {
                if (RichTextBox.Text.ToLower().Contains(findText.ToLower()))
                {
                    string text = RichTextBox.Text.ToLower();
                    string nextText = text.Remove(0, findCutLength);
                    int resultPosition = nextText.IndexOf(findText.ToLower());

                    if (resultPosition != -1)
                    {
                        RichTextBox.Select(resultPosition + findCutLength, findText.Length);
                        RichTextBox.ScrollToCaret();
                        RichTextBox.Focus();
                        findCutLength += findText.Length + resultPosition;
                    }
                    else if (resultPosition == -1 && findCutLength != 0)
                    {
                        findCutLength = 0;
                        return FindRichTextBox(ref RichTextBox, findText, ref findCutLength, register);
                    }
                }
                // Если текст изначально не содержит результатов поиска - обнуляем findCutLength, выводим сообщение
                else
                {
                    findCutLength = 0;
                    MessageBox.Show("По вашему запросу ничего не нашлось.", "Совпадений не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return 0;
        }

        // Метод "Заменить"
        public static int ReplaceRichTextBox(ref RichTextBox RichTextBox, string findText, string replaceText, ref int findCutLength, bool register)
        {
            if (register == true)
            {
                if (RichTextBox.Text.Contains(findText))
                {
                    if (RichTextBox.SelectedText == "" || RichTextBox.SelectedText != findText)
                    {
                        string text = RichTextBox.Text;
                        string nextText = text.Remove(0, findCutLength);
                        int resultPosition = nextText.IndexOf(findText);
                        if (resultPosition != -1)
                        {
                            RichTextBox.Select(resultPosition + findCutLength, findText.Length);
                            RichTextBox.ScrollToCaret();
                            RichTextBox.Focus();
                            findCutLength += findText.Length + resultPosition;
                        }
                        else if (resultPosition == -1 && findCutLength != 0)
                        {
                            findCutLength = 0;
                            return ReplaceRichTextBox(ref RichTextBox, findText, replaceText, ref findCutLength, register);
                        }
                    }
                    else if (RichTextBox.SelectedText == findText)
                    {
                        RichTextBox.SelectedText = replaceText;
                    }
                }
                else
                {
                    findCutLength = 0;
                    MessageBox.Show("По вашему запросу ничего не нашлось.", "Совпадений не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (register == false)
            {
                if (RichTextBox.Text.ToLower().Contains(findText.ToLower()))
                {
                    if (RichTextBox.SelectedText == "" || RichTextBox.SelectedText.ToLower() != findText.ToLower())
                    {
                        string text = RichTextBox.Text.ToLower();
                        string nextText = text.Remove(0, findCutLength);
                        int resultPosition = nextText.IndexOf(findText.ToLower());
                        if (resultPosition != -1)
                        {
                            RichTextBox.Select(resultPosition + findCutLength, findText.Length);
                            RichTextBox.ScrollToCaret();
                            RichTextBox.Focus();
                            findCutLength += findText.Length + resultPosition;
                        }
                        else if (resultPosition == -1 && findCutLength != 0)
                        {
                            findCutLength = 0;
                            return ReplaceRichTextBox(ref RichTextBox, findText, replaceText, ref findCutLength, register);
                        }
                    }
                    else if (RichTextBox.SelectedText.ToLower() == findText.ToLower())
                    {
                        RichTextBox.SelectedText = replaceText;
                    }
                }
                else
                {
                    findCutLength = 0;
                    MessageBox.Show("По вашему запросу ничего не нашлось.", "Совпадений не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return 0;
        }

        // Метод "Заменить всё"
        public static int ReplaceAllRichTextBox(ref RichTextBox RichTextBox, string findText, string replaceText, bool register)
        {
            if (register == true)
            {
                string text = RichTextBox.Text;
                string words = findText;
                if (RichTextBox.Text.Contains(words))
                {
                    int startPosition = text.IndexOf(words);
                    RichTextBox.Select(startPosition, words.Length);
                    RichTextBox.SelectedText = replaceText;
                    return ReplaceAllRichTextBox(ref RichTextBox, findText, replaceText, register);
                }
                else
                {
                    MessageBox.Show("Замены произведены успешно.", "Заменить всё", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (register == false)
            {
                string text = RichTextBox.Text.ToLower();
                string words = findText.ToLower();
                if (text.Contains(words))
                {
                    int startPosition = text.IndexOf(words);
                    RichTextBox.Select(startPosition, findText.Length);
                    RichTextBox.SelectedText = replaceText;
                    return ReplaceAllRichTextBox(ref RichTextBox, findText, replaceText, register);
                }
                else
                {
                    MessageBox.Show("Замены произведены успешно.", "Заменить всё", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return 0;
        }

        public static void mEditEnableds(ref RichTextBox notebox, ref ToolStripMenuItem mEditCopy, ref ToolStripMenuItem mEditCut, ref ToolStripMenuItem mEditDel, ref ToolStripMenuItem mEditFind, ref ToolStripMenuItem mEditGo)
        {
            if (notebox.Text.Length < 1)
            {
                mEditCopy.Enabled = false;
                mEditCut.Enabled = false;
                mEditDel.Enabled = false;
                mEditFind.Enabled = false;
                mEditGo.Enabled = false;
            }
            else
            {
                mEditCopy.Enabled = true;
                mEditCut.Enabled = true;
                mEditDel.Enabled = true;
                mEditFind.Enabled = true;
                mEditGo.Enabled = true;
            }
        }

        public static void StatusAnalize(ref RichTextBox notebox, ref ToolStripStatusLabel statusLinesCount, ref ToolStripStatusLabel statusWordsCount, ref ToolStripStatusLabel statusCharSpaceCount, ref ToolStripStatusLabel statusCharCount)
        {
            string text = notebox.Text;
            // Количество строк в тексте
            statusLinesCount.Text = notebox.Lines.Count().ToString();
            // Количество слов в тексте
            statusWordsCount.Text = text.Split(new char[] { ' ', '\t', '\n', '\r', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-',
                '_', '+', '=', '[', '{', ']', '}', '/', '\\', '|', '"', ':', ';', '.', ',', '>', '<' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
            // Количество символов без пробелов
            statusCharCount.Text = text.Replace(" ", "").Replace("\t", "").Replace("\n", "").Replace("\r", "").ToCharArray().Length.ToString();
            // Количество символов с пробелами
            statusCharSpaceCount.Text = text.ToCharArray().Length.ToString();
        }
    }
}