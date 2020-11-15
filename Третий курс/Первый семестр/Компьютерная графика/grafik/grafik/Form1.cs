using System;
using System.Drawing;
using System.Windows.Forms;

namespace grafik
{
    public partial class Form1 : Form
    {
        private const int штрихи = 5;
        private const int КолВо = 1000;
        private const double a = 1;
        private const double НачФи = 0;
        private const double КонФи = 2 * Math.PI;
        private double dX, dY, dA;
        private тип_анимации выборка;
        private bool НаличиеГрафика;
        private int ОтступГ, ОтступВ;
        private double[,] Точки, ПреобразТочки;
        private Bitmap Холст;

        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void построитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Точки = new double [КолВо, 2]; //x,y-1000штук
            ПреобразТочки = new double[КолВо, 2];
            var ШагФи = (КонФи - НачФи) / (КолВо - 1);
            for (var i = 0; i < КолВо; i++)
            {
                var phi = НачФи + i * ШагФи;
                (Точки[i, 0], Точки[i, 1]) = PlotF.pol2cart(PlotF.r(phi), phi);
                ПреобразТочки[i, 0] = Точки[i, 0];
                ПреобразТочки[i, 1] = Точки[i, 1];
            }

            НаличиеГрафика = true;
            ОтображениеГрафика(ref ПреобразТочки, Холст);

            демонстрацияСдвигаToolStripMenuItem.Enabled = true;
            демонстрацияПоворотаToolStripMenuItem.Enabled = true;
            демонстрацияСжатияToolStripMenuItem.Enabled = true;
            демонстрацияСдвигаИПоворотаToolStripMenuItem.Enabled = true;
            демонстрацияПоворотаИСдвигаToolStripMenuItem.Enabled = true;
        }

