using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Quill.Blazor;

public sealed partial class QuillEditor : IAsyncDisposable
{
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public string? ToolbarId { get; set; }

    [Parameter] public QuillOptions Options { get; set; } = new();

    [Parameter] public string Class { get; set; } = string.Empty;

    [Parameter] public string Style { get; set; } = string.Empty;

    [Parameter] public EventCallback<QuillTextChangeEventArgs> OnTextChange { get; set; }
    
    private IJSObjectReference? _module;
    private ElementReference _editor;
    private IJSObjectReference? _instance;
    private DotNetObjectReference<QuillEditor>? _interopRef;

    private const string PackageName = "Itemzen.Quill.Blazor";
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _module ??= await JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", $"./_content/{PackageName}/quill_interop.js");

            _interopRef = DotNetObjectReference.Create(this);
            _instance = await _module.InvokeAsync<IJSObjectReference>(
                "init", _editor, ToolbarId, Options, _interopRef);
        }
    }

    public async Task<string> GetText()
    {
        return await _instance!.InvokeAsync<string>("getText");
    }

    public async Task<string> GetHtml()
    {
        return await _instance!.InvokeAsync<string>("getSemanticHTML");
    }

    public async Task LoadHtml(string html)
    {
        await _instance!.InvokeVoidAsync("loadHtml", html);
    }

    public async Task SetPlaceholder(string placeholder)
    {
        await _instance!.InvokeVoidAsync("setPlaceholder", placeholder);
    }
    
    public async Task<int> GetLength()
    {
        return await _instance!.InvokeAsync<int>("getLength");
    }

    public async Task Enable()
    {
        await _instance!.InvokeVoidAsync("enable");
    }

    public async Task Disable()
    {
        await _instance!.InvokeVoidAsync("disable");
    }

    [JSInvokable]
    public Task TextChanged(string delta, string oldContents, string source)
    {
        var args = new QuillTextChangeEventArgs(delta, oldContents, source);
        return OnTextChange.InvokeAsync(args);
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_interopRef != null)
        {
            _interopRef.Dispose();
            _interopRef = null;
        }
        
        if (_instance != null)
        {
            await _instance.DisposeAsync();
            _instance = null;
        }

        if (_module != null)
        {
            await _module.DisposeAsync();
            _module = null;
        }
    }
}