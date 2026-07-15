using ArtistRegistry.Standard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Core.WebScraperLibrary
{
	public class ParseResult
	{
		public string Content { get; set; }
		public int StartIndex { get; set; }
		public int EndIndex { get; set; }

		public ParseResult(string content, int startIndex, int endIndex)
		{
			Content = content.Trim();
			StartIndex = startIndex;
			EndIndex = endIndex;
		}

		public bool HasValue
		{
			get
			{
				if (StartIndex == 0 && EndIndex == 0) return false;
				return true;
			}
		}



	}
}
