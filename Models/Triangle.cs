using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TrianglesWinForm.Models
{
	public class Triangle
	{
		public Point TopA { get; set; }
		public Point TopB { get; set; }
		public Point TopC { get; set; }


		public async void DrawAsync( PaintEventArgs e )
		{
			Pen pen = new Pen(Color.Black, 2);

			await Task.Run(() => e.Graphics.DrawLine(pen, TopA, TopB));
			await Task.Run(() => e.Graphics.DrawLine(pen, TopB, TopC));
			await Task.Run(() => e.Graphics.DrawLine(pen, TopA, TopC));
		}

		public void Draw( PaintEventArgs e )
		{
			Pen pen = new Pen(Color.Black, 2);

			e.Graphics.DrawLine(pen, TopA, TopB);
			e.Graphics.DrawLine(pen, TopB, TopC);
			e.Graphics.DrawLine(pen, TopA, TopC);
		}

		public Point Top(int x, int y )
		{
			return new Point(x, y);
		}

		public Triangle(Point A, Point B, Point C)
		{
			TopA = A;
			TopB = B;
			TopC = C;
		}
		public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			TopA = new Point(x1, y1);
			TopB = new Point(x2, y2);
			TopC = new Point(x3, y3);
		}

		public Triangle(string row)
		{
			string pattern = @"\s+";
			//string[] coords = row.Split(new char[] { ' ' } , StringSplitOptions.RemoveEmptyEntries);
			string[] coords = Regex.Split(row, pattern);

			TopA = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
			TopB = new Point(int.Parse(coords[2]), int.Parse(coords[3]));
			TopC = new Point(int.Parse(coords[4]), int.Parse(coords[5]));
		}
	}
}
