
namespace Nonogram
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnEasyLvl = new System.Windows.Forms.Button();
            this.btnMediumLvl = new System.Windows.Forms.Button();
            this.btnHardLvl = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSolver = new System.Windows.Forms.Button();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnSolve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.btnRestart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.gbSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(678, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(613, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Location = new System.Drawing.Point(548, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(44, 47);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // btnEasyLvl
            // 
            this.btnEasyLvl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEasyLvl.Location = new System.Drawing.Point(114, 329);
            this.btnEasyLvl.Name = "btnEasyLvl";
            this.btnEasyLvl.Size = new System.Drawing.Size(138, 66);
            this.btnEasyLvl.TabIndex = 3;
            this.btnEasyLvl.Text = "Easy";
            this.btnEasyLvl.UseVisualStyleBackColor = true;
            this.btnEasyLvl.Click += new System.EventHandler(this.btnEasyLvl_Click);
            // 
            // btnMediumLvl
            // 
            this.btnMediumLvl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMediumLvl.Location = new System.Drawing.Point(286, 329);
            this.btnMediumLvl.Name = "btnMediumLvl";
            this.btnMediumLvl.Size = new System.Drawing.Size(138, 66);
            this.btnMediumLvl.TabIndex = 4;
            this.btnMediumLvl.Text = "Medium";
            this.btnMediumLvl.UseVisualStyleBackColor = true;
            this.btnMediumLvl.Click += new System.EventHandler(this.btnMediumLvl_Click);
            // 
            // btnHardLvl
            // 
            this.btnHardLvl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHardLvl.Location = new System.Drawing.Point(458, 329);
            this.btnHardLvl.Name = "btnHardLvl";
            this.btnHardLvl.Size = new System.Drawing.Size(138, 66);
            this.btnHardLvl.TabIndex = 5;
            this.btnHardLvl.Text = "Hard";
            this.btnHardLvl.UseVisualStyleBackColor = true;
            this.btnHardLvl.Click += new System.EventHandler(this.btnHardLvl_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(207, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(92, 33);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next Level";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(109, 12);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(92, 33);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.Text = "Previous Level";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Visible = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(11, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(92, 33);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSolver
            // 
            this.btnSolver.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSolver.Location = new System.Drawing.Point(265, 431);
            this.btnSolver.Name = "btnSolver";
            this.btnSolver.Size = new System.Drawing.Size(175, 66);
            this.btnSolver.TabIndex = 9;
            this.btnSolver.Text = "Solver";
            this.btnSolver.UseVisualStyleBackColor = true;
            this.btnSolver.Click += new System.EventHandler(this.btnSolver_Click);
            // 
            // gbSize
            // 
            this.gbSize.BackColor = System.Drawing.Color.White;
            this.gbSize.Controls.Add(this.radioButton3);
            this.gbSize.Controls.Add(this.radioButton2);
            this.gbSize.Controls.Add(this.radioButton1);
            this.gbSize.Location = new System.Drawing.Point(13, 51);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(90, 101);
            this.gbSize.TabIndex = 10;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Grid size";
            this.gbSize.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 75);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(61, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "15 x 15";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "10 x 10";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "5 x 5";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(109, 12);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(92, 33);
            this.btnSolve.TabIndex = 11;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Visible = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 665);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(734, 56);
            this.label1.TabIndex = 12;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTitle
            // 
            this.pbTitle.Image = global::Nonogram.Properties.Resources.title;
            this.pbTitle.Location = new System.Drawing.Point(148, 167);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(420, 129);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbTitle.TabIndex = 13;
            this.pbTitle.TabStop = false;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Red;
            this.btnRestart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRestart.ForeColor = System.Drawing.Color.Snow;
            this.btnRestart.Location = new System.Drawing.Point(11, 676);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(92, 33);
            this.btnRestart.TabIndex = 14;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 721);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.btnSolver);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnHardLvl);
            this.Controls.Add(this.btnMediumLvl);
            this.Controls.Add(this.btnEasyLvl);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(750, 760);
            this.MinimumSize = new System.Drawing.Size(750, 760);
            this.Name = "Form1";
            this.Text = "Nonogram";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnEasyLvl;
        private System.Windows.Forms.Button btnMediumLvl;
        private System.Windows.Forms.Button btnHardLvl;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSolver;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Button btnRestart;
    }
}

