namespace Calculator
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Sqrt = new System.Windows.Forms.Button();
            this.Sin = new System.Windows.Forms.Button();
            this.Cos = new System.Windows.Forms.Button();
            this.Invert = new System.Windows.Forms.Button();
            this.Sqr = new System.Windows.Forms.Button();
            this.Fact = new System.Windows.Forms.Button();
            this.Tg = new System.Windows.Forms.Button();
            this.Abs = new System.Windows.Forms.Button();
            this.Pow = new System.Windows.Forms.Button();
            this.Arctg = new System.Windows.Forms.Button();
            this.Arccos = new System.Windows.Forms.Button();
            this.Arcsin = new System.Windows.Forms.Button();
            this.E = new System.Windows.Forms.Button();
            this.pi = new System.Windows.Forms.Button();
            this.logE = new System.Windows.Forms.Button();
            this.IsDeg = new System.Windows.Forms.CheckBox();
            this.IsRad = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sqrt
            // 
            this.Sqrt.Location = new System.Drawing.Point(464, 221);
            this.Sqrt.Name = "Sqrt";
            this.Sqrt.Size = new System.Drawing.Size(79, 42);
            this.Sqrt.TabIndex = 28;
            this.Sqrt.Text = "√x";
            this.Sqrt.UseVisualStyleBackColor = true;
            this.Sqrt.Click += new System.EventHandler(this.Sqrt_Click);
            // 
            // Sin
            // 
            this.Sin.Location = new System.Drawing.Point(464, 98);
            this.Sin.Name = "Sin";
            this.Sin.Size = new System.Drawing.Size(79, 42);
            this.Sin.TabIndex = 29;
            this.Sin.Text = "Sin x";
            this.Sin.UseVisualStyleBackColor = true;
            this.Sin.Click += new System.EventHandler(this.Sin_Click);
            // 
            // Cos
            // 
            this.Cos.Location = new System.Drawing.Point(549, 98);
            this.Cos.Name = "Cos";
            this.Cos.Size = new System.Drawing.Size(79, 42);
            this.Cos.TabIndex = 30;
            this.Cos.Text = "Cos x";
            this.Cos.UseVisualStyleBackColor = true;
            this.Cos.Click += new System.EventHandler(this.Cos_Click);
            // 
            // Invert
            // 
            this.Invert.Location = new System.Drawing.Point(464, 281);
            this.Invert.Name = "Invert";
            this.Invert.Size = new System.Drawing.Size(79, 42);
            this.Invert.TabIndex = 31;
            this.Invert.Text = "1/x";
            this.Invert.UseVisualStyleBackColor = true;
            this.Invert.Click += new System.EventHandler(this.Invert_Click);
            // 
            // Sqr
            // 
            this.Sqr.Location = new System.Drawing.Point(549, 221);
            this.Sqr.Name = "Sqr";
            this.Sqr.Size = new System.Drawing.Size(79, 42);
            this.Sqr.TabIndex = 32;
            this.Sqr.Text = "x^2";
            this.Sqr.UseVisualStyleBackColor = true;
            this.Sqr.Click += new System.EventHandler(this.Sqr_Click);
            // 
            // Fact
            // 
            this.Fact.Location = new System.Drawing.Point(634, 281);
            this.Fact.Name = "Fact";
            this.Fact.Size = new System.Drawing.Size(79, 42);
            this.Fact.TabIndex = 33;
            this.Fact.Text = "x!";
            this.Fact.UseVisualStyleBackColor = true;
            this.Fact.Click += new System.EventHandler(this.Fact_Click);
            // 
            // Tg
            // 
            this.Tg.Location = new System.Drawing.Point(634, 98);
            this.Tg.Name = "Tg";
            this.Tg.Size = new System.Drawing.Size(79, 42);
            this.Tg.TabIndex = 36;
            this.Tg.Text = "Tg x";
            this.Tg.UseVisualStyleBackColor = true;
            this.Tg.Click += new System.EventHandler(this.Tg_Click);
            // 
            // Abs
            // 
            this.Abs.Location = new System.Drawing.Point(549, 281);
            this.Abs.Name = "Abs";
            this.Abs.Size = new System.Drawing.Size(79, 42);
            this.Abs.TabIndex = 37;
            this.Abs.Text = "|x|";
            this.Abs.UseVisualStyleBackColor = true;
            this.Abs.Click += new System.EventHandler(this.Abs_Click);
            // 
            // Pow
            // 
            this.Pow.Location = new System.Drawing.Point(634, 221);
            this.Pow.Name = "Pow";
            this.Pow.Size = new System.Drawing.Size(79, 42);
            this.Pow.TabIndex = 38;
            this.Pow.Text = "x^y";
            this.Pow.UseVisualStyleBackColor = true;
            this.Pow.Click += new System.EventHandler(this.Pow_Click);
            // 
            // Arctg
            // 
            this.Arctg.Location = new System.Drawing.Point(634, 160);
            this.Arctg.Name = "Arctg";
            this.Arctg.Size = new System.Drawing.Size(79, 42);
            this.Arctg.TabIndex = 41;
            this.Arctg.Text = "Arctg x";
            this.Arctg.UseVisualStyleBackColor = true;
            this.Arctg.Click += new System.EventHandler(this.Arctg_Click);
            // 
            // Arccos
            // 
            this.Arccos.Location = new System.Drawing.Point(549, 160);
            this.Arccos.Name = "Arccos";
            this.Arccos.Size = new System.Drawing.Size(79, 42);
            this.Arccos.TabIndex = 40;
            this.Arccos.Text = "Arccos x";
            this.Arccos.UseVisualStyleBackColor = true;
            this.Arccos.Click += new System.EventHandler(this.Arccos_Click);
            // 
            // Arcsin
            // 
            this.Arcsin.Location = new System.Drawing.Point(464, 160);
            this.Arcsin.Name = "Arcsin";
            this.Arcsin.Size = new System.Drawing.Size(79, 42);
            this.Arcsin.TabIndex = 39;
            this.Arcsin.Text = "Arcsin x";
            this.Arcsin.UseVisualStyleBackColor = true;
            this.Arcsin.Click += new System.EventHandler(this.Arcsin_Click);
            // 
            // E
            // 
            this.E.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.E.Location = new System.Drawing.Point(464, 341);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(79, 42);
            this.E.TabIndex = 42;
            this.E.Text = "e";
            this.E.UseVisualStyleBackColor = true;
            this.E.Click += new System.EventHandler(this.E_Click);
            // 
            // pi
            // 
            this.pi.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pi.Location = new System.Drawing.Point(549, 341);
            this.pi.Name = "pi";
            this.pi.Size = new System.Drawing.Size(79, 42);
            this.pi.TabIndex = 43;
            this.pi.Text = "π";
            this.pi.UseVisualStyleBackColor = true;
            this.pi.Click += new System.EventHandler(this.pi_Click);
            // 
            // logE
            // 
            this.logE.Location = new System.Drawing.Point(634, 341);
            this.logE.Name = "logE";
            this.logE.Size = new System.Drawing.Size(79, 42);
            this.logE.TabIndex = 44;
            this.logE.Text = "ln x";
            this.logE.UseVisualStyleBackColor = true;
            this.logE.Click += new System.EventHandler(this.logE_Click);
            // 
            // IsDeg
            // 
            this.IsDeg.AutoSize = true;
            this.IsDeg.Location = new System.Drawing.Point(464, 71);
            this.IsDeg.Name = "IsDeg";
            this.IsDeg.Size = new System.Drawing.Size(86, 21);
            this.IsDeg.TabIndex = 45;
            this.IsDeg.Text = "Градусы";
            this.IsDeg.UseVisualStyleBackColor = true;
            this.IsDeg.CheckedChanged += new System.EventHandler(this.IsDeg_CheckedChanged);
            // 
            // IsRad
            // 
            this.IsRad.AutoSize = true;
            this.IsRad.Checked = true;
            this.IsRad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsRad.Location = new System.Drawing.Point(464, 44);
            this.IsRad.Name = "IsRad";
            this.IsRad.Size = new System.Drawing.Size(89, 21);
            this.IsRad.TabIndex = 46;
            this.IsRad.Text = "Радианы";
            this.IsRad.UseVisualStyleBackColor = true;
            this.IsRad.CheckedChanged += new System.EventHandler(this.IsRad_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(726, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 285);
            this.button1.TabIndex = 47;
            this.button1.Text = "∛";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 395);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IsRad);
            this.Controls.Add(this.IsDeg);
            this.Controls.Add(this.logE);
            this.Controls.Add(this.pi);
            this.Controls.Add(this.E);
            this.Controls.Add(this.Arctg);
            this.Controls.Add(this.Arccos);
            this.Controls.Add(this.Arcsin);
            this.Controls.Add(this.Pow);
            this.Controls.Add(this.Abs);
            this.Controls.Add(this.Tg);
            this.Controls.Add(this.Fact);
            this.Controls.Add(this.Sqr);
            this.Controls.Add(this.Invert);
            this.Controls.Add(this.Cos);
            this.Controls.Add(this.Sin);
            this.Controls.Add(this.Sqrt);
            this.Name = "Form2";
            this.Text = "Инженерный";
            this.Controls.SetChildIndex(this.Sqrt, 0);
            this.Controls.SetChildIndex(this.Sin, 0);
            this.Controls.SetChildIndex(this.Cos, 0);
            this.Controls.SetChildIndex(this.Invert, 0);
            this.Controls.SetChildIndex(this.Sqr, 0);
            this.Controls.SetChildIndex(this.Fact, 0);
            this.Controls.SetChildIndex(this.Tg, 0);
            this.Controls.SetChildIndex(this.Abs, 0);
            this.Controls.SetChildIndex(this.Pow, 0);
            this.Controls.SetChildIndex(this.Arcsin, 0);
            this.Controls.SetChildIndex(this.Arccos, 0);
            this.Controls.SetChildIndex(this.Arctg, 0);
            this.Controls.SetChildIndex(this.E, 0);
            this.Controls.SetChildIndex(this.pi, 0);
            this.Controls.SetChildIndex(this.logE, 0);
            this.Controls.SetChildIndex(this.IsDeg, 0);
            this.Controls.SetChildIndex(this.IsRad, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Sqrt;
        private System.Windows.Forms.Button Sin;
        private System.Windows.Forms.Button Cos;
        private System.Windows.Forms.Button Invert;
        private System.Windows.Forms.Button Sqr;
        private System.Windows.Forms.Button Fact;
        private System.Windows.Forms.Button Tg;
        private System.Windows.Forms.Button Abs;
        private System.Windows.Forms.Button Pow;
        private System.Windows.Forms.Button Arctg;
        private System.Windows.Forms.Button Arccos;
        private System.Windows.Forms.Button Arcsin;
        private System.Windows.Forms.Button E;
        private System.Windows.Forms.Button pi;
        private System.Windows.Forms.Button logE;
        private System.Windows.Forms.CheckBox IsDeg;
        private System.Windows.Forms.CheckBox IsRad;
        private System.Windows.Forms.Button button1;
    }
}