using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Ajax.Utilities;

namespace BibleTree.Services {
	public class ScriptService {

		public static Dictionary<string, string> Scripts { get; private set; }

		public static void Init() {
			Scripts = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\Services\SQL\", "*.sql")
				.ToDictionary(f => Path.GetFileNameWithoutExtension(f).ToLower(), File.ReadAllText, StringComparer.OrdinalIgnoreCase);
		}
	}
}