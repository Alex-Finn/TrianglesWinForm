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
	/// <summary>
	/// Класс треугольника, содержащий все необходимые методы и свойства
	/// </summary>
	public class Triangle
	{
		/// <summary>
		/// Глубина вложенности треугольника (влияет на цвет окраски)
		/// </summary>
		public int NestingDegree { get; set; } = 1;
		/// <summary>
		/// Массив вершин треугольника с координатами в формате числа с плавающей запятой
		/// </summary>
		public PointF[] Tops { get; set; }
		/// <summary>
		/// Указывает пересекается ли треугольник с другим
		/// </summary>
		public bool IsIntersected = false;

		/// <summary>
		/// Метод определения вхождения одного треугольника в другой
		/// </summary>
		/// <param name="triangle">Треугольник, который исследуется на вложенность</param>
		/// <returns>Булево значение, показывающее содержит ли данный треугольник все три вершины другого треугольника</returns>
		public bool IsContainsTriangle( Triangle triangle )
		{
			bool condition1 = this.IsContainsPoint(triangle.Tops[0]);
			bool condition2 = this.IsContainsPoint(triangle.Tops[1]);
			bool condition3 = this.IsContainsPoint(triangle.Tops[2]);

			if (	( condition1	&& condition2	&& !condition3	)
				||	( condition1	&& !condition2	&& condition3	)
				||	( !condition1	&& condition2	&& condition3	)
				||	( !condition1	&& !condition2	&& condition3	)
				||	( !condition1	&& condition2	&& !condition3	) 
				||	( condition1	&& !condition2	&& !condition3	) )
			{
				//	используется теория, при которой второй треугольник выходит за пределы первого,
				//	если только одна или только две вершины второго треугольника из трёх находятся
				//	внутри первого
				IsIntersected = true;
				throw new Exception();
			}

			if ( condition1 && condition2 && condition3 )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Метод определения принадлежности точки треугольнику. Используется метод векторного произведения
		/// </summary>
		/// <param name="point">Исследуемая точка с координатами в формате float</param>
		/// <returns>Признак принадлежности точки треугольнику</returns>
		private bool IsContainsPoint( PointF point )
		{
			float a = ( this.Tops[2].X - point.X ) * ( this.Tops[1].Y - this.Tops[2].Y )
				- ( this.Tops[1].X - this.Tops[2].X ) * ( this.Tops[2].Y - point.Y );

			float b = ( this.Tops[1].X - point.X ) * ( this.Tops[0].Y - this.Tops[1].Y )
				- ( this.Tops[0].X - this.Tops[1].X ) * ( this.Tops[1].Y - point.Y );

			float c = ( this.Tops[0].X - point.X ) * ( this.Tops[2].Y - this.Tops[0].Y )
				- ( this.Tops[2].X - this.Tops[0].X ) * ( this.Tops[0].Y - point.Y );

			if ( ( a >= 0 && b >= 0 && c >= 0 ) || ( a <= 0 && b <= 0 && c <= 0 ) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		/// <summary>
		/// Метод отрисовки треугольника соответствующим цветом
		/// </summary>
		/// <param name="e"></param>
		/// <param name="property">Объект, содержащий общие свойства проекта</param>
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

		/// <summary>
		/// Конструктор треугольника по трём вершинам с координатами в формате float
		/// </summary>
		/// <param name="A">Вершина А</param>
		/// <param name="B">Вершина В</param>
		/// <param name="C">Вершина С</param>
		public Triangle( PointF A, PointF B, PointF C )
		{
			Tops = new PointF[] { A, B, C };
		}

		/// <summary>
		/// Конструктор треугольника по координатам в формате float
		/// </summary>
		/// <param name="x1">Координата X первой вершины</param>
		/// <param name="y1">Координата Y первой вершины</param>
		/// <param name="x2">Координата X второй вершины</param>
		/// <param name="y2">Координата Y второй вершины</param>
		/// <param name="x3">Координата X третьей вершины</param>
		/// <param name="y3">Координата Y третьей вершины</param>
		public Triangle( float x1, float y1, float x2, float y2, float x3, float y3 )
		{
			Tops = new PointF[]
				{
					new PointF(x1, y1),
					new PointF(x2, y2),
					new PointF(x3, y3)
				};
		}

		/// <summary>
		/// Конструктор треугольника, принимающий координаты вершин треугольника в формате строки "х1 у1 х2 у2 х3 у3"
		/// </summary>
		/// <param name="row">Строка, в которой ожидаются координаты вершин треугольника</param>
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
					{
						throw new Exception();
					}
				}
			}
			catch
			{
				MessageBox.Show($"Не правильный формат входных данных.\nОшибка в следующей строке:\n{row}", caption: "Ошибка чтения");
			}
		}
	}
}
