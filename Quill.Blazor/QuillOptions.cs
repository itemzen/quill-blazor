using System.Text.Json.Serialization;

namespace Quill.Blazor;

/**
 * https://quilljs.com/docs/configuration
 */
public sealed record QuillOptions
{
    /// <summary>
    /// Static method enabling logging messages at a given level: 'error', 'warn', 'log',
    /// or 'info'. Passing true is equivalent to passing 'log'.
    /// Passing false disables all messages.
    /// </summary>
    [JsonPropertyName("debug")]
    public string? Debug { get; set; }

    /// <summary>
    /// A list of formats that are recognized and can exist within the editor contents.
    ///
    /// By default, all formats that are defined in the Quill library are allowed.
    /// To restrict formatting to a smaller list, pass in an array of the format names to support.
    /// </summary>
    [JsonPropertyName("formats")]
    public List<string>? Formats { get; set; }
    
    /// <summary>
    /// Placeholder text to show when editor is empty.
    /// </summary>
    [JsonPropertyName("placeholder")]
    public string? Placeholder { get; set; }

    /// <summary>
    /// Whether to instantiate the editor to read-only mode.
    /// </summary>
    [JsonPropertyName("readOnly")] 
    public bool IsReadOnly { get; set; }
    
    /// <summary>
    /// Name of theme to use. The builtin options are "bubble" or "snow".
    /// An invalid or falsy value will load a default minimal theme.
    /// Note the theme's specific stylesheet still needs to be included manually.
    /// </summary>
    [JsonPropertyName("theme")] 
    public string? Theme { get; set; }
}