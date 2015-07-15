﻿namespace Raven.Documentation.Parser.Data
{
	using System.Collections.Generic;
	using System.Security.Cryptography;
	using System.Text;

	public class DocumentationPage
    {
		public DocumentationPage()
		{
			this.Images = new HashSet<DocumentationImage>();
		}

        public string Version { get; set; }

	    public string HtmlContent { get; set; }

	    public string TextContent { get; set; }

	    public string Title { get; set; }

		public string Key { get; set; }

	    public string Id { get; set; }

		public string LastCommitSha { get; set; }

		public string RelativePath { get; set; }

		public Language Language { get; set; }

	    public Category Category { get; set; }

		public HashSet<DocumentationImage> Images { get; set; }

		public string GetUniqueKey()
		{
			var str = string.Concat(this.Version, this.Language.ToString().ToLowerInvariant(), this.Key);
			var bytes = Encoding.UTF8.GetBytes(str);
			return System.Convert.ToBase64String(bytes);
		}
    }
}