namespace TrianglesWinForm
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
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
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
			this.btn_read = new System.Windows.Forms.Button();
			this.tb_result = new System.Windows.Forms.TextBox();
			this.pb_pictureBox = new System.Windows.Forms.PictureBox();
			this.btn_clear = new System.Windows.Forms.Button();
			this.pb_colorPicker = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pb_pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_colorPicker)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_read
			// 
			this.btn_read.Location = new System.Drawing.Point(10, 194);
			this.btn_read.Margin = new System.Windows.Forms.Padding(2);
			this.btn_read.Name = "btn_read";
			this.btn_read.Size = new System.Drawing.Size(90, 25);
			this.btn_read.TabIndex = 0;
			this.btn_read.Text = "Load";
			this.btn_read.UseVisualStyleBackColor = true;
			this.btn_read.Click += new System.EventHandler(this.Btn_read_Click);
			// 
			// tb_result
			// 
			this.tb_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_result.Location = new System.Drawing.Point(10, 26);
			this.tb_result.Margin = new System.Windows.Forms.Padding(2);
			this.tb_result.Name = "tb_result";
			this.tb_result.ReadOnly = true;
			this.tb_result.Size = new System.Drawing.Size(90, 29);
			this.tb_result.TabIndex = 1;
			this.tb_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// pb_pictureBox
			// 
			this.pb_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pb_pictureBox.Location = new System.Drawing.Point(106, 11);
			this.pb_pictureBox.Margin = new System.Windows.Forms.Padding(2);
			this.pb_pictureBox.Name = "pb_pictureBox";
			this.pb_pictureBox.Size = new System.Drawing.Size(1000, 1000);
			this.pb_pictureBox.TabIndex = 2;
			this.pb_pictureBox.TabStop = false;
			this.pb_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Pb_pictureBox_Paint);
			// 
			// btn_clear
			// 
			this.btn_clear.Location = new System.Drawing.Point(10, 223);
			this.btn_clear.Margin = new System.Windows.Forms.Padding(2);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(90, 25);
			this.btn_clear.TabIndex = 3;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clear_Click);
			// 
			// pb_colorPicker
			// 
			this.pb_colorPicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pb_colorPicker.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pb_colorPicker.Location = new System.Drawing.Point(11, 152);
			this.pb_colorPicker.Name = "pb_colorPicker";
			this.pb_colorPicker.Size = new System.Drawing.Size(90, 25);
			this.pb_colorPicker.TabIndex = 4;
			this.pb_colorPicker.TabStop = false;
			this.pb_colorPicker.Click += new System.EventHandler(this.pb_colorPicker_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Choose color";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Number of shades";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1117, 1021);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pb_colorPicker);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.pb_pictureBox);
			this.Controls.Add(this.tb_result);
			this.Controls.Add(this.btn_read);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Colored Triangles";
			((System.ComponentModel.ISupportInitialize)(this.pb_pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_colorPicker)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_read;
		private System.Windows.Forms.TextBox tb_result;
		private System.Windows.Forms.PictureBox pb_pictureBox;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.PictureBox pb_colorPicker;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

