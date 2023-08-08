using System.Text;

namespace AsoiafKindleDict.Api.Dto;
public class IndexDto {
    public IndexDto() { }

    public IndexDto(string name) {
        Name = name;
    }
    public String Name { get; set; }
    public Dictionary<string, WordDefinitionDto> WordDefinitions { get; set; } = new(StringComparer.InvariantCultureIgnoreCase);

    public void AddWord(string word, string definition) {
        if (WordDefinitions.ContainsKey(word)) {
            throw new ArgumentException($"'{word}': word already exists in index '{Name}'");
        }

        WordDefinitions.Add(word, new WordDefinitionDto(word, definition));
    }

    public string ToHtml() {
        var builder = new StringBuilder();
        foreach (var wordDefinition in WordDefinitions) {
            builder.AppendLine(wordDefinition.Value.ToHtml(Name));
        }
        return File.ReadAllText(@"Templates\contentTemplate.html").Replace("[WORDS]", builder.ToString());
    }
}
