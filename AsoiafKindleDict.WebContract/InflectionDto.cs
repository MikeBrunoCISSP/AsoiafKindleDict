using System.Text;

namespace AsoiafKindleDict.WebContract;
public class InflectionDto {
    public InflectionDto() { }
    public InflectionDto(string name, string value, bool isExactMatch = false) {
        Name = name;
        Value = value;
        IsExactMatch = isExactMatch;
    }
    /// <summary>
    /// The name of the inflection entry.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The inflection value.
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// By default, the Kindle device uses a fuzzy algorithm for matching diacritics during word lookup.
    /// Languages that use contrastive diacritics to distinguish between distinct word forms should use the exact="yes" attribute in the <idx:iform /> tag to force exact match of diacritics during lookup.
    /// </summary>
    public Boolean IsExactMatch { get; set; }

    public string ToHtml() {
        var builder = new StringBuilder("<idx:iform ");
        if (!String.IsNullOrEmpty(Name)) {
            builder.Append($"name=\"{Name}\" ");
        }
        builder.Append($"value=\"{Value}\" ");
        if (IsExactMatch) {
            builder.Append("exact=\"yes\" ");
        }
        builder.Append("/>");

        return builder.ToString();
    }
}
