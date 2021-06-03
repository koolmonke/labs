using System;
using System.Globalization;
using System.Windows.Forms;

namespace Calculator
{
    public enum PrevClick
    {
        Add,
        Sub,
        Mul,
        Div,
        Pow
    }

    public partial class Form1 : Form
    {


        public static bool CheckOnNansAndInfs(string textbox) => 
            textbox == NumberFormatInfo.CurrentInfo.NaNSymbol || textbox == "∞";

        public Form1()
        {
            InitializeComponent();
            DecimalSep.Text = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }

        protected string MainTextBox
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        protected string LabelTextBox
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        protected PrevClick state;
        protected double a, b;
        private double _mem;

        protected double Mem
        {
            get => _mem;
            set 
            {
                _mem = value;
                MemTextBox.Text = $"{_mem}";
            }
        }
       


        private void DecimalSeparator_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                textBox1.Text += CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
                textBox1.Text += "0";
        }

        private void One_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "1";
        }

        private void Two_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "2";
        }

        private void Three_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "3";
        }

        private void Four_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "4";
        }

        private void Five_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "5";
        }

        private void Six_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "6";
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "7";
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "8";
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Clear();
            textBox1.Text += "9";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D0:
                    Zero.PerformClick();
                    return true;
                case Keys.D1:
                    One.PerformClick();
                    return true;
                case Keys.D2:
                    Two.PerformClick();
                    return true;
                case Keys.D3:
                    Three.PerformClick();
                    return true;
                case Keys.D4:
                    Four.PerformClick();
                    return true;
                case Keys.D5:
                    Five.PerformClick();
                    return true;
                case Keys.D6:
                    Six.PerformClick();
                    return true;
                case Keys.D7:
                    Seven.PerformClick();
                    return true;
                case Keys.D8:
                    Eight.PerformClick();
                    return true;
                case Keys.D9:
                    Nine.PerformClick();
                    return true;
                default:
                {
                    if (keyData == Keys.Shift)
                    {
                        Add.PerformClick();
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
        }

        private void ChangeSign(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
            {
                if (textBox1.Text[0] != '-')
                {
                    textBox1.Text = $"-{textBox1.Text}";
                }
                else
                {
                    textBox1.Text = textBox1.Text.TrimStart('-');
                }
            }

        }

        private void Eval()
        {

            switch (state)
            {
                case PrevClick.Add:
                    b = a + double.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;

                case PrevClick.Sub:
                    b = a - double.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;

                case PrevClick.Mul:
                    b = a * double.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;

                case PrevClick.Div:
                    b = a / double.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;

                case PrevClick.Pow:
                    b = Math.Pow(a, double.Parse(textBox1.Text));
                    textBox1.Text = b.ToString();
                    break;
            }

        }

        private void Add_Click(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text);
            textBox1.Text = "0";
            state = PrevClick.Add;
            label1.Text = $"{a}+";
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text);
            textBox1.Text = "0";
            state = PrevClick.Sub;
            label1.Text = $"{a}-";
        }

        private void Mul_Click(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text);
            textBox1.Text = "0";
            state = PrevClick.Mul;
            label1.Text = $"{a}*";
        }

        private void Div_Click(object sender, EventArgs e)
        {
            a = double.Parse(textBox1.Text);
            textBox1.Text = "0";
            state = PrevClick.Div;
            label1.Text = $"{a}/";
        }

        private void Eval_Click(object sender, EventArgs e)
        {
            Eval();
            label1.Text = "";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                item.Enabled = true;
            }
            textBox1.Enabled = false;
            label1.Enabled = false;
            textBox1.Text = "0";
            a = 0;
            b = 0;
            label1.Text = "";
        }

        private void MemAdd_Click(object sender, EventArgs e)
        {
            Mem += double.Parse(textBox1.Text);
        }

        private void MemSub_Click(object sender, EventArgs e)
        {
            Mem -= double.Parse(textBox1.Text);
        }

        private void MemtextBox_MouseHoover(object sender, EventArgs e)
        {
            MemToolTip.SetToolTip(MemTextBox, "Память");
        }

        private void MemClear_Click(object sender, EventArgs e)
        {
            Mem = 0;
        }

        private void MemRes_Click(object sender, EventArgs e)
        {
            textBox1.Text = MemTextBox.Text;
        }

        private void ИнженерныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var nigro = new Form2();
            nigro.Show();
        }

        private void обычныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var normal = new Form1();
            normal.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (CheckOnNansAndInfs(textBox1.Text))
            {
                foreach (Control item in Controls)
                {
                    item.Enabled = false;
                }
                Clear.Enabled = true;
            }
        }



        private void Backspace_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            if (lenght == 0)
            {
                textBox1.Text = "0";
            }
            else
            {
                for (int i = 0; i < lenght; i++)
                    textBox1.Text += text[i];
            }
        }


    }
}
