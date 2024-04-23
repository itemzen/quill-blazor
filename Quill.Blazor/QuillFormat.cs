// ReSharper disable MemberCanBePrivate.Global
namespace Quill.Blazor;

/**
 * https://quilljs.com/docs/formats
 */
public static class QuillFormat
{
    // Inline
    public const string BackgroundColor = "background";
    public const string Bold = "bold";
    public const string Color = "color";
    public const string Font = "font";
    public const string InlineCode = "code";
    public const string Italic = "italic";
    public const string Link = "link";
    public const string Size = "size";
    public const string Strikethrough = "strike";
    public const string Script = "script";
    public const string Underline = "underline";

    public static readonly List<string> Inline = new()
    {
        BackgroundColor,
        Bold,
        Color,
        Font,
        InlineCode,
        Italic,
        Link,
        Size,
        Strikethrough,
        Script,
        Underline
    };

    // Block
    public const string Blockquote = "blockquote";
    public const string Header = "header";
    public const string Indent = "indent";
    public const string List = "list";
    public const string TextAlignment = "align";
    public const string TextDirection = "direction";
    public const string CodeBlock = "code-block";

    public static readonly List<string> Block = new()
    {
        Blockquote,
        Header,
        Indent,
        List,
        TextAlignment,
        TextDirection,
        CodeBlock
    };

    // Embeds
    public const string Formula = "formula";
    public const string Image = "image";
    public const string Video = "video";

    public static readonly List<string> Embeds = new()
    {
        Formula,
        Image,
        Video
    };
}