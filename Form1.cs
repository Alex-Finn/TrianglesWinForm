using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrianglesWinForm.Models;

namespace TrianglesWinForm
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// Коллекция треугольников для отображения
		/// </summary>
		private List<Triangle> triangles;
		/// <summary>
		/// Значение, показывающее следует ли отрисовывать изображение
		/// </summary>
		private bool doPaint;
		/// <summary>
		/// Объект, хранящий общие данные проекта
		/// </summary>
		private PropertyStorage store;

		public Form1()
		{
			InitializeComponent();
			doPaint = false;
			triangles = new List<Triangle>();
			store = new PropertyStorage();

			pb_colorPicker.BackColor = store.baseColor;
			pb_pictureBox.BackColor = store.baseColor;
		}

		/// <summary>
		/// Метод, получающий данные для отрисовки треугольников и подсчёта количества оттенков
		/// </summary>
		/// <returns></returns>
		private bool ReadData()
		{
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

					try
					{
						//	проверка вхождения треугольников друг в друга
						if ( triangles[j].IsContainsTriangle(triangles[i]) )
						{
							triangles[i].NestingDegree++;
						}
					}
					catch
					{
						tb_result.Text = "ERROR";
						doPaint = false;
						pb_pictureBox.Invalidate();
						return false;
					}
				}
			}
			triangles.Sort(( a, b ) => a.NestingDegree.CompareTo(b.NestingDegree));
			store.maxNestingDegree = triangles.Max(el => el.NestingDegree);
			return true;
		}

		/// <summary>
		/// Обработка события нажатия кнопки "Read"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_read_Click( object sender, EventArgs e )
		{
			tb_result.Text = "Loading...";
			btn_read.Enabled = false;
			btn_clear.Enabled = false;

			if ( !ReadData() )	//	если данные считаны с ошибками, либо если присутствуют пересекающиеся треугольники
			{
				return;
			}

			doPaint = true;
			pb_pictureBox.Invalidate();
			tb_result.Text = ( store.maxNestingDegree + 1 ).ToString();
			btn_read.Enabled = true;
			btn_clear.Enabled = true;
		}		

		/// <summary>
		/// Метод отрисовки изображения на элементе "PictureBox"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
			btn_read.Enabled = true;
			btn_clear.Enabled = true;
		}

		/// <summary>
		/// Метод, запускающий отрисовку треугольников коллекции
		/// </summary>
		/// <param name="e"></param>
		private void DrawTriangles( PaintEventArgs e )
		{
			foreach ( var triangle in triangles )
			{
				triangle.Draw(e, store);
			}
		}

		/// <summary>
		/// Обработка события нажатия на кнопку "Clear"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Btn_clear_Click( object sender, EventArgs e )
		{
			doPaint = false;
			tb_result.Text = string.Empty;
			pb_pictureBox.Invalidate();
		}

		/// <summary>
		/// Метод работы с входным файлом, заполняющий коллекцию треугольников
		/// </summary>
		/// <returns></returns>
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
						tb_result.Text = string.Empty;
						btn_read.Enabled = true;
						btn_clear.Enabled = true;
						return false;
					}
				}
			}
			catch
			{
				MessageBox.Show($"При чтении файла возникла ошибка\nВозможно выбран файл некорректного формата", "Ошибка чтения");
				tb_result.Text = string.Empty;
				btn_read.Enabled = true;
				btn_clear.Enabled = true;
				return false;
			}

			return true;
		}

		/// <summary>
		/// Метод, позволяющий выбрать базовый цвет для окрашивания треугольников
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pb_colorPicker_Click( object sender, EventArgs e )
		{
			ColorDialog cDialog = new ColorDialog
			{
				AnyColor = true
			};
			if ( cDialog.ShowDialog() == DialogResult.OK )
			{
				store.baseColor = cDialog.Color;
			}
			else
			{
				return;
			}

			pb_colorPicker.BackColor = store.baseColor;
			pb_pictureBox.BackColor = store.baseColor;
		}
	}
}
