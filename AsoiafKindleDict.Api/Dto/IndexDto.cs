using System.Text;

namespace AsoiafKindleDict.Api.Dto;
public class IndexDto {
    public IndexDto() { }

    public IndexDto(string name) {
        Name = name;
    }
    public String Name { get; set; }
    public HashSet<WordDefinitionDto> WordDefinitions { get; set; } = new();

    public void AddWord(string word, string definition) {
        WordDefinitions.Add(new WordDefinitionDto(word, definition));
    }

    public string ToHtml() {
        var builder = new StringBuilder();
        foreach (var wordDefinition in WordDefinitions) {
            builder.AppendLine(wordDefinition.ToHtml(Name));
        }
        return File.ReadAllText(@"Templates\contentTemplate.html").Replace("[WORDS]", builder.ToString());
    }
    public override bool Equals(object? obj) {
        return !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || (obj is IndexDto other && equals(other)));
    }
    public override int GetHashCode() {
        return StringComparer.InvariantCultureIgnoreCase.GetHashCode(Name);
    }

    protected bool equals(IndexDto other) {
        return Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }
}
