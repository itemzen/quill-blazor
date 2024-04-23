namespace Quill.Blazor;

public static class QuillValue
{
    public const string OrderedList = "ordered";
    public const string BulletList = "bullet";

    public const string Indent = "+1";
    public const string Unindent = "-1";

    public static readonly List<string?> Sizes = new()
    {
        "small", null, "large", "huge"
    };

    public static readonly List<string?> Headers = new()
    {
        null, "1", "2", "3", "4", "5", "6"
    };
}