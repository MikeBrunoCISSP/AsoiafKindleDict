using System.Text;

namespace AsoiafKindleDict.Api.Dto;
public class InflectionGroupDto {
    public InflectionGroupDto() { }
    public InflectionGroupDto(string name) {
        Name = name;
    }
    public string Name { get; set; }
    public HashSet<InflectionDto> Entries { get; set; } = new();

    public override bool Equals(object obj) {
        return !ReferenceEquals(null, obj) && ReferenceEquals(this, obj) ||
               (obj is InflectionGroupDto other && equals(other));
    }

    public override int GetHashCode() {
        return StringComparer.InvariantCultureIgnoreCase.GetHashCode(Name);
    }

    public string ToHtml() {
        var builder = new StringBuilder($"<idx:infl inflgrp=\"{Name}\">\r\n");
        foreach (var entry in Entries) {
            builder.AppendLine(entry.ToHtml());
        }

        builder.AppendLine("</idx:infl>");

        return builder.ToString();
    }

    protected bool equals(InflectionGroupDto other) {
        return Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }
}
