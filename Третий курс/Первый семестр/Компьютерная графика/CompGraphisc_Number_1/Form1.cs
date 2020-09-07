using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CompGraphisc_Number_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const int offset = 800;
        float sizeH, sizeW;
        float newH = 1, newW = 1;
        private static readonly SolidBrush brush = new SolidBrush(Color.DimGray);

        PointF p1_A = new PointF(100, 50);
        PointF p2_A = new PointF(200, 50);
        PointF p3_A = new PointF(250, 350);
        PointF p4_A = new PointF(200, 350);
        PointF p5_A = new PointF(175, 250);
        PointF p6_A = new PointF(120, 250);
        PointF p7_A = new PointF(100, 350);
        PointF p8_A = new PointF(50, 350);
        PointF pd9_A = new PointF(125,200);
        PointF pd10_A = new PointF(150, 85);
        PointF pd11_A = new PointF(175, 200);

        PointF p1_P = new PointF(300, 50);
        PointF p2_P = new PointF(450, 50);
        PointF p3_P = new PointF(500, 100);
        PointF p4_P = new PointF(500, 150);
        PointF p5_P = new PointF(450, 200);
        PointF p6_P = new PointF(350, 200);
        PointF p7_P = new PointF(350, 350);
        PointF p8_P = new PointF(300, 350);
        PointF pd9_P = new PointF(350, 100);
        PointF pd10_P = new PointF(425, 100);
        PointF pd11_P = new PointF(450.5f, 112.5f);
        PointF pd12_P = new PointF(450.5f, 137.5f);
        PointF pd13_P = new PointF(425, 150);
        PointF pd14_P = new PointF(350, 150);

        PointF p1_T = new PointF(550, 50);
        PointF p2_T = new PointF(800, 50);
        PointF p3_T = new PointF(800, 100);
        PointF p4_T = new PointF(700, 100);
        PointF p5_T = new PointF(700, 350);
        PointF p6_T = new PointF(650, 350);
        PointF p7_T = new PointF(650, 100);
        PointF p8_T = new PointF(550, 100);

        PointF p1_Y = new PointF(850, 50);
        PointF p2_Y = new PointF(900, 50);
        PointF p3_Y = new PointF(950, 200);
        PointF p4_Y = new PointF(1000, 50);
        PointF p5_Y = new PointF(1050, 50);
        PointF p6_Y = new PointF(937.5f, 350);
        PointF p7_Y = new PointF(887.5f, 350);
        PointF p8_Y = new PointF(925, 250);

        PointF p1_P2 = new PointF(300 + offset, 50);
        PointF p2_P2 = new PointF(450 + offset, 50);
        PointF p3_P2 = new PointF(500 + offset, 100);
        PointF p4_P2 = new PointF(500 + offset, 150);
        PointF p5_P2 = new PointF(450 + offset, 200);
        PointF p6_P2 = new PointF(350 + offset, 200);
        PointF p7_P2 = new PointF(350 + offset, 350);
        PointF p8_P2 = new PointF(300 + offset, 350);
        PointF pd9_P2 = new PointF(350 + offset, 100);
        PointF pd10_P2 = new PointF(425 + offset, 100);
        PointF pd11_P2 = new PointF(450.5f + offset, 112.5f);
        PointF pd12_P2 = new PointF(450.5f + offset, 137.5f);
        PointF pd13_P2 = new PointF(425 + offset, 150);
        PointF pd14_P2 = new PointF(350 + offset, 150);

        private void Form1_Load(object sender, EventArgs e)
        {
            sizeH = ClientSize.Height;
            sizeW = ClientSize.Width;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            newH = ClientSize.Height / sizeH;
            newW = ClientSize.Width / sizeW;

            Invalidate();
        }

        public PointF SetPoint(PointF point, float H, float W)
        {
            PointF temP = new PointF(point.X * W, point.Y * H);
            return temP;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            GraphicsPath Defpath = new GraphicsPath();
            GraphicsPath Defpath2 = new GraphicsPath();
            Region gp, gp2;
            
            //A
            PointF np1_A = SetPoint(p1_A, newH, newW);
            PointF np2_A = SetPoint(p2_A, newH, newW);
            PointF np3_A = SetPoint(p3_A, newH, newW);
            PointF np4_A = SetPoint(p4_A, newH, newW);
            PointF np5_A = SetPoint(p5_A, newH, newW);
            PointF np6_A = SetPoint(p6_A, newH, newW);
            PointF np7_A = SetPoint(p7_A, newH, newW);
            PointF np8_A = SetPoint(p8_A, newH, newW);
            PointF npd9_A = SetPoint(pd9_A, newH, newW);
            PointF npd10_A = SetPoint(pd10_A, newH, newW);
            PointF npd11_A = SetPoint(pd11_A, newH, newW);

            //P
            PointF np1_P = SetPoint(p1_P, newH, newW);
            PointF np2_P = SetPoint(p2_P, newH, newW);
            PointF np3_P = SetPoint(p3_P, newH, newW);
            PointF np4_P = SetPoint(p4_P, newH, newW);
            PointF np5_P = SetPoint(p5_P, newH, newW);
            PointF np6_P = SetPoint(p6_P, newH, newW);
            PointF np7_P = SetPoint(p7_P, newH, newW);
            PointF np8_P = SetPoint(p8_P, newH, newW);
            PointF npd9_P = SetPoint(pd9_P, newH, newW);
            PointF npd10_P = SetPoint(pd10_P, newH, newW);
            PointF npd11_P = SetPoint(pd11_P, newH, newW);
            PointF npd12_P = SetPoint(pd12_P, newH, newW);
            PointF npd13_P = SetPoint(pd13_P, newH, newW);
            PointF npd14_P = SetPoint(pd14_P, newH, newW);

            //T
            PointF np1_T = SetPoint(p1_T, newH, newW);
            PointF np2_T = SetPoint(p2_T, newH, newW);
            PointF np3_T = SetPoint(p3_T, newH, newW);
            PointF np4_T = SetPoint(p4_T, newH, newW);
            PointF np5_T = SetPoint(p5_T, newH, newW);
            PointF np6_T = SetPoint(p6_T, newH, newW);
            PointF np7_T = SetPoint(p7_T, newH, newW);
            PointF np8_T = SetPoint(p8_T, newH, newW);

            //У
            PointF np1_Y = SetPoint(p1_Y, newH, newW);
            PointF np2_Y = SetPoint(p2_Y, newH, newW);
            PointF np3_Y = SetPoint(p3_Y, newH, newW);
            PointF np4_Y = SetPoint(p4_Y, newH, newW);
            PointF np5_Y = SetPoint(p5_Y, newH, newW);
            PointF np6_Y = SetPoint(p6_Y, newH, newW);
            PointF np7_Y = SetPoint(p7_Y, newH, newW);
            PointF np8_Y = SetPoint(p8_Y, newH, newW);

            //P2
            PointF np1_P2 = SetPoint(p1_P2, newH, newW);
            PointF np2_P2 = SetPoint(p2_P2, newH, newW);
            PointF np3_P2 = SetPoint(p3_P2, newH, newW);
            PointF np4_P2 = SetPoint(p4_P2, newH, newW);
            PointF np5_P2 = SetPoint(p5_P2, newH, newW);
            PointF np6_P2 = SetPoint(p6_P2, newH, newW);
            PointF np7_P2 = SetPoint(p7_P2, newH, newW);
            PointF np8_P2 = SetPoint(p8_P2, newH, newW);
            PointF npd9_P2 = SetPoint(pd9_P2, newH, newW);
            PointF npd10_P2 = SetPoint(pd10_P2, newH, newW);
            PointF npd11_P2 = SetPoint(pd11_P2, newH, newW);
            PointF npd12_P2 = SetPoint(pd12_P2, newH, newW);
            PointF npd13_P2 = SetPoint(pd13_P2, newH, newW);
            PointF npd14_P2 = SetPoint(pd14_P2, newH, newW);

            //A
            path.AddLine(np1_A, np2_A);
            path.AddLine(np2_A, np3_A);
            path.AddLine(np3_A, np4_A);
            path.AddLine(np4_A, np5_A);
            path.AddLine(np5_A, np6_A);
            path.AddLine(np6_A, np7_A);
            path.AddLine(np7_A, np8_A);
            path.AddLine(np8_A, np1_A);
            Defpath.AddLine(npd9_A, npd10_A);
            Defpath.AddLine(npd10_A, npd11_A);
            Defpath.AddLine(npd11_A, npd9_A);

            //P
            path.AddLine(np1_P, np2_P);
            path.AddBezier(np2_P, np3_P, np4_P, np5_P);
            path.AddLine(np5_P, np6_P);
            path.AddLine(np6_P, np7_P);
            path.AddLine(np7_P, np8_P);
            path.AddLine(np8_P, np1_P);
            Defpath.AddLine(npd9_P, npd10_P);
            Defpath.AddBezier(npd10_P, npd11_P, npd12_P, npd13_P);
            Defpath.AddLine(npd13_P, npd14_P);
            Defpath.AddLine(npd14_P, npd9_P);

            //T
            path.AddLine(np1_T, np2_T);
            path.AddLine(np2_T, np3_T);
            path.AddLine(np3_T, np4_T);
            path.AddLine(np4_T, np5_T);
            path.AddLine(np5_T, np6_T);
            path.AddLine(np6_T, np7_T);
            path.AddLine(np7_T, np8_T);
            path.AddLine(np8_T, np1_T);

            //Y
            path.AddLine(np1_Y, np2_Y);
            path.AddLine(np2_Y, np3_Y);
            path.AddLine(np3_Y, np4_Y);
            path.AddLine(np4_Y, np5_Y);
            path.AddLine(np5_Y, np6_Y);
            path.AddLine(np6_Y, np7_Y);
            path.AddLine(np7_Y, np8_Y);
            path.AddLine(np8_Y, np1_Y);

            //P2
            path.AddLine(np1_P2, np2_P2);
            path.AddBezier(np2_P2, np3_P2, np4_P2, np5_P2);
            path.AddLine(np5_P2, np6_P2);
            path.AddLine(np6_P2, np7_P2);
            path.AddLine(np7_P2, np8_P2);
            path.AddLine(np8_P2, np1_P2);
            Defpath2.AddLine(npd9_P2, npd10_P2);
            Defpath2.AddBezier(npd10_P2, npd11_P2, npd12_P2, npd13_P2);
            Defpath2.AddLine(npd13_P2, npd14_P2);
            Defpath2.AddLine(npd14_P2, npd9_P2);

            gp = new Region(Defpath);
            gp2 = new Region(Defpath2);
            e.Graphics.ExcludeClip(gp);
            e.Graphics.ExcludeClip(gp2);
            e.Graphics.FillPath(brush, path);
        } 
    }
}
