using System.Drawing;
using System.Drawing.Text;

namespace HakutakuDesktop.Util
{
	public static class FontUtil
	{
		private static PrivateFontCollection pfc;

		public static void InitCustomFonts()
		{
			//Create your private font collection object.
			pfc = new PrivateFontCollection();
			pfc.AddFontFile("./Fonts/OpenSans-ExtraBoldItalic.ttf");
			pfc.AddFontFile("./Fonts/OpenSans-Regular_0.ttf");
		}

		public static Font GetExtrabold(float size)
		{
			try
			{
				if (pfc == null)
					InitCustomFonts();
				return new Font(pfc.Families[1], size);
			}
			catch
			{
				return new Font("Arial", size);
			}
		}

		public static Font GetRegular(float size)
		{
			try
			{
				if (pfc == null)
					InitCustomFonts();
				return new Font(pfc.Families[0], size);
			}
			catch
			{
				return new Font("Arial", size);
			}
		}
	}
}
