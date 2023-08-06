namespace AsoiafKindleDict.Api.Dto;
class CoverPageDto {
    public string Title { get; set; }
    public string Author { get; set; }

    public string ToHtml() => $"<html>\r\n  <head>\r\n    <meta content=\"text/html\" http-equiv=\"content-type\">\r\n  </head>\r\n  <body>\r\n    <h1>{Title}</h1>\r\n    <h3>Created by {Author}</h3>\r\n  </body>\r\n</html>";
}
