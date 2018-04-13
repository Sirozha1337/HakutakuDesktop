using System;
using System.Collections.Generic;
using Tesseract;

namespace HakutakuDesktop.Util
{
	public static class RecognitionUtil
	{
		private static TesseractEngine _engine;
		private static string _engine_lang;
		public static bool _engineBusy = false;

		private static TesseractEngine GetEngine(string language)
		{
			if(_engine != null)
			{
				if (_engine_lang == language)
					return _engine;
				else
					_engine.Dispose();
			}
			_engine = new TesseractEngine(@"./tessdata", language, EngineMode.Default);
			_engine_lang = language;
			return _engine;
		}

		public static TextOverlay[] Execute(int x, int y, int width, int height, string srcLang, string dstLang)
		{
			Logger.WriteLog("Start text recognition");
			TextOverlay[] textOverlays = null;
			if (!_engineBusy)
			{
				_engineBusy = true;
				if (width - 1 > 0 && height - 1 > 0)
				{
					var sc = ImageUtil.GetScreenCapture(x, y, width, height);
					if(sc.Width < 500 || sc.Height < 500)
					{
						sc = ImageUtil.MagnifyBitmap(sc, 2);
					}

					using (var img = PixConverter.ToPix(sc))
					{
						using (var page = GetEngine("eng").Process(img))
						{
							textOverlays = ProccessPage(page, srcLang, dstLang, 2);
						}
					}
				}
				_engineBusy = false;
				Logger.WriteLog("Finish text recognition");
			}
			return textOverlays;
		}

		private static TextOverlay[] ProccessPage(Page page, string srcLang, string dstLang, int scaleFactor)
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
							string translatedText = TranslationUtil.Translate(text, srcLang, dstLang);
							//string translatedText = text;
							Rect rect;
							if (iter.TryGetBoundingBox(PageIteratorLevel.TextLine, out rect))
							{
								textOverlays.Add(new TextOverlay
								{
									x = rect.X1 / scaleFactor,
									y = rect.Y1 / scaleFactor,
									ySize = Math.Max(Math.Abs(rect.Y1 - rect.Y2) / scaleFactor, 1),
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
