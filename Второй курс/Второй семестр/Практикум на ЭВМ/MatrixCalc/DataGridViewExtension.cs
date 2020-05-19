using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixCalc
{
    public static class DataGridViewExtension
    {
        public static void RowFill(this DataGridView view)
        {
            foreach (DataGridViewRow row in view.Rows)
            {
                row.Height = view.Size.Height / view.Rows.Count;
            }
            view.Font = new Font(view.Font.FontFamily, 0.3f * view.Size.Height / (view.Rows.Count == 0 ? 1 : view.Rows.Count), FontStyle.Regular);
        }

        public static void Init(this DataGridView view, int r = 3, int c = 3)
        {
            for (int i = 0; i < c; i++)
            {
                view.Columns.Add("", "");
            }
            view.Rows.Add(r);
            for (int x = 0; x < view.ColumnCount; x++)
            {
                for (int y = 0; y < view.RowCount; y++)
                {
                    view[x, y].Value = 0;
                }
            }
        }

        public static void Clear(this DataGridView view)
        {
            view.Rows.Clear();
            view.Columns.Clear();
        }

        public static double[,] ToDoubleArray(this DataGridView view)
        {
            double[,] ret = new double[view.Rows.Count, view.Columns.Count];
            for (int x = 0; x < ret.GetLength(0); x++)
                for (int y = 0; y < ret.GetLength(1); y++)
                    if (!double.TryParse(view.Rows[x].Cells[y].Value.ToString(), out ret[x, y]))
                        throw new Exception($"Isn't numeric value at [{x + 1},{y + 1}]");

            return ret;
        }

        public static void ToDisplay(this DataGridView view, double[,] twoD)
        {
            view.Clear();

            int height = twoD.GetLength(0);
            int width = twoD.GetLength(1);

            view.ColumnCount = width;

            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(view);

                for (int c = 0; c < width; c++)
                {
                    row.Cells[c].Value = twoD[r, c].ToString();
                }

                view.Rows.Add(row);
            }
        }

        public static void ToDisplay(this DataGridView view, DataGridView other) => view.ToDisplay(other.ToDoubleArray());

        public static void ToDisplay(this DataGridView view, double arr)
        {
            view.Rows.Clear();
            view.Columns.Clear();
            view.Columns.Add("", "");
            view.Rows.Add(1);
            view[0, 0].Value = arr;
        }

    }
}

