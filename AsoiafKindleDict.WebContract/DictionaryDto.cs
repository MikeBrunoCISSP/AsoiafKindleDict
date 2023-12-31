﻿using System.Text;

namespace AsoiafKindleDict.WebContract;
public class DictionaryDto {
    public DictionaryDto() { }

    public DictionaryDto(String title, String owner, String author = "") {
        CopyRight = new CopyrightDto {
            Owner = owner
        };
        CoverPage = new CoverPageDto {
            Title = title,
            Author = String.IsNullOrEmpty(author) ? owner : author
        };
    }
    public CopyrightDto CopyRight { get; set; } = new();
    public CoverPageDto CoverPage { get; set; } = new();
    public Dictionary<string, IndexDto> Indexes { get; set; } = new(StringComparer.InvariantCultureIgnoreCase);

    public void AddWord(string word, string definition, string indexName) {
        if (!Indexes.ContainsKey(indexName)) {
            Indexes.Add(indexName, new IndexDto(indexName));
        }

        Indexes[indexName].AddWord(word, definition);
    }
    public void CreateArtifacts(string outputDirectory) {
        if (string.IsNullOrEmpty(outputDirectory)) {
            throw new ArgumentNullException(nameof(outputDirectory));
        }

        if (!Directory.Exists(outputDirectory)) {
            throw new DirectoryNotFoundException($"'{outputDirectory}': Directory does not exist.");
        }

        string payloadFolder = Path.Combine(outputDirectory, $"AsoiafDictionary_{DateTime.Now:dd-MMM-yyyy_hhmmss}");
        Directory.CreateDirectory(payloadFolder);
        File.WriteAllText(Path.Combine(payloadFolder, "cover.html"), CoverPage.ToHtml());
        File.WriteAllText(Path.Combine(payloadFolder, "copyright.html"), CopyRight.ToHtml());

        var referenceBuilder = new StringBuilder();
        var contentBuilder = new StringBuilder();
        var spineBuilder = new StringBuilder();
        foreach (var index in Indexes.Values) {
            referenceBuilder.AppendLine($"        <reference type=\"index\" title=\"{index.Name}\" href=\"{index.Name}.html\"/>");
            contentBuilder.AppendLine($"        <item id=\"{index.Name}\"\r\n                  href=\"{index.Name}.html\"\r\n                  media-type=\"application/xhtml+xml\" />");
            spineBuilder.AppendLine($"		<itemref idref=\"{index.Name}\"/>");
            string indexContents = File.ReadAllText(@"Templates\contentTemplate.html").Replace("[WORDS]", index.ToHtml());
            File.WriteAllText(Path.Combine(payloadFolder, $"{index.Name}.html"), indexContents);
        }

        string opfContents = File.ReadAllText(@"Templates\opfTemplate.xml")
            .Replace("[REFERENCE]", referenceBuilder.ToString())
            .Replace("[CONTENT]", contentBuilder.ToString())
            .Replace("[SPINE]", spineBuilder.ToString());
        File.WriteAllText(Path.Combine(payloadFolder, "dict.opf"), opfContents);
    }
}
