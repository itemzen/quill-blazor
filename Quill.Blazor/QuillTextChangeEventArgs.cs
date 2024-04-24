namespace Quill.Blazor;

public sealed class QuillTextChangeEventArgs : EventArgs
{
    internal QuillTextChangeEventArgs(string delta, string oldContents, string source)
    {
        Delta = delta;
        OldContents = oldContents;
        Source = source;
    }
    
    public string Delta { get; private set; }

    public string OldContents { get; private set; }
    
    public string Source { get; private set; }
}