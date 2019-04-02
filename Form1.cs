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
		private List<Triangle> triangles;
		private List<Point> points;
		private bool doPaint;

		public Form1()
		{
			InitializeComponent();
			doPaint = false;
			triangles = new List<Triangle>();
			points = new List<Point>();
			
			pb_pictureBox.BackColor = Color.GhostWhite;
		}

		private void ReadData()
		{
			//	points.Add(new Point(100, 100));
			//	points.Add(new Point(200, 200));

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
				DrawTriangles(e);
			}
			else
			{
				e.Graphics.Clear(pb_pictureBox.BackColor);
				triangles.Clear();
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
			try
			{
				using ( OpenFileDialog openFileDialog = new OpenFileDialog() )
				{
					openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
					openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
					openFileDialog.FilterIndex = 1;
					openFileDialog.RestoreDirectory = true;

					if ( openFileDialog.ShowDialog() == DialogResult.OK )
					{
						//Read the contents of the file into a stream
						var fileStream = openFileDialog.OpenFile();

						using ( StreamReader sr = new StreamReader(fileStream) )
						{
							triangles.Clear();
							string line;
							int rowCount = Int32.Parse(sr.ReadLine());

							while ( ( line = sr.ReadLine() ) != null && rowCount > 0 )
							{
								triangles.Add(new Triangle(line));
								rowCount--;
							}
						}
					}
				}
			}
			catch ( Exception ex )
			{			
				MessageBox.Show($"При чтении файла возникла ошибка\nВозможно выбран файл некорректного формата", "Ошибка чтения");
			}
		}
	}
}
