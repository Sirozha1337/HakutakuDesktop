using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakutakuDesktop.Util
{
	public static class FontUtil
	{
		private static PrivateFontCollection pfc;

		public static void InitCustomFonts()
		{
			//Create your private font collection object.
			pfc = new PrivateFontCollection();
			pfc.AddFontFile("Fonts/OpenSans-ExtraBoldItalic.ttf");
			pfc.AddFontFile("Fonts/OpenSans-Regular_0.ttf");
		}

		public static Font GetExtrabold(float size)
		{
			return new Font(pfc.Families[1], size);
		}

		public static Font GetRegular(float size)
		{
			return new Font(pfc.Families[0], size);
		}
	}
}
