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
		public int NestingDegree { get; set; } = 1;
		public PointF[] Tops { get; set; }
		public bool IsIntersected = false;

		public bool IsContainsTriangle( Triangle triangle )
		{
			if ( this.IsContainsPoint(triangle.Tops[0])
				&& this.IsContainsPoint(triangle.Tops[1])
				&& this.IsContainsPoint(triangle.Tops[2]) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool IsContainsPoint( PointF point )
		{
			IsIntersected = false;
			float a = ( this.Tops[0].X - point.X ) * ( this.Tops[1].Y - this.Tops[0].Y ) 
				- ( this.Tops[1].X - this.Tops[0].X ) * ( this.Tops[0].Y - point.Y );
			float b = ( this.Tops[1].X - point.X ) * ( this.Tops[2].Y - this.Tops[1].Y ) 
				- ( this.Tops[2].X - this.Tops[1].X ) * ( this.Tops[1].Y - point.Y );
			float c = ( this.Tops[2].X - point.X ) * ( this.Tops[0].Y - this.Tops[2].Y ) 
				- ( this.Tops[0].X - this.Tops[2].X ) * ( this.Tops[2].Y - point.Y );

			if ( a == 0 || b == 0 || c == 0 )
			{
				IsIntersected = true;
			}

			if ( ( a >= 0 && b >= 0 && c >= 0 ) || ( a <= 0 && b <= 0 && c <= 0 ) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Draw( PaintEventArgs e, PropertyStorage property )
		{
			//	отрисовка с помощью массива вершин
			if ( Tops?.Count() > 0 )
			{
				Color brushColor = Color.FromArgb(
					property.baseColor.R - property.Rcomp * NestingDegree,
					property.baseColor.G - property.Gcomp * NestingDegree,
					property.baseColor.B - property.Bcomp * NestingDegree);

				Pen pen = new Pen(Color.Black, 3F);
				Brush brush = new SolidBrush(brushColor);

				e.Graphics.DrawPolygon(pen, Tops);
				e.Graphics.FillPolygon(brush, Tops);
			}
		}

		public PointF Top( float x, float y )
		{
			return new PointF(x, y);
		}

		public Triangle( PointF A, PointF B, PointF C )
		{
			Tops = new PointF[] { A, B, C };
		}

		public Triangle( float x1, float y1, float x2, float y2, float x3, float y3 )
		{
			Tops = new PointF[]
				{
					new PointF(x1, y1),
					new PointF(x2, y2),
					new PointF(x3, y3)
				};
		}

		public Triangle( string row )
		{
			string pattern = @"\s+";
			string[] coords = Regex.Split(row, pattern);

			try
			{
				Tops = new PointF[]
				{
					new PointF(float.Parse(coords[0]), float.Parse(coords[1])),
					new PointF(float.Parse(coords[2]), float.Parse(coords[3])),
					new PointF(float.Parse(coords[4]), float.Parse(coords[5]))
				};
				foreach ( var item in Tops )
				{
					if ( item.X > 1000 || item.X < 0 || item.Y > 1000 || item.Y < 0 )
						throw new Exception();
				}
			}
			catch
			{
				MessageBox.Show($"Не правильный формат входных данных.\nОшибка в следующей строке:\n{row}", caption: "Ошибка чтения");
			}
		}
	}
}
