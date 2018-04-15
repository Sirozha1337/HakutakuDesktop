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

		public static string Execute(int x, int y, int width, int height, string srcLang, string dstLang)
		{
			Logger.WriteLog("Start text recognition");
			string translatedText = "";
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
						using (var page = GetEngine(srcLang).Process(img))
						{
							string text = page.GetText();
							Logger.WriteLog("Recognized text: " + text);
							translatedText = TranslationUtil.Translate(text, srcLang, dstLang);
							Logger.WriteLog("Translated text: " + translatedText);
						}
					}
				}
				_engineBusy = false;
				Logger.WriteLog("Finish text recognition");
			}
			return translatedText;
		}
	}
}
