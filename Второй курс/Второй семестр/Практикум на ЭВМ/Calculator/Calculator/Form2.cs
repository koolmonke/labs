using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{

    public partial class Form2 : Form1
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Invert_Click(object sender, EventArgs e)
        {
            MainTextBox = (1 / double.Parse(MainTextBox)).ToString();
        }

        private void Abs_Click(object sender, EventArgs e)
        {
            MainTextBox = MainTextBox.TrimStart('-');
        }

        private void Fact_Click(object sender, EventArgs e)
        {
            MainTextBox = MathExt.Factorial(MainTextBox).ToString();
        }

        private double GetRads(double x) => IsRad.Checked ? x : MathExt.ToRadians(x);
        
        private void Sin_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.Round(Math.Sin(GetRads(double.Parse(MainTextBox))), 4).ToString();
        }

        private void Cos_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.Round(Math.Cos(GetRads(double.Parse(MainTextBox))), 4).ToString();
        }

        private void Tg_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.Round(MathExt.Tan(MainTextBox, IsRad.Checked), 4).ToString();
        }

        private void Sqrt_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.Sqrt(double.Parse(MainTextBox)).ToString();
        }

        private void Sqr_Click(object sender, EventArgs e)
        {
            double val = double.Parse(MainTextBox);
            MainTextBox = (val * val).ToString();
        }

        private void Pow_Click(object sender, EventArgs e)
        {
            a = double.Parse(MainTextBox);
            MainTextBox = "0";
            state = PrevClick.Pow;
            LabelTextBox = $"{a}^";
        }

        private void Arcsin_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.Asin(double.Parse(MainTextBox)).ToString();
        }

        private void Arccos_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.Acos(double.Parse(MainTextBox)).ToString();
        }

        private void Arctg_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.Atan(double.Parse(MainTextBox)).ToString();
        }
        private void E_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.E.ToString();
        }

        private void pi_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.PI.ToString();
        }

        private void logE_Click(object sender, EventArgs e)
        {
            MainTextBox = Math.Log(double.Parse(MainTextBox)).ToString();
        }

        private void IsRad_CheckedChanged(object sender, EventArgs e)
        {
            IsDeg.Checked = !IsRad.Checked;
        }

        private void IsDeg_CheckedChanged(object sender, EventArgs e)
        {
            IsRad.Checked = !IsDeg.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = double.Parse(MainTextBox);
            if (t >= 0)
                MainTextBox = Math.Pow(t, (1 / 3d)).ToString();
            else
                MainTextBox = $"-{Math.Pow(-t, (1 / 3d))}";
        }
    }
}
