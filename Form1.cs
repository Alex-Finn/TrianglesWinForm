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

namespace TrianglesWinForm
{
	public partial class Form1 : Form
	{
		private List<Triangle> triangles;
		private bool doPaint;

		private PropertyStorage prop;

		public Form1()
		{
			InitializeComponent();
			doPaint = false;
			triangles = new List<Triangle>();
			prop = new PropertyStorage();

			pb_colorPicker.BackColor = prop.baseColor;
			
			pb_pictureBox.BackColor = prop.baseColor;
		}

		private bool ReadData()
		{
			//	points.Add(new Point(100, 100));
			//	points.Add(new Point(200, 200));

			if ( !ReadFile() )
			{
				return false;
			}
			for ( int i = 0 ; i < triangles.Count ; i++ )
			{
				for ( int j = 0 ; j < triangles.Count ; j++ )
				{
					if ( i == j )
					{
						continue;
					}

					if ( triangles[j].AreIntersected(triangles[i]) )
					{
						triangles[i].NestingDegree++;
					}
				}
			}
			triangles.Sort(( a, b ) => a.NestingDegree.CompareTo(b.NestingDegree));
			prop.maxNestingDegree = triangles.Max(el => el.NestingDegree);
			return true;
		}

		private void Btn_read_Click( object sender, EventArgs e )
		{
			if ( !ReadData() )
			{
				return;
			}

			doPaint = true;
			DoPaintOnPictureBox();
		}

		private void DoPaintOnPictureBox()
		{
			pb_pictureBox.Refresh();
			//pb_pictureBox.Invalidate();
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
				triangle.Draw(e, prop);
			}
		}

		private void Btn_clear_Click( object sender, EventArgs e )
		{
			doPaint = false;
			DoPaintOnPictureBox();
		}

		private bool ReadFile()
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
					else
					{
						return false;
					}
				}
			}
			catch
			{
				MessageBox.Show($"При чтении файла возникла ошибка\nВозможно выбран файл некорректного формата", "Ошибка чтения");
				return false;
			}
			return true;
		}

		private void pb_pictureBox_DoubleClick( object sender, EventArgs e )
		{
			doPaint = true;
			ReadData();
			DoPaintOnPictureBox();
		}

		private void pb_colorPicker_Click( object sender, EventArgs e )
		{
			ColorDialog cDialog = new ColorDialog();
			cDialog.AnyColor = true;
			if ( cDialog.ShowDialog() == DialogResult.OK )
			{
				prop.baseColor = cDialog.Color;
			}
			else
				return;
			pb_colorPicker.BackColor = prop.baseColor;
			pb_pictureBox.BackColor = prop.baseColor;
		}
	}
}
