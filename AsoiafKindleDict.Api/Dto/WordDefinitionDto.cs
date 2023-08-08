using System.Text;

namespace AsoiafKindleDict.Api.Dto;
public class WordDefinitionDto {
    public WordDefinitionDto() { }
    public WordDefinitionDto(string word, string definition) {
        Word = word;
        Definition = definition;
    }
    public string Word { get; set; }
    public string Definition { get; set; }
    public HashSet<InflectionGroupDto> InflectionGroups { get; set; } = new();

    public override bool Equals(object obj) {
        return !ReferenceEquals(null, obj) && ReferenceEquals(this, obj) ||
               (obj is WordDefinitionDto other && equals(other));
    }

    public override int GetHashCode() {
        return Word.ToUpper().GetHashCode();
    }

    public string ToHtml(string indexName) {
        var builder = new StringBuilder($"<idx:entry name=\"{indexName}\" scriptable=\"yes\" spell=\"yes\">\r\n");
        if (!InflectionGroups.Any()) {
            builder.AppendLine($"<h5><dt><idx:orth>{Word}</idx:orth></dt></h5>");
        } else {
            builder.AppendLine($"<h5><dt><idx:orth>{Word}");
            foreach (var inflectionGroup in InflectionGroups) {
                builder.AppendLine(inflectionGroup.ToHtml());
            }
            builder.AppendLine("</idx:orth></dt></h5>");
        }

        builder.AppendLine($"<dd>{Definition}</dd>");
        builder.AppendLine("</idx:entry>");

        return builder.ToString();
    }

    protected bool equals(WordDefinitionDto other) {
        return Word.Equals(other.Word, StringComparison.InvariantCultureIgnoreCase);
    }
}
