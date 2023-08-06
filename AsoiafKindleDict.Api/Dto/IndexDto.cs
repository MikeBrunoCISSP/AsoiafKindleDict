using System.Text;

namespace AsoiafKindleDict.Api.Dto;
class IndexDto {
    public String Name { get; set; }
    public Dictionary<string, string> Words { get; set; } = new();

    public string ToHtml() {
        var builder = new StringBuilder();
        foreach (var word in Words) {
            builder.AppendLine(GetWordHtml(word));
        }
        return builder.ToString();
    }

    public string? GetWordHtml(string word) {
        return Words.ContainsKey(word)
            ? $"      <idx:entry name=\"{Name}\" scriptable=\"yes\" spell=\"yes\">\r\n          <h5><dt><idx:orth>{word}</idx:orth></dt></h5>\r\n          <dd>{Words[word]}</dd>\r\n      </idx:entry>\r\n      <hr/>"
            : null;
    }

    public string GetWordHtml(KeyValuePair<string, string> word) => $"      <idx:entry name=\"{Name}\" scriptable=\"yes\" spell=\"yes\">\r\n          <h5><dt><idx:orth>{word.Key}</idx:orth></dt></h5>\r\n          <dd>{word.Value}</dd>\r\n      </idx:entry>\r\n      <hr/>";

    public string? GetDefinition(string word) {
        return Words.ContainsKey(word)
            ? Words[word]
            : null;
    }
}
