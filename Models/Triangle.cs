using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrianglesWinForm.Models
{
	public class Triangle
	{
		public int Color { get; }
		public int NestingDegree { get; set; } = 0;


		public Point[] Tops { get; set; }
		//public Point TopA { get; set; }
		//public Point TopB { get; set; }
		//public Point TopC { get; set; }


		//public async void DrawAsync( PaintEventArgs e )
		//{
		//	Pen pen = new Pen(Color.Black, 2);

		//	await Task.Run(() => e.Graphics.DrawLine(pen, TopA, TopB));
		//	await Task.Run(() => e.Graphics.DrawLine(pen, TopB, TopC));
		//	await Task.Run(() => e.Graphics.DrawLine(pen, TopA, TopC));
		//}

		public bool AreIntersected( Triangle triangle )
		{
			if (   this.ArePointIntersected(triangle.Tops[0])
				&& this.ArePointIntersected(triangle.Tops[1])
				&& this.ArePointIntersected(triangle.Tops[2]) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool ArePointIntersected( Point point )
		{
			int a = ( this.Tops[0].X - point.X ) * ( this.Tops[1].Y - this.Tops[0].Y ) - ( this.Tops[1].X - this.Tops[0].X ) * ( this.Tops[0].Y - point.Y );
			int b = ( this.Tops[1].X - point.X ) * ( this.Tops[2].Y - this.Tops[1].Y ) - ( this.Tops[2].X - this.Tops[1].X ) * ( this.Tops[1].Y - point.Y );
			int c = ( this.Tops[2].X - point.X ) * ( this.Tops[0].Y - this.Tops[2].Y ) - ( this.Tops[0].X - this.Tops[2].X ) * ( this.Tops[2].Y - point.Y );

			if ( ( a >= 0 && b >= 0 && c >= 0 ) || ( a <= 0 && b <= 0 && c <= 0 ) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Draw( PaintEventArgs e )
		{
			//	отрисовка с помощью массива вершин
			if ( Tops?.Count() > 0 )
			{
				Pen pen = Pens.Black;
				Brush brush = Brushes.LightGreen;
				e.Graphics.DrawPolygon(pen, Tops);
				e.Graphics.FillPolygon(brush, Tops);
			}

			//	отрисовка с помощью отдельных вершин
			//e.Graphics.DrawPolygon(pen, new Point[] { TopA, TopB, TopC });
			//e.Graphics.FillPolygon(brush, new Point[] { TopA, TopB, TopC });

		}

		public Point Top( int x, int y )
		{
			return new Point(x, y);
		}

		public Triangle( Point A, Point B, Point C )
		{
			// по вершинам
			//TopA = A;
			//TopB = B;
			//TopC = C;

			//	массивом
			Tops = new Point[] { A, B, C };
		}

		public Triangle( int x1, int y1, int x2, int y2, int x3, int y3 )
		{
			// по вершинам
			//TopA = new Point(x1, y1);
			//TopB = new Point(x2, y2);
			//TopC = new Point(x3, y3);

			//	массивом
			Tops = new Point[]
				{
					new Point(x1, y1),
					new Point(x2, y2),
					new Point(x3, y3)
				};
		}

		public Triangle( string row )
		{
			string pattern = @"\s+";
			string[] coords = Regex.Split(row, pattern);

			try
			{
				//	по вершинам
				//TopA = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
				//TopB = new Point(int.Parse(coords[2]), int.Parse(coords[3]));
				//TopC = new Point(int.Parse(coords[4]), int.Parse(coords[5]));

				// массивом
				Tops = new Point[]
				{
					new Point(int.Parse(coords[0]), int.Parse(coords[1])),
					new Point(int.Parse(coords[2]), int.Parse(coords[3])),
					new Point(int.Parse(coords[4]), int.Parse(coords[5]))
				};
			}
			catch ( Exception ex )
			{
				MessageBox.Show($"Одна или несколько координат вершин треугольника считана не верно\nОшибка в следующей строке:\n{row}", caption: "Ошибка чтения");
			}
		}
	}
}
