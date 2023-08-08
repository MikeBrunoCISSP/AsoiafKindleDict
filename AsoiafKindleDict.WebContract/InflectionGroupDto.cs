using System.Text;

namespace AsoiafKindleDict.WebContract;
public class InflectionGroupDto {
    public InflectionGroupDto() { }
    public InflectionGroupDto(string name) {
        Name = name;
    }

    public string Name { get; set; }
    public Dictionary<string, InflectionDto> Entries { get; set; } = new(StringComparer.InvariantCultureIgnoreCase);

    public string ToHtml() {
        var builder = new StringBuilder($"<idx:infl inflgrp=\"{Name}\">\r\n");
        foreach (var entry in Entries.Values) {
            builder.AppendLine(entry.ToHtml());
        }

        builder.AppendLine("</idx:infl>");

        return builder.ToString();
    }
}