        private void ОтображениеГрафика(ref double[,] T, Bitmap B)
        {
            double XMin, XMax, YMin, YMax;
            XMin = XMax = Точки[0, 0];
            YMin = YMax = Точки[0, 1];
            for (var i = 1; i < КолВо; i++)
            {
                if (XMin > Точки[i, 0])
                    XMin = Точки[i, 0];
                if (XMax < Точки[i, 0])
                    XMax = Точки[i, 0];
                if (YMin > Точки[i, 1])
                    YMin = Точки[i, 1];
                if (YMax < Точки[i, 1])
                    YMax = Точки[i, 1];
            }

            ОтступГ = ClientSize.Width / 3;
            ОтступВ = ClientSize.Height / 5;
            var c = (ClientSize.Width - ОтступГ - ОтступГ) / (XMax - XMin);
            var d = ОтступГ - c * XMin;
            var g = (ClientSize.Height - menuStrip1.Height - ОтступВ - ОтступВ) / (YMin - YMax);
            var h = ОтступВ - g * YMax;
            var grp = Graphics.FromImage(B);
            grp.Clear(Color.GreenYellow);
            grp.DrawLine(Pens.Black, 0 /*(float)(ОтступГ)*/, (float) h, ClientSize.Width /* - ОтступГ*/, (float) h);
            grp.DrawLine(Pens.Black, (float) d, 0 /*(float)(ОтступВ)*/, (float) d,
                ClientSize.Height - menuStrip1.Height);
            var fs = FontStyle.Italic;
            var f = new Font("Monotype Corsiva", 12, fs);
            for (var i = 1;; i++)
            {
                //штрихи по х
                grp.DrawLine(Pens.Black, (float) (c * i * XMax / штрихи + d), (float) (h - 2),
                    (float) (c * i * XMax / штрихи + d), (float) (h + 2));
                //координаты
                grp.DrawString(((float) (i * XMax / штрихи)).ToString("F2"), f, Brushes.BlueViolet,
                    (float) (c * i * XMax / штрихи + d - 13), (float) (h + 10));
                if (i * XMax / штрихи >= XMax)
                    break;
            }

            for (var i = 1;; i++)
            {
                //штрихи по у
                grp.DrawLine(Pens.Black, (float) (d - 2), (float) (g * i * YMax / штрихи + h), (float) (d + 2),
                    (float) (g * i * YMax / штрихи + h));
                //координаты
                grp.DrawString(((float) (i * YMax / штрихи)).ToString("F2"), f, Brushes.BlueViolet, (float) (d - 40),
                    (float) (g * i * YMax / штрихи + h) - 9);
                if (i * YMax / штрихи > YMax)
                    break;
            }

            for (var i = 1;; i++)
            {
                //штрихи по -у
                grp.DrawLine(Pens.Black, (float) (d - 2), (float) (g * i * YMin / штрихи + h), (float) (d + 2),
                    (float) (g * i * YMin / штрихи + h));
                //координаты
                grp.DrawString(((float) (i * YMin / штрихи)).ToString("F2"), f, Brushes.BlueViolet, (float) (d - 40),
                    (float) (g * i * YMin / штрихи + h) - 9);
                if (i * YMin / штрихи < YMin)
                    break;
            }

            //0
            grp.DrawString(((float) 0.0).ToString("F0"), f, Brushes.BlueViolet, (float) (d - 14), (float) (h - 3));

            var p = new Pen(Color.FromArgb(150, Color.DeepPink), 2);
            for (var i = 1; i < КолВо; i++)
                grp.DrawLine(p, (float) (c * T[i - 1, 0] + d), (float) (g * T[i - 1, 1] + h), (float) (c * T[i, 0] + d),
                    (float) (g * T[i, 1] + h));
            grp.Dispose();
            p.Dispose();
            CreateGraphics().DrawImageUnscaled(Холст, 0, menuStrip1.Height); //рис картинку на окне чтобы не мерцало
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Холст = new Bitmap(ClientSize.Width, ClientSize.Height - menuStrip1.Height);
            if (НаличиеГрафика)
                ОтображениеГрафика(ref ПреобразТочки, Холст);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Холст = new Bitmap(ClientSize.Width, ClientSize.Height - menuStrip1.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (НаличиеГрафика)
                e.Graphics.DrawImageUnscaled(Холст, 0, menuStrip1.Height);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                построитьToolStripMenuItem_Click(null, null);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void демонстрацияСдвигаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            выборка = тип_анимации.сдвиг;
            dX = 0.0;
            dY = 0.0;
            timer.Enabled = true;
        }

        private void демонстрацияПоворотаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            выборка = тип_анимации.поворот;
            dX = 2.0 * Math.PI;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var МатрТрансф1 = new double[3, 3];
            var МатрТрансф2 = new double[3, 3];
            var МатрТрансф3 = new double[3, 3];
            var ВремВек = new double[3];
            var ВремВекРезультат = new double[3];
            switch (выборка)
            {
                case тип_анимации.сдвиг:
                    if (dX < 1.0)
                    {
                        dX += 0.099;
                        dY += 0.3;
                        МатрТрансф1[0, 0] = 1.0;
                        МатрТрансф1[0, 1] = 0.0;
                        МатрТрансф1[0, 2] = dX;
                        МатрТрансф1[1, 0] = 0.0;
                        МатрТрансф1[1, 1] = 1.0;
                        МатрТрансф1[1, 2] = dY;
                        МатрТрансф1[2, 0] = 0.0;
                        МатрТрансф1[2, 1] = 0.0;
                        МатрТрансф1[2, 2] = 1.0;
                        for (var i = 0; i < КолВо; i++)
                        {
                            ВремВек[0] = Точки[i, 0];
                            ВремВек[1] = Точки[i, 1];
                            ВремВек[2] = 1.0; //*(x,y,1)
                            матрица_на_вектор(МатрТрансф1, ВремВек, ref ВремВекРезультат);
                            ПреобразТочки[i, 0] = ВремВекРезультат[0];
                            ПреобразТочки[i, 1] = ВремВекРезультат[1]; //забираем др матр кот рис на графике
                        }

                        ОтображениеГрафика(ref ПреобразТочки, Холст);
                    }
                    else
                    {
                        timer.Enabled = false;
                    }

                    break;

                case тип_анимации.поворот:
                    if (dX > 0.0)
                    {
                        dX -= 0.20943951023931954923084289221863;
                        МатрТрансф1[0, 0] = Math.Cos(dX);
                        МатрТрансф1[0, 1] = -Math.Sin(dX);
                        МатрТрансф1[0, 2] = 0.0;
                        МатрТрансф1[1, 0] = Math.Sin(dX);
                        МатрТрансф1[1, 1] = Math.Cos(dX);
                        МатрТрансф1[1, 2] = 0.0;
                        МатрТрансф1[2, 0] = 0.0;
                        МатрТрансф1[2, 1] = 0.0;
                        МатрТрансф1[2, 2] = 1.0;
                        for (var i = 0; i < КолВо; i++)
                        {
                            ВремВек[0] = Точки[i, 0];
                            ВремВек[1] = Точки[i, 1];
                            ВремВек[2] = 1.0; //*(x,y,1)
                            матрица_на_вектор(МатрТрансф1, ВремВек, ref ВремВекРезультат);
                            ПреобразТочки[i, 0] = ВремВекРезультат[0];
                            ПреобразТочки[i, 1] = ВремВекРезультат[1]; //забираем др матр кот рис на графике
                        }

                        ОтображениеГрафика(ref ПреобразТочки, Холст);
                    }
                    else
                    {
                        timer.Enabled = false;
                    }

                    break;

                case тип_анимации.сжатие:
                    if (dY > 0.5)
                    {
                        dX -= 0.1;
                        dY -= 0.05;
                        МатрТрансф1[0, 0] = dX;
                        МатрТрансф1[0, 1] = 0.0;
                        МатрТрансф1[0, 2] = 0.0;
                        МатрТрансф1[1, 0] = 0.0;
                        МатрТрансф1[1, 1] = dY;
                        МатрТрансф1[1, 2] = 0.0;
                        МатрТрансф1[2, 0] = 0.0;
                        МатрТрансф1[2, 1] = 0.0;
                        МатрТрансф1[2, 2] = 1.0;
                        for (var i = 0; i < КолВо; i++)
                        {
                            ВремВек[0] = Точки[i, 0];
                            ВремВек[1] = Точки[i, 1];
                            ВремВек[2] = 1.0; //*(x,y,1)
                            матрица_на_вектор(МатрТрансф1, ВремВек, ref ВремВекРезультат);
                            ПреобразТочки[i, 0] = ВремВекРезультат[0];
                            ПреобразТочки[i, 1] = ВремВекРезультат[1]; //забираем др матр кот рис на графике
                        }

                        ОтображениеГрафика(ref ПреобразТочки, Холст);
                    }
                    else
                    {
                        timer.Enabled = false;
                    }

                    break;

                case тип_анимации.сип:
                    if (dA > 0.0)
                    {
                        dA -= 0.20943951023931954923084289221863;
                        dX += 0.04;
                        dY += 0.07;
                        МатрТрансф1[0, 0] = 1.0;
                        МатрТрансф1[0, 1] = 0.0;
                        МатрТрансф1[0, 2] = dX;
                        МатрТрансф1[1, 0] = 0.0;
                        МатрТрансф1[1, 1] = 1.0;
                        МатрТрансф1[1, 2] = dY;
                        МатрТрансф1[2, 0] = 0.0;
                        МатрТрансф1[2, 1] = 0.0;
                        МатрТрансф1[2, 2] = 1.0;
                        МатрТрансф2[0, 0] = Math.Cos(dA);
                        МатрТрансф2[0, 1] = -Math.Sin(dA);
                        МатрТрансф2[0, 2] = 0.0;
                        МатрТрансф2[1, 0] = Math.Sin(dA);
                        МатрТрансф2[1, 1] = Math.Cos(dA);
                        МатрТрансф2[1, 2] = 0.0;
                        МатрТрансф2[2, 0] = 0.0;
                        МатрТрансф2[2, 1] = 0.0;
                        МатрТрансф2[2, 2] = 1.0;
                        матрица_на_матрицу(МатрТрансф1, МатрТрансф2, ref МатрТрансф3);
                        for (var i = 0; i < КолВо; i++)
                        {
                            ВремВек[0] = Точки[i, 0];
                            ВремВек[1] = Точки[i, 1];
                            ВремВек[2] = 1.0; //*(x,y,1)
                            матрица_на_вектор(МатрТрансф3, ВремВек, ref ВремВекРезультат);
                            ПреобразТочки[i, 0] = ВремВекРезультат[0];
                            ПреобразТочки[i, 1] = ВремВекРезультат[1]; //забираем др матр кот рис на графике
                        }

                        ОтображениеГрафика(ref ПреобразТочки, Холст);
                    }
                    else
                    {
                        timer.Enabled = false;
                    }

                    break;

                case тип_анимации.пис:
                    if (dA > 0.2)
                    {
                        dA -= 0.02;
                        dX -= 0.035;
                        dY += 0.1;
                        МатрТрансф1[0, 0] = 1.0;
                        МатрТрансф1[0, 1] = 0.0;
                        МатрТрансф1[0, 2] = dX;
                        МатрТрансф1[1, 0] = 0.0;
                        МатрТрансф1[1, 1] = 1.0;
                        МатрТрансф1[1, 2] = dY;
                        МатрТрансф1[2, 0] = 0.0;
                        МатрТрансф1[2, 1] = 0.0;
                        МатрТрансф1[2, 2] = 1.0;

                        МатрТрансф2[0, 0] = dA;
                        МатрТрансф2[0, 1] = 0.0;
                        МатрТрансф2[0, 2] = 0.0;
                        МатрТрансф2[1, 0] = 0.0;
                        МатрТрансф2[1, 1] = dA;
                        МатрТрансф2[1, 2] = 0.0;
                        МатрТрансф2[2, 0] = 0.0;
                        МатрТрансф2[2, 1] = 0.0;
                        МатрТрансф2[2, 2] = 1.0;
                        матрица_на_матрицу(МатрТрансф1, МатрТрансф2, ref МатрТрансф3);
                        for (var i = 0; i < КолВо; i++)
                        {
                            ВремВек[0] = Точки[i, 0];
                            ВремВек[1] = Точки[i, 1];
                            ВремВек[2] = 1.0; //*(x,y,1)
                            матрица_на_вектор(МатрТрансф3, ВремВек, ref ВремВекРезультат);
                            ПреобразТочки[i, 0] = ВремВекРезультат[0];
                            ПреобразТочки[i, 1] = ВремВекРезультат[1]; //забираем др матр кот рис на графике
                        }

                        ОтображениеГрафика(ref ПреобразТочки, Холст);
                    }
                    else
                    {
                        timer.Enabled = false;
                    }

                    break;
            }
        }

