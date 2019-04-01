using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrianglesWinForm.Models;
//using Point = TrianglesWinForm.Models.Point;

namespace TrianglesWinForm
{
	public partial class Form1 : Form
	{
		List<Triangle> triangles;
		List<Point> points;
		bool doPaint;
		public Form1()
		{
			doPaint = false;
			triangles = new List<Triangle>();
			points = new List<Point>();
			InitializeComponent();
		}

		private void ReadData()
		{
			triangles.Add(new Triangle(
				new Point(300, 300),
				new Point(450, 200),
				new Point(100, 150)));



			points.Add(new Point(100, 100));
			points.Add(new Point(200, 200));

			ReadFile();

		}

		private void Btn_read_Click( object sender, EventArgs e )
		{
			doPaint = true;
			ReadData();
			DoPaintOnPictureBox();


		}

		private void DoPaintOnPictureBox()
		{
			pb_pictureBox.Invalidate();
		}

		private void Pb_pictureBox_Paint( object sender, PaintEventArgs e )
		{
			if ( doPaint == true )
			{
				Pen blackPen = new Pen(Color.Black, 5);



				e.Graphics.DrawLine(blackPen, points[0], points[1]);

				DrawTriangles(e);


			}
			else
			{
				e.Graphics.Clear(pb_pictureBox.BackColor);
			}
		}

		private void DrawTriangles( PaintEventArgs e )
		{
			foreach ( var triangle in triangles )
			{
				triangle.Draw(e);
			}
		}

		private void Btn_clear_Click( object sender, EventArgs e )
		{
			doPaint = false;
			DoPaintOnPictureBox();
		}

		private void ReadFile()
		{
			string filePath = string.Empty;
			string fileContent = string.Empty;
			int trianglesCount = 0;
			int rowCount = 0;

			try
			{
				using ( StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default) )
				{
					string line;
					trianglesCount = rowCount = Int32.Parse(sr.ReadLine());
					while((line = sr.ReadLine()) != null && rowCount > 0)
					{
						line.Split()
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
