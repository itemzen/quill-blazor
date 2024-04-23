using System.Reflection;
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

    private IJSObjectReference? _module;
    private ElementReference _editor;
    private IJSObjectReference? _instance;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            _module ??= await JsRuntime.InvokeAsync<IJSObjectReference>(
                "import", $"./_content/{assemblyName}/quill_interop.js");

            _instance = await _module.InvokeAsync<IJSObjectReference>(
                "init", _editor, ToolbarId, Options);
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

    public async Task Enable()
    {
        await _instance!.InvokeVoidAsync("enable");
    }

    public async Task Disable()
    {
        await _instance!.InvokeVoidAsync("disable");
    }

    public async ValueTask DisposeAsync()
    {
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