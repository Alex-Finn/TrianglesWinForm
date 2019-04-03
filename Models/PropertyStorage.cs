using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesWinForm.Models
{
	public class PropertyStorage
	{
		public Color baseColor { get; set; }
		public int maxNestingDegree { get; set; }
		private const int koef = 50;

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