        //умножение матр на век
        private void матрица_на_вектор(double[,] Матрица, double[] Вектор, ref double[] Результат)
        {
            for (var i = 0; i < 3; i++)
            {
                Результат[i] = 0;
                for (var j = 0; j < 3; j++) Результат[i] += Матрица[i, j] * Вектор[j];
            }
        }

        //умножение матр на матр
        private void матрица_на_матрицу(double[,] Матрица, double[,] Матрица1, ref double[,] МатрицаРезультат)
        {
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
            {
                МатрицаРезультат[i, j] = 0.0;
                for (var k = 0; k < 3; k++) МатрицаРезультат[i, j] += Матрица[i, k] * Матрица1[k, j];
            }
        }

        private void демонстрацияСжатияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            выборка = тип_анимации.сжатие;
            dX = 2.2;
            dY = 1.5;
            timer.Enabled = true;
        }

        private void демонстрацияСдвигаИПоворотаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            выборка = тип_анимации.сип;
            dX = 0.0;
            dY = 0.0;
            dA = 2.0 * Math.PI;
            timer.Enabled = true;
        }

        private void демонстрацияПоворотаИСдвигаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            выборка = тип_анимации.пис;
            dX = 0.0;
            dY = 0.0;
            dA = 1.0;
            timer.Enabled = true;
        }

        private enum тип_анимации : byte
        {
            сдвиг,
            поворот,
            сжатие,
            сип,
            пис
        }
    }
}