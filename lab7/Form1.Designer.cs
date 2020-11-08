namespace lab7
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
            this.components = new System.ComponentModel.Container();
            this.IMG1 = new Emgu.CV.UI.ImageBox();
            this.load = new System.Windows.Forms.Button();
            this.dotsb = new System.Windows.Forms.Button();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.IMG2 = new Emgu.CV.UI.ImageBox();
            this.load2 = new System.Windows.Forms.Button();
            this.function1 = new System.Windows.Forms.Button();
            this.homob = new System.Windows.Forms.Button();
            this.pointcomp = new System.Windows.Forms.Button();
            this.IMG3 = new Emgu.CV.UI.ImageBox();
            this.comph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IMG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMG3)).BeginInit();
            this.SuspendLayout();
            // 
            // IMG1
            // 
            this.IMG1.Location = new System.Drawing.Point(12, 12);
            this.IMG1.Name = "IMG1";
            this.IMG1.Size = new System.Drawing.Size(640, 480);
            this.IMG1.TabIndex = 2;
            this.IMG1.TabStop = false;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(12, 498);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(151, 32);
            this.load.TabIndex = 3;
            this.load.Text = "Load first";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // dotsb
            // 
            this.dotsb.Location = new System.Drawing.Point(223, 498);
            this.dotsb.Name = "dotsb";
            this.dotsb.Size = new System.Drawing.Size(151, 32);
            this.dotsb.TabIndex = 4;
            this.dotsb.Text = "Find dots";
            this.dotsb.UseVisualStyleBackColor = true;
            this.dotsb.Click += new System.EventHandler(this.dotsb_Click);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(169, 498);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(53, 17);
            this.rb1.TabIndex = 5;
            this.rb1.TabStop = true;
            this.rb1.Text = "GFTT";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(169, 521);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(48, 17);
            this.rb2.TabIndex = 6;
            this.rb2.Text = "Brisk";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(169, 544);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(45, 17);
            this.rb3.TabIndex = 7;
            this.rb3.Text = "Fast";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.CheckedChanged += new System.EventHandler(this.rb3_CheckedChanged);
            // 
            // IMG2
            // 
            this.IMG2.Location = new System.Drawing.Point(658, 12);
            this.IMG2.Name = "IMG2";
            this.IMG2.Size = new System.Drawing.Size(640, 480);
            this.IMG2.TabIndex = 8;
            this.IMG2.TabStop = false;
            // 
            // load2
            // 
            this.load2.Location = new System.Drawing.Point(12, 536);
            this.load2.Name = "load2";
            this.load2.Size = new System.Drawing.Size(151, 32);
            this.load2.TabIndex = 9;
            this.load2.Text = "Load second";
            this.load2.UseVisualStyleBackColor = true;
            this.load2.Click += new System.EventHandler(this.load2_Click);
            // 
            // function1
            // 
            this.function1.Location = new System.Drawing.Point(380, 498);
            this.function1.Name = "function1";
            this.function1.Size = new System.Drawing.Size(151, 32);
            this.function1.TabIndex = 10;
            this.function1.Text = "Find dots on second img";
            this.function1.UseVisualStyleBackColor = true;
            this.function1.Click += new System.EventHandler(this.function1_Click);
            // 
            // homob
            // 
            this.homob.Location = new System.Drawing.Point(380, 536);
            this.homob.Name = "homob";
            this.homob.Size = new System.Drawing.Size(151, 32);
            this.homob.TabIndex = 12;
            this.homob.Text = "Homography";
            this.homob.UseVisualStyleBackColor = true;
            this.homob.Click += new System.EventHandler(this.homob_Click);
            // 
            // pointcomp
            // 
            this.pointcomp.Location = new System.Drawing.Point(537, 498);
            this.pointcomp.Name = "pointcomp";
            this.pointcomp.Size = new System.Drawing.Size(151, 32);
            this.pointcomp.TabIndex = 13;
            this.pointcomp.Text = "Point comprassion";
            this.pointcomp.UseVisualStyleBackColor = true;
            this.pointcomp.Click += new System.EventHandler(this.button1_Click);
            // 
            // IMG3
            // 
            this.IMG3.Location = new System.Drawing.Point(12, 12);
            this.IMG3.Name = "IMG3";
            this.IMG3.Size = new System.Drawing.Size(1286, 480);
            this.IMG3.TabIndex = 2;
            this.IMG3.TabStop = false;
            // 
            // comph
            // 
            this.comph.Location = new System.Drawing.Point(537, 536);
            this.comph.Name = "comph";
            this.comph.Size = new System.Drawing.Size(151, 32);
            this.comph.TabIndex = 14;
            this.comph.Text = "Comp homography";
            this.comph.UseVisualStyleBackColor = true;
            this.comph.Click += new System.EventHandler(this.comph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 613);
            this.Controls.Add(this.comph);
            this.Controls.Add(this.IMG3);
            this.Controls.Add(this.pointcomp);
            this.Controls.Add(this.homob);
            this.Controls.Add(this.function1);
            this.Controls.Add(this.load2);
            this.Controls.Add(this.IMG2);
            this.Controls.Add(this.rb3);
            this.Controls.Add(this.rb2);
            this.Controls.Add(this.rb1);
            this.Controls.Add(this.dotsb);
            this.Controls.Add(this.load);
            this.Controls.Add(this.IMG1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.IMG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMG3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox IMG1;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button dotsb;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb3;
        private Emgu.CV.UI.ImageBox IMG2;
        private System.Windows.Forms.Button load2;
        private System.Windows.Forms.Button function1;
        private System.Windows.Forms.Button homob;
        private System.Windows.Forms.Button pointcomp;
        private Emgu.CV.UI.ImageBox IMG3;
        private System.Windows.Forms.Button comph;
    }
}

