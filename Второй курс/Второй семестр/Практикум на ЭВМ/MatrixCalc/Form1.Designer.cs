namespace MatrixCalc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResultMatrix = new System.Windows.Forms.DataGridView();
            this.RightMatrix = new System.Windows.Forms.DataGridView();
            this.LeftMatrix = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Sub = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Mul = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.RightDet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RightCols = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.RightRows = new System.Windows.Forms.NumericUpDown();
            this.RightCopy = new System.Windows.Forms.Button();
            this.RightMulByValue = new System.Windows.Forms.Button();
            this.RightTranspose = new System.Windows.Forms.Button();
            this.RightMulValue = new System.Windows.Forms.NumericUpDown();
            this.RightInverse = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LeftDet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LeftCols = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftRows = new System.Windows.Forms.NumericUpDown();
            this.LeftCopy = new System.Windows.Forms.Button();
            this.LeftMulByValue = new System.Windows.Forms.Button();
            this.LeftInv = new System.Windows.Forms.Button();
            this.LeftMulValue = new System.Windows.Forms.NumericUpDown();
            this.LeftTranspose = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftMatrix)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightMulValue)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftMulValue)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 597);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.RightMatrix, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LeftMatrix, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(995, 597);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResultMatrix);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(332, 299);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 297);
            this.panel1.TabIndex = 91;
            // 
            // ResultMatrix
            // 
            this.ResultMatrix.AllowUserToAddRows = false;
            this.ResultMatrix.AllowUserToDeleteRows = false;
            this.ResultMatrix.AllowUserToResizeColumns = false;
            this.ResultMatrix.AllowUserToResizeRows = false;
            this.ResultMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultMatrix.BackgroundColor = System.Drawing.Color.Gray;
            this.ResultMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultMatrix.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.ResultMatrix.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ResultMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ResultMatrix.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResultMatrix.DefaultCellStyle = dataGridViewCellStyle1;
            this.ResultMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultMatrix.Location = new System.Drawing.Point(0, 0);
            this.ResultMatrix.Name = "ResultMatrix";
            this.ResultMatrix.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ResultMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ResultMatrix.RowHeadersVisible = false;
            this.ResultMatrix.RowTemplate.Height = 23;
            this.ResultMatrix.Size = new System.Drawing.Size(329, 297);
            this.ResultMatrix.TabIndex = 90;
            this.ResultMatrix.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.LeftMatrix_RowsAdded);
            this.ResultMatrix.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.LeftMatrix_RowsRemoved);
            this.ResultMatrix.Resize += new System.EventHandler(this.LeftMatrix_Resize);
            // 
            // RightMatrix
            // 
            this.RightMatrix.AllowUserToAddRows = false;
            this.RightMatrix.AllowUserToDeleteRows = false;
            this.RightMatrix.AllowUserToResizeColumns = false;
            this.RightMatrix.AllowUserToResizeRows = false;
            this.RightMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RightMatrix.BackgroundColor = System.Drawing.Color.Gray;
            this.RightMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RightMatrix.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.RightMatrix.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RightMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RightMatrix.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RightMatrix.DefaultCellStyle = dataGridViewCellStyle3;
            this.RightMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightMatrix.Location = new System.Drawing.Point(665, 3);
            this.RightMatrix.Name = "RightMatrix";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RightMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.RightMatrix.RowHeadersVisible = false;
            this.RightMatrix.RowTemplate.Height = 23;
            this.RightMatrix.Size = new System.Drawing.Size(327, 292);
            this.RightMatrix.TabIndex = 89;
            this.RightMatrix.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.LeftMatrix_RowsAdded);
            this.RightMatrix.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.LeftMatrix_RowsRemoved);
            this.RightMatrix.Resize += new System.EventHandler(this.LeftMatrix_Resize);
            // 
            // LeftMatrix
            // 
            this.LeftMatrix.AllowUserToAddRows = false;
            this.LeftMatrix.AllowUserToDeleteRows = false;
            this.LeftMatrix.AllowUserToResizeColumns = false;
            this.LeftMatrix.AllowUserToResizeRows = false;
            this.LeftMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LeftMatrix.BackgroundColor = System.Drawing.Color.Gray;
            this.LeftMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LeftMatrix.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.LeftMatrix.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.LeftMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.LeftMatrix.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = "0";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LeftMatrix.DefaultCellStyle = dataGridViewCellStyle5;
            this.LeftMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftMatrix.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.LeftMatrix.Location = new System.Drawing.Point(3, 3);
            this.LeftMatrix.Name = "LeftMatrix";
            this.LeftMatrix.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LeftMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.LeftMatrix.RowHeadersVisible = false;
            this.LeftMatrix.RowTemplate.Height = 23;
            this.LeftMatrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LeftMatrix.Size = new System.Drawing.Size(325, 292);
            this.LeftMatrix.TabIndex = 88;
            this.LeftMatrix.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.LeftMatrix_RowsAdded);
            this.LeftMatrix.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.LeftMatrix_RowsRemoved);
            this.LeftMatrix.Resize += new System.EventHandler(this.LeftMatrix_Resize);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Sub);
            this.panel3.Controls.Add(this.Add);
            this.panel3.Controls.Add(this.Mul);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(334, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 292);
            this.panel3.TabIndex = 92;
            // 
            // Sub
            // 
            this.Sub.Location = new System.Drawing.Point(3, 32);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(319, 23);
            this.Sub.TabIndex = 2;
            this.Sub.Text = "Sub matrices";
            this.Sub.UseVisualStyleBackColor = true;
            this.Sub.Click += new System.EventHandler(this.Sub_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(3, 3);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(319, 23);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add matrices";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Mul
            // 
            this.Mul.Location = new System.Drawing.Point(3, 61);
            this.Mul.Name = "Mul";
            this.Mul.Size = new System.Drawing.Size(319, 23);
            this.Mul.TabIndex = 0;
            this.Mul.Text = "Multiply matrices";
            this.Mul.UseVisualStyleBackColor = true;
            this.Mul.Click += new System.EventHandler(this.Mul_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.RightDet);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.RightCols);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.RightRows);
            this.panel4.Controls.Add(this.RightCopy);
            this.panel4.Controls.Add(this.RightMulByValue);
            this.panel4.Controls.Add(this.RightTranspose);
            this.panel4.Controls.Add(this.RightMulValue);
            this.panel4.Controls.Add(this.RightInverse);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(665, 301);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 293);
            this.panel4.TabIndex = 93;
            // 
            // RightDet
            // 
            this.RightDet.Location = new System.Drawing.Point(40, 101);
            this.RightDet.Name = "RightDet";
            this.RightDet.Size = new System.Drawing.Size(124, 23);
            this.RightDet.TabIndex = 16;
            this.RightDet.Text = "Det";
            this.RightDet.UseVisualStyleBackColor = true;
            this.RightDet.Click += new System.EventHandler(this.RightDet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(176, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cols:";
            // 
            // RightCols
            // 
            this.RightCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RightCols.Location = new System.Drawing.Point(234, 12);
            this.RightCols.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RightCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RightCols.Name = "RightCols";
            this.RightCols.Size = new System.Drawing.Size(60, 21);
            this.RightCols.TabIndex = 14;
            this.RightCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.RightCols.ValueChanged += new System.EventHandler(this.RightCols_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(46, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Rows:";
            // 
            // RightRows
            // 
            this.RightRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RightRows.Location = new System.Drawing.Point(104, 12);
            this.RightRows.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RightRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RightRows.Name = "RightRows";
            this.RightRows.Size = new System.Drawing.Size(60, 21);
            this.RightRows.TabIndex = 12;
            this.RightRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.RightRows.ValueChanged += new System.EventHandler(this.RightRows_ValueChanged);
            // 
            // RightCopy
            // 
            this.RightCopy.Location = new System.Drawing.Point(40, 181);
            this.RightCopy.Name = "RightCopy";
            this.RightCopy.Size = new System.Drawing.Size(254, 23);
            this.RightCopy.TabIndex = 8;
            this.RightCopy.Text = "Copy from Result";
            this.RightCopy.UseVisualStyleBackColor = true;
            this.RightCopy.Click += new System.EventHandler(this.RightCopy_Click);
            // 
            // RightMulByValue
            // 
            this.RightMulByValue.Location = new System.Drawing.Point(40, 43);
            this.RightMulByValue.Name = "RightMulByValue";
            this.RightMulByValue.Size = new System.Drawing.Size(124, 23);
            this.RightMulByValue.TabIndex = 7;
            this.RightMulByValue.Text = "Multiply by Value";
            this.RightMulByValue.UseVisualStyleBackColor = true;
            this.RightMulByValue.Click += new System.EventHandler(this.RightMulByValue_Click);
            // 
            // RightTranspose
            // 
            this.RightTranspose.Location = new System.Drawing.Point(170, 43);
            this.RightTranspose.Name = "RightTranspose";
            this.RightTranspose.Size = new System.Drawing.Size(124, 23);
            this.RightTranspose.TabIndex = 9;
            this.RightTranspose.Text = "Transpose";
            this.RightTranspose.UseVisualStyleBackColor = true;
            this.RightTranspose.Click += new System.EventHandler(this.RightTranspose_Click);
            // 
            // RightMulValue
            // 
            this.RightMulValue.DecimalPlaces = 2;
            this.RightMulValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RightMulValue.Location = new System.Drawing.Point(40, 72);
            this.RightMulValue.Name = "RightMulValue";
            this.RightMulValue.Size = new System.Drawing.Size(124, 21);
            this.RightMulValue.TabIndex = 8;
            // 
            // RightInverse
            // 
            this.RightInverse.Location = new System.Drawing.Point(170, 72);
            this.RightInverse.Name = "RightInverse";
            this.RightInverse.Size = new System.Drawing.Size(124, 23);
            this.RightInverse.TabIndex = 10;
            this.RightInverse.Text = "Inverse Matrix";
            this.RightInverse.UseVisualStyleBackColor = true;
            this.RightInverse.Click += new System.EventHandler(this.RightInverse_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.LeftDet);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.LeftCols);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.LeftRows);
            this.panel5.Controls.Add(this.LeftCopy);
            this.panel5.Controls.Add(this.LeftMulByValue);
            this.panel5.Controls.Add(this.LeftInv);
            this.panel5.Controls.Add(this.LeftMulValue);
            this.panel5.Controls.Add(this.LeftTranspose);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 301);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(325, 293);
            this.panel5.TabIndex = 94;
            // 
            // LeftDet
            // 
            this.LeftDet.Location = new System.Drawing.Point(37, 101);
            this.LeftDet.Name = "LeftDet";
            this.LeftDet.Size = new System.Drawing.Size(124, 23);
            this.LeftDet.TabIndex = 12;
            this.LeftDet.Text = "Det";
            this.LeftDet.UseVisualStyleBackColor = true;
            this.LeftDet.Click += new System.EventHandler(this.LeftDet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(173, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cols:";
            // 
            // LeftCols
            // 
            this.LeftCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeftCols.Location = new System.Drawing.Point(231, 16);
            this.LeftCols.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.LeftCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LeftCols.Name = "LeftCols";
            this.LeftCols.Size = new System.Drawing.Size(60, 21);
            this.LeftCols.TabIndex = 10;
            this.LeftCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LeftCols.ValueChanged += new System.EventHandler(this.LeftCols_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Rows:";
            // 
            // LeftRows
            // 
            this.LeftRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeftRows.Location = new System.Drawing.Point(101, 16);
            this.LeftRows.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.LeftRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LeftRows.Name = "LeftRows";
            this.LeftRows.Size = new System.Drawing.Size(60, 21);
            this.LeftRows.TabIndex = 8;
            this.LeftRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LeftRows.ValueChanged += new System.EventHandler(this.LeftRows_ValueChanged);
            // 
            // LeftCopy
            // 
            this.LeftCopy.Location = new System.Drawing.Point(37, 181);
            this.LeftCopy.Name = "LeftCopy";
            this.LeftCopy.Size = new System.Drawing.Size(254, 23);
            this.LeftCopy.TabIndex = 7;
            this.LeftCopy.Text = "Copy from Result";
            this.LeftCopy.UseVisualStyleBackColor = true;
            this.LeftCopy.Click += new System.EventHandler(this.LeftCopy_Click);
            // 
            // LeftMulByValue
            // 
            this.LeftMulByValue.Location = new System.Drawing.Point(37, 43);
            this.LeftMulByValue.Name = "LeftMulByValue";
            this.LeftMulByValue.Size = new System.Drawing.Size(124, 23);
            this.LeftMulByValue.TabIndex = 3;
            this.LeftMulByValue.Text = "Multiply by Value";
            this.LeftMulByValue.UseVisualStyleBackColor = true;
            this.LeftMulByValue.Click += new System.EventHandler(this.LeftMulByNumber_Click);
            // 
            // LeftInv
            // 
            this.LeftInv.Location = new System.Drawing.Point(167, 72);
            this.LeftInv.Name = "LeftInv";
            this.LeftInv.Size = new System.Drawing.Size(124, 23);
            this.LeftInv.TabIndex = 6;
            this.LeftInv.Text = "Inverse Matrix";
            this.LeftInv.UseVisualStyleBackColor = true;
            this.LeftInv.Click += new System.EventHandler(this.LeftInv_Click);
            // 
            // LeftMulValue
            // 
            this.LeftMulValue.DecimalPlaces = 2;
            this.LeftMulValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeftMulValue.Location = new System.Drawing.Point(37, 74);
            this.LeftMulValue.Name = "LeftMulValue";
            this.LeftMulValue.Size = new System.Drawing.Size(124, 21);
            this.LeftMulValue.TabIndex = 4;
            // 
            // LeftTranspose
            // 
            this.LeftTranspose.Location = new System.Drawing.Point(167, 43);
            this.LeftTranspose.Name = "LeftTranspose";
            this.LeftTranspose.Size = new System.Drawing.Size(124, 23);
            this.LeftTranspose.TabIndex = 5;
            this.LeftTranspose.Text = "Transpose";
            this.LeftTranspose.UseVisualStyleBackColor = true;
            this.LeftTranspose.Click += new System.EventHandler(this.LeftTranspose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 597);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Matrix Calc";
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftMatrix)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightMulValue)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftMulValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Mul;
        private System.Windows.Forms.DataGridView LeftMatrix;
        private System.Windows.Forms.DataGridView ResultMatrix;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Sub;
        private System.Windows.Forms.NumericUpDown LeftMulValue;
        private System.Windows.Forms.Button LeftMulByValue;
        private System.Windows.Forms.Button LeftTranspose;
        private System.Windows.Forms.Button LeftInv;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button RightMulByValue;
        private System.Windows.Forms.Button RightInverse;
        private System.Windows.Forms.NumericUpDown RightMulValue;
        private System.Windows.Forms.Button RightTranspose;
        private System.Windows.Forms.Button RightCopy;
        private System.Windows.Forms.Button LeftCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RightCols;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RightRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown LeftCols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown LeftRows;
        private System.Windows.Forms.DataGridView RightMatrix;
        private System.Windows.Forms.Button LeftDet;
        private System.Windows.Forms.Button RightDet;
    }
}

