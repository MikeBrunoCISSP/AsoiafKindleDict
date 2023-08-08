namespace AsoiafKindleDict.WebContract;
public class CopyrightDto {
    public string Owner { get; set; }

    public string ToHtml() => $"<html>\r\n  <head>\r\n    <meta content=\"text/html\" http-equiv=\"content-type\">\r\n  </head>\r\n  <body>\r\n    <h3>Copyright {DateTime.Now:yyyy} {Owner}</h3>\r\n  </body>\r\n</html>";
}
