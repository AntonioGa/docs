﻿namespace Raven.Documentation.Parser
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;

	using Raven.Documentation.Parser.Data;
	using Raven.Documentation.Parser.Helpers;

	internal class DocumentationDirectoryCompiler
	{
		private readonly DocumentCompiler _documentCompiler;

		private readonly ParserOptions _options;


		public DocumentationDirectoryCompiler(DocumentCompiler documentCompiler, ParserOptions options)
		{
			_documentCompiler = documentCompiler;
			_options = options;
		}

		public IEnumerable<DocumentationPage> Compile(DirectoryInfo directoryInfo, DocumentationCompilation.Context compilationContext)
		{
			var directoryName = directoryInfo.Name;
			var documentationVersion = directoryName;

		    var pagesDirectory = _options.GetPathToDocumentationPagesDirectory(documentationVersion);
		    Debug.Assert(Directory.Exists(pagesDirectory));

		    return CompileDocumentationDirectory(pagesDirectory, documentationVersion, compilationContext);
		}

	    private DocumentationPage CompileDocumentationPage(FolderItem page, string directory,
	        string documentationVersion, DocumentationCompilation.Context compilationContext, List<DocumentationMapping> mappings)
	    {
	        var path = Path.Combine(directory,
	            page.Name + FileExtensionHelper.GetLanguageFileExtension(page.Language) +
	            Constants.MarkdownFileExtension);
	        var fileInfo = new FileInfo(path);

	        if (fileInfo.Exists == false)
	            throw new FileNotFoundException(string.Format("Documentaiton file '{0}' not found.", path));

	        var compilationParams = new DocumentationCompilation.Parameters
	        {
	            File = fileInfo,
	            Page = page,
	            DocumentationVersion = documentationVersion,
	            Mappings = mappings
	        };

	        return _documentCompiler.Compile(compilationParams, compilationContext);
	    }

	    private IEnumerable<DocumentationPage> CompileDocumentationDirectory(string directory, string documentationVersion,
	        DocumentationCompilation.Context context, List<DocumentationMapping> mappings = null)
		{
			var docsFilePath = Path.Combine(directory, Constants.DocumentationFileName);
			if (File.Exists(docsFilePath) == false)
				yield break;

			foreach (var item in DocumentationFileHelper.ParseFile(docsFilePath))
			{
				if (item.IsFolder)
				{
					foreach (var page in CompileDocumentationDirectory(Path.Combine(directory, item.Name), documentationVersion, context, item.Mappings))
					{
						yield return page;
					}

					continue;
				}

				foreach (var pageToCompile in GetPages(directory, item))
				{
					yield return CompileDocumentationPage(pageToCompile, directory, documentationVersion, context, pageToCompile.Mappings);
				}
			}

			var indexFilePath = Path.Combine(directory, "index" + Constants.MarkdownFileExtension);
			if (File.Exists(indexFilePath) == false)
				yield break;

			var indexItem = new FolderItem(isFolder: false)
								{
									Description = string.Empty,
									Language = Language.All,
									Name = "index"
								};

		    yield return CompileDocumentationPage(indexItem, directory, documentationVersion,
		        context, mappings ?? new List<DocumentationMapping>());
		}

	    internal static IEnumerable<FolderItem> GetPages(string directory, FolderItem item)
		{
			var path = Path.Combine(directory, item.Name + Constants.MarkdownFileExtension);
			if (File.Exists(path))
			{
				yield return item;
				yield break;
			}

			var languageFileExtensions = FileExtensionHelper.GetLanguageFileExtensions();

			foreach (var language in languageFileExtensions.Keys)
			{
				var extension = languageFileExtensions[language];
				var name = item.Name + extension;
				path = Path.Combine(directory, name + Constants.MarkdownFileExtension);
				if (File.Exists(path))
				{
					yield return new FolderItem(item)
									 {
										 Language = language
									 };
				}
			}
		}
	}
}
