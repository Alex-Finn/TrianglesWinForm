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
			((System.ComponentModel.ISupportInitialize)(this.pb_pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_read
			// 
			this.btn_read.Location = new System.Drawing.Point(13, 13);
			this.btn_read.Name = "btn_read";
			this.btn_read.Size = new System.Drawing.Size(75, 23);
			this.btn_read.TabIndex = 0;
			this.btn_read.Text = "Read";
			this.btn_read.UseVisualStyleBackColor = true;
			this.btn_read.Click += new System.EventHandler(this.Btn_read_Click);
			// 
			// tb_result
			// 
			this.tb_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tb_result.Location = new System.Drawing.Point(13, 43);
			this.tb_result.Name = "tb_result";
			this.tb_result.Size = new System.Drawing.Size(75, 21);
			this.tb_result.TabIndex = 1;
			this.tb_result.Text = "Press \"Read\"";
			this.tb_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// pb_pictureBox
			// 
			this.pb_pictureBox.Location = new System.Drawing.Point(95, 13);
			this.pb_pictureBox.Name = "pb_pictureBox";
			this.pb_pictureBox.Size = new System.Drawing.Size(1000, 1000);
			this.pb_pictureBox.TabIndex = 2;
			this.pb_pictureBox.TabStop = false;
			this.pb_pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Pb_pictureBox_Paint);
			// 
			// btn_clear
			// 
			this.btn_clear.Location = new System.Drawing.Point(13, 414);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(75, 23);
			this.btn_clear.TabIndex = 3;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Click += new System.EventHandler(this.Btn_clear_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1111, 1028);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.pb_pictureBox);
			this.Controls.Add(this.tb_result);
			this.Controls.Add(this.btn_read);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pb_pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_read;
		private System.Windows.Forms.TextBox tb_result;
		private System.Windows.Forms.PictureBox pb_pictureBox;
		private System.Windows.Forms.Button btn_clear;
	}
}

