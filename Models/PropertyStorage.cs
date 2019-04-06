using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesWinForm.Models
{
	/// <summary>
	/// Класс общих данных для проекта
	/// </summary>
	public class PropertyStorage
	{
		/// <summary>
		/// Цвет, выбранный в качестве базового пользователем
		/// </summary>
		public Color baseColor { get; set; }
		/// <summary>
		/// Максимальная глубина вхождения треугольников
		/// </summary>
		public int maxNestingDegree { get; set; }
		/// <summary>
		/// Коэффициент в процентах, отвечающий за разницу между самым светлым и самым тёмным оттенком треугольников
		/// </summary>
		private const int koef = 70;

		/// <summary>
		/// Конструктор объекта, хранящего общие данные проекта
		/// </summary>
		public PropertyStorage()
		{
			baseColor = Color.GhostWhite;
			maxNestingDegree = 1;
		}

		//public int Acomp
		//{
		//	get
		//	{
		//		if ( maxNestingDegree == 1 )
		//			return baseColor.A;
		//		return (( baseColor.A  * koef / 100) / ( maxNestingDegree - 1));

		//	}
		//}
		/// <summary>
		/// Компонента для вычисления красного оттенка для треугольника
		/// </summary>
		public int Rcomp
		{
			get
			{
				if ( maxNestingDegree == 1 )
				{
					return baseColor.R;
				}

				return ( ( baseColor.R * koef / 100 ) / ( maxNestingDegree ) );

			}
		}
		/// <summary>
		/// Компонента для вычисления зелёного оттенка для треугольника
		/// </summary>
		public int Gcomp
		{
			get
			{
				if ( maxNestingDegree == 1 )
				{
					return baseColor.G;
				}

				return ( ( baseColor.G * koef / 100 ) / ( maxNestingDegree ) );

			}
		}
		/// <summary>
		/// Компонента для вычисления синего оттенка для треугольника
		/// </summary>
		public int Bcomp
		{
			get
			{
				if ( maxNestingDegree == 1 )
				{
					return baseColor.B;
				}

				return( ( baseColor.B * koef / 100 ) / ( maxNestingDegree ) );

			}
		}
	}
}
