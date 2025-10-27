namespace ГИБДД
{
    partial class export
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::ГИБДД.Properties.Resources.image_1;
			this.pictureBox1.Location = new System.Drawing.Point(0, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(115, 111);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Rubik One", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(121, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 33);
			this.label1.TabIndex = 4;
			this.label1.Text = "Экспорт в ФССП";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Rubik One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(190, 167);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "Период";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Rubik One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(470, 167);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 48);
			this.label3.TabIndex = 6;
			this.label3.Text = "Выбрать\r\nводителя:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Rubik One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(469, 362);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(131, 26);
			this.label4.TabIndex = 2;
			this.label4.Text = "Оплачено:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Rubik One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(469, 279);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(230, 26);
			this.label6.TabIndex = 3;
			this.label6.Text = "Найдено штрафов:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Rubik One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(469, 320);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(159, 26);
			this.label8.TabIndex = 4;
			this.label8.Text = "Просрочено:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Rubik One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label9.Location = new System.Drawing.Point(705, 279);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 26);
			this.label9.TabIndex = 5;
			this.label9.Text = "12";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Rubik One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label10.Location = new System.Drawing.Point(634, 320);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(28, 26);
			this.label10.TabIndex = 6;
			this.label10.Text = "2";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Rubik One", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
			this.label11.Location = new System.Drawing.Point(606, 362);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(39, 26);
			this.label11.TabIndex = 7;
			this.label11.Text = "10";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(194, 215);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 10;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightGray;
			this.button1.Font = new System.Drawing.Font("Rubik One", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(140, 464);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(272, 52);
			this.button1.TabIndex = 19;
			this.button1.Text = "Распечатать";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.LightGray;
			this.button2.Font = new System.Drawing.Font("Rubik One", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.Location = new System.Drawing.Point(474, 464);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(272, 52);
			this.button2.TabIndex = 20;
			this.button2.Text = "Закрыть";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// export
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(884, 561);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.monthCalendar1);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "export";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "export";
			this.Load += new System.EventHandler(this.export_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}