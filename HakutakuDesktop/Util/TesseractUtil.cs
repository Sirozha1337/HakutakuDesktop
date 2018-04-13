using System;
using System.Collections.Generic;
using Tesseract;

namespace HakutakuDesktop.Util
{
	public static class TesseractUtil
	{
		public static TextOverlay[] ProccessPage(Page page)
		{
			Logger.WriteLog("Start page processing");
			List<TextOverlay> textOverlays = new List<TextOverlay>();
			try
			{
				using (var iter = page.GetIterator())
				{
					do
					{
						string text = iter.GetText(PageIteratorLevel.TextLine);
						if (!string.IsNullOrEmpty(text))
						{
							string translatedText = text;
							Rect rect;
							if (iter.TryGetBoundingBox(PageIteratorLevel.TextLine, out rect))
							{
								textOverlays.Add(new TextOverlay
								{
									x = rect.X1 / 2,
									y = rect.Y1 / 2,
									ySize = Math.Max(Math.Abs(rect.Y1 - rect.Y2) / 2, 1),
									Text = translatedText
								});
							}
							Console.WriteLine(translatedText);
						}
					} while (iter.Next(PageIteratorLevel.TextLine));
				}
			}
			catch (Exception ex)
			{
				Logger.WriteLog("Error processing page: " + ex.Message);
			}
			Logger.WriteLog("Finish page processing");

			return textOverlays.ToArray();
		}
	}
}
