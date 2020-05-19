using System;
using System.Windows.Forms;
using NumSharp;

namespace MatrixCalc
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            LeftMatrix.Init();
            RightMatrix.Init();
            ResultMatrix.Init();
        }

        private void LeftMatrix_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LeftMatrix.RowFill();
            RightMatrix.RowFill();
            ResultMatrix.RowFill();
        }

        private void LeftMatrix_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            LeftMatrix.RowFill();
            RightMatrix.RowFill();
            ResultMatrix.RowFill();
        }

        private void LeftMatrix_Resize(object sender, EventArgs e)
        {
            LeftMatrix.RowFill();
            RightMatrix.RowFill();
            ResultMatrix.RowFill();
        }

        private void Mul_Click(object sender, EventArgs e)
        {
            try
            {
                var Left = np.array(LeftMatrix.ToDoubleArray());
                var Right = np.array(RightMatrix.ToDoubleArray());
                ResultMatrix.ToDisplay(np.matmul(Left, Right).ToDoubleArray());

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                var Left = np.array(LeftMatrix.ToDoubleArray());
                var Right = np.array(RightMatrix.ToDoubleArray());
                ResultMatrix.ToDisplay((Left + Right).ToDoubleArray());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            try
            {
                var Left = np.array(LeftMatrix.ToDoubleArray());
                var Right = np.array(RightMatrix.ToDoubleArray());
                ResultMatrix.ToDisplay((Left - Right).ToDoubleArray());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void LeftMulByNumber_Click(object sender, EventArgs e)
        {
            try
            {
                var Left = np.array(LeftMatrix.ToDoubleArray());
                var Num = LeftMulValue.Value;
                ResultMatrix.ToDisplay((Num * Left).ToDoubleArray());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void LeftTranspose_Click(object sender, EventArgs e)
        {
            try
            {
                var Left = np.array(LeftMatrix.ToDoubleArray());
                ResultMatrix.ToDisplay(Left.transpose().ToDoubleArray());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void LeftInv_Click(object sender, EventArgs e)
        {
            try
            {
                var Left = np.array(LeftMatrix.ToDoubleArray());
                ResultMatrix.ToDisplay(Left.ToInverse());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void LeftCopy_Click(object sender, EventArgs e)
        {
            LeftMatrix.ToDisplay(ResultMatrix);
        }

        private void RightCopy_Click(object sender, EventArgs e)
        {
            RightMatrix.ToDisplay(ResultMatrix);
        }

        private void RightInverse_Click(object sender, EventArgs e)
        {
            try
            {
                var Right = np.array(RightMatrix.ToDoubleArray());
                ResultMatrix.ToDisplay(Right.ToInverse());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void RightMulByValue_Click(object sender, EventArgs e)
        {
            try
            {
                var Right = np.array(RightMatrix.ToDoubleArray());
                var Num = RightMulValue.Value;
                ResultMatrix.ToDisplay((Num * Right).ToDoubleArray());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void RightTranspose_Click(object sender, EventArgs e)
        {
            try
            {
                var Left = np.array(RightMatrix.ToDoubleArray());
                ResultMatrix.ToDisplay(Left.transpose().ToDoubleArray());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void LeftRows_ValueChanged(object sender, EventArgs e)
        {
            var col = LeftMatrix.ColumnCount;
            LeftMatrix.Clear();
            LeftMatrix.Init((int)LeftRows.Value, col);
        }

        private void LeftCols_ValueChanged(object sender, EventArgs e)
        {
            var row = LeftMatrix.RowCount;
            LeftMatrix.Clear();
            LeftMatrix.Init(row, (int)LeftCols.Value);
        }

        private void RightRows_ValueChanged(object sender, EventArgs e)
        {
            var col = RightMatrix.ColumnCount;
            RightMatrix.Clear();
            RightMatrix.Init((int)RightRows.Value, col);
        }

        private void RightCols_ValueChanged(object sender, EventArgs e)
        {
            var row = RightMatrix.RowCount;
            RightMatrix.Clear();
            RightMatrix.Init(row, (int)RightCols.Value);
        }

        private void LeftDet_Click(object sender, EventArgs e)
        {
            try
            {
                var matrix = LeftMatrix.ToDoubleArray();

                MessageBox.Show(Det.SafeDet(matrix).ToString());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }

        }

        private void RightDet_Click(object sender, EventArgs e)
        {
            try
            {
                var matrix = RightMatrix.ToDoubleArray();

                MessageBox.Show(Det.SafeDet(matrix).ToString());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }
    }
}

