namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChangeSig = new System.Windows.Forms.Button();
            this.Backspace = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.Seven = new System.Windows.Forms.Button();
            this.Eight = new System.Windows.Forms.Button();
            this.Nine = new System.Windows.Forms.Button();
            this.Sub = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Five = new System.Windows.Forms.Button();
            this.Six = new System.Windows.Forms.Button();
            this.Mul = new System.Windows.Forms.Button();
            this.One = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Div = new System.Windows.Forms.Button();
            this.Zero = new System.Windows.Forms.Button();
            this.DecimalSep = new System.Windows.Forms.Button();
            this.Evaluate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MemTextBox = new System.Windows.Forms.TextBox();
            this.MemAdd = new System.Windows.Forms.Button();
            this.MemSub = new System.Windows.Forms.Button();
            this.MemClear = new System.Windows.Forms.Button();
            this.MemRes = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.обычныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инженегрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MemToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(13, 45);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(338, 34);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ChangeSig
            // 
            this.ChangeSig.Location = new System.Drawing.Point(186, 98);
            this.ChangeSig.Margin = new System.Windows.Forms.Padding(4);
            this.ChangeSig.Name = "ChangeSig";
            this.ChangeSig.Size = new System.Drawing.Size(79, 42);
            this.ChangeSig.TabIndex = 1;
            this.ChangeSig.Text = "±";
            this.ChangeSig.UseVisualStyleBackColor = true;
            this.ChangeSig.Click += new System.EventHandler(this.ChangeSign);
            // 
            // Backspace
            // 
            this.Backspace.Location = new System.Drawing.Point(100, 98);
            this.Backspace.Margin = new System.Windows.Forms.Padding(4);
            this.Backspace.Name = "Backspace";
            this.Backspace.Size = new System.Drawing.Size(79, 42);
            this.Backspace.TabIndex = 2;
            this.Backspace.Text = "←";
            this.Backspace.UseVisualStyleBackColor = true;
            this.Backspace.Click += new System.EventHandler(this.Backspace_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(13, 98);
            this.Clear.Margin = new System.Windows.Forms.Padding(4);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(79, 42);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "C";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(272, 221);
            this.Add.Margin = new System.Windows.Forms.Padding(4);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(79, 42);
            this.Add.TabIndex = 4;
            this.Add.Text = "+";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Seven
            // 
            this.Seven.Location = new System.Drawing.Point(13, 160);
            this.Seven.Margin = new System.Windows.Forms.Padding(4);
            this.Seven.Name = "Seven";
            this.Seven.Size = new System.Drawing.Size(79, 42);
            this.Seven.TabIndex = 5;
            this.Seven.Text = "7";
            this.Seven.UseVisualStyleBackColor = true;
            this.Seven.Click += new System.EventHandler(this.Seven_Click);
            // 
            // Eight
            // 
            this.Eight.Location = new System.Drawing.Point(100, 160);
            this.Eight.Margin = new System.Windows.Forms.Padding(4);
            this.Eight.Name = "Eight";
            this.Eight.Size = new System.Drawing.Size(79, 42);
            this.Eight.TabIndex = 6;
            this.Eight.Text = "8";
            this.Eight.UseVisualStyleBackColor = true;
            this.Eight.Click += new System.EventHandler(this.Eight_Click);
            // 
            // Nine
            // 
            this.Nine.Location = new System.Drawing.Point(186, 160);
            this.Nine.Margin = new System.Windows.Forms.Padding(4);
            this.Nine.Name = "Nine";
            this.Nine.Size = new System.Drawing.Size(79, 42);
            this.Nine.TabIndex = 7;
            this.Nine.Text = "9";
            this.Nine.UseVisualStyleBackColor = true;
            this.Nine.Click += new System.EventHandler(this.Nine_Click);
            // 
            // Sub
            // 
            this.Sub.Location = new System.Drawing.Point(272, 281);
            this.Sub.Margin = new System.Windows.Forms.Padding(4);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(79, 42);
            this.Sub.TabIndex = 8;
            this.Sub.Text = "-";
            this.Sub.UseVisualStyleBackColor = true;
            this.Sub.Click += new System.EventHandler(this.Sub_Click);
            // 
            // Four
            // 
            this.Four.Location = new System.Drawing.Point(13, 221);
            this.Four.Margin = new System.Windows.Forms.Padding(4);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(79, 42);
            this.Four.TabIndex = 9;
            this.Four.Text = "4";
            this.Four.UseVisualStyleBackColor = true;
            this.Four.Click += new System.EventHandler(this.Four_Click);
            // 
            // Five
            // 
            this.Five.Location = new System.Drawing.Point(100, 221);
            this.Five.Margin = new System.Windows.Forms.Padding(4);
            this.Five.Name = "Five";
            this.Five.Size = new System.Drawing.Size(79, 42);
            this.Five.TabIndex = 10;
            this.Five.Text = "5";
            this.Five.UseVisualStyleBackColor = true;
            this.Five.Click += new System.EventHandler(this.Five_Click);
            // 
            // Six
            // 
            this.Six.Location = new System.Drawing.Point(186, 221);
            this.Six.Margin = new System.Windows.Forms.Padding(4);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(79, 42);
            this.Six.TabIndex = 11;
            this.Six.Text = "6";
            this.Six.UseVisualStyleBackColor = true;
            this.Six.Click += new System.EventHandler(this.Six_Click);
            // 
            // Mul
            // 
            this.Mul.Location = new System.Drawing.Point(272, 98);
            this.Mul.Margin = new System.Windows.Forms.Padding(4);
            this.Mul.Name = "Mul";
            this.Mul.Size = new System.Drawing.Size(79, 42);
            this.Mul.TabIndex = 12;
            this.Mul.Text = "*";
            this.Mul.UseVisualStyleBackColor = true;
            this.Mul.Click += new System.EventHandler(this.Mul_Click);
            // 
            // One
            // 
            this.One.Location = new System.Drawing.Point(13, 281);
            this.One.Margin = new System.Windows.Forms.Padding(4);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(79, 42);
            this.One.TabIndex = 13;
            this.One.Text = "1";
            this.One.UseVisualStyleBackColor = true;
            this.One.Click += new System.EventHandler(this.One_Click);
            // 
            // Two
            // 
            this.Two.Location = new System.Drawing.Point(100, 281);
            this.Two.Margin = new System.Windows.Forms.Padding(4);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(79, 42);
            this.Two.TabIndex = 14;
            this.Two.Text = "2";
            this.Two.UseVisualStyleBackColor = true;
            this.Two.Click += new System.EventHandler(this.Two_Click);
            // 
            // Three
            // 
            this.Three.Location = new System.Drawing.Point(186, 281);
            this.Three.Margin = new System.Windows.Forms.Padding(4);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(79, 42);
            this.Three.TabIndex = 15;
            this.Three.Text = "3";
            this.Three.UseVisualStyleBackColor = true;
            this.Three.Click += new System.EventHandler(this.Three_Click);
            // 
            // Div
            // 
            this.Div.Location = new System.Drawing.Point(272, 160);
            this.Div.Margin = new System.Windows.Forms.Padding(4);
            this.Div.Name = "Div";
            this.Div.Size = new System.Drawing.Size(79, 42);
            this.Div.TabIndex = 16;
            this.Div.Text = "/";
            this.Div.UseVisualStyleBackColor = true;
            this.Div.Click += new System.EventHandler(this.Div_Click);
            // 
            // Zero
            // 
            this.Zero.Location = new System.Drawing.Point(13, 341);
            this.Zero.Margin = new System.Windows.Forms.Padding(4);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(79, 42);
            this.Zero.TabIndex = 17;
            this.Zero.Text = "0";
            this.Zero.UseVisualStyleBackColor = true;
            this.Zero.Click += new System.EventHandler(this.Zero_Click);
            // 
            // DecimalSep
            // 
            this.DecimalSep.Location = new System.Drawing.Point(100, 341);
            this.DecimalSep.Margin = new System.Windows.Forms.Padding(4);
            this.DecimalSep.Name = "DecimalSep";
            this.DecimalSep.Size = new System.Drawing.Size(79, 42);
            this.DecimalSep.TabIndex = 18;
            this.DecimalSep.Text = ".";
            this.DecimalSep.UseVisualStyleBackColor = true;
            this.DecimalSep.Click += new System.EventHandler(this.DecimalSeparator_Click);
            // 
            // Evaluate
            // 
            this.Evaluate.Location = new System.Drawing.Point(186, 341);
            this.Evaluate.Margin = new System.Windows.Forms.Padding(4);
            this.Evaluate.Name = "Evaluate";
            this.Evaluate.Size = new System.Drawing.Size(165, 42);
            this.Evaluate.TabIndex = 19;
            this.Evaluate.Text = "=";
            this.Evaluate.UseVisualStyleBackColor = true;
            this.Evaluate.Click += new System.EventHandler(this.Eval_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "        ";
            // 
            // MemTextBox
            // 
            this.MemTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.MemTextBox.HideSelection = false;
            this.MemTextBox.Location = new System.Drawing.Point(363, 52);
            this.MemTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.MemTextBox.Name = "MemTextBox";
            this.MemTextBox.ReadOnly = true;
            this.MemTextBox.Size = new System.Drawing.Size(79, 22);
            this.MemTextBox.TabIndex = 21;
            this.MemTextBox.Text = "0";
            this.MemTextBox.MouseHover += new System.EventHandler(this.MemtextBox_MouseHoover);
            // 
            // MemAdd
            // 
            this.MemAdd.Location = new System.Drawing.Point(363, 221);
            this.MemAdd.Margin = new System.Windows.Forms.Padding(4);
            this.MemAdd.Name = "MemAdd";
            this.MemAdd.Size = new System.Drawing.Size(79, 42);
            this.MemAdd.TabIndex = 23;
            this.MemAdd.Text = "M+";
            this.MemAdd.UseVisualStyleBackColor = true;
            this.MemAdd.Click += new System.EventHandler(this.MemAdd_Click);
            // 
            // MemSub
            // 
            this.MemSub.Location = new System.Drawing.Point(363, 281);
            this.MemSub.Margin = new System.Windows.Forms.Padding(4);
            this.MemSub.Name = "MemSub";
            this.MemSub.Size = new System.Drawing.Size(79, 42);
            this.MemSub.TabIndex = 24;
            this.MemSub.Text = "M-";
            this.MemSub.UseVisualStyleBackColor = true;
            this.MemSub.Click += new System.EventHandler(this.MemSub_Click);
            // 
            // MemClear
            // 
            this.MemClear.Location = new System.Drawing.Point(363, 98);
            this.MemClear.Margin = new System.Windows.Forms.Padding(4);
            this.MemClear.Name = "MemClear";
            this.MemClear.Size = new System.Drawing.Size(79, 42);
            this.MemClear.TabIndex = 25;
            this.MemClear.Text = "MC";
            this.MemClear.UseVisualStyleBackColor = true;
            this.MemClear.Click += new System.EventHandler(this.MemClear_Click);
            // 
            // MemRes
            // 
            this.MemRes.Location = new System.Drawing.Point(363, 160);
            this.MemRes.Margin = new System.Windows.Forms.Padding(4);
            this.MemRes.Name = "MemRes";
            this.MemRes.Size = new System.Drawing.Size(79, 42);
            this.MemRes.TabIndex = 26;
            this.MemRes.Text = "MR";
            this.MemRes.UseVisualStyleBackColor = true;
            this.MemRes.Click += new System.EventHandler(this.MemRes_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обычныйToolStripMenuItem,
            this.инженегрToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(455, 28);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // обычныйToolStripMenuItem
            // 
            this.обычныйToolStripMenuItem.Name = "обычныйToolStripMenuItem";
            this.обычныйToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.обычныйToolStripMenuItem.Text = "Обычный";
            this.обычныйToolStripMenuItem.Click += new System.EventHandler(this.обычныйToolStripMenuItem_Click);
            // 
            // инженегрToolStripMenuItem
            // 
            this.инженегрToolStripMenuItem.Name = "инженегрToolStripMenuItem";
            this.инженегрToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.инженегрToolStripMenuItem.Text = "Инженерный";
            this.инженегрToolStripMenuItem.Click += new System.EventHandler(this.ИнженерныйToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(455, 402);
            this.Controls.Add(this.MemRes);
            this.Controls.Add(this.MemClear);
            this.Controls.Add(this.MemSub);
            this.Controls.Add(this.MemAdd);
            this.Controls.Add(this.MemTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Evaluate);
            this.Controls.Add(this.DecimalSep);
            this.Controls.Add(this.Zero);
            this.Controls.Add(this.Div);
            this.Controls.Add(this.Three);
            this.Controls.Add(this.Two);
            this.Controls.Add(this.One);
            this.Controls.Add(this.Mul);
            this.Controls.Add(this.Six);
            this.Controls.Add(this.Five);
            this.Controls.Add(this.Four);
            this.Controls.Add(this.Sub);
            this.Controls.Add(this.Nine);
            this.Controls.Add(this.Eight);
            this.Controls.Add(this.Seven);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Backspace);
            this.Controls.Add(this.ChangeSig);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Обычный";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ChangeSig;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Seven;
        private System.Windows.Forms.Button Eight;
        private System.Windows.Forms.Button Nine;
        private System.Windows.Forms.Button Sub;
        private System.Windows.Forms.Button Four;
        private System.Windows.Forms.Button Five;
        private System.Windows.Forms.Button Six;
        private System.Windows.Forms.Button Mul;
        private System.Windows.Forms.Button One;
        private System.Windows.Forms.Button Two;
        private System.Windows.Forms.Button Three;
        private System.Windows.Forms.Button Div;
        private System.Windows.Forms.Button Zero;
        private System.Windows.Forms.Button DecimalSep;
        private System.Windows.Forms.Button Evaluate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MemTextBox;
        private System.Windows.Forms.Button MemAdd;
        private System.Windows.Forms.Button MemSub;
        private System.Windows.Forms.Button MemClear;
        private System.Windows.Forms.Button MemRes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem обычныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инженегрToolStripMenuItem;
        private System.Windows.Forms.ToolTip MemToolTip;
        private System.Windows.Forms.Button Backspace;
    }
}

