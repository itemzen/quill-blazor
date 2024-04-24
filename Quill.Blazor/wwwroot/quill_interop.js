export function init(editor, toolbarId, options, interopReference) {

    if(toolbarId) {
        options["modules"] = {
            'toolbar': '#' + toolbarId
        };
    }
    
    const quill = new Quill(editor, options);
    
    quill.loadHtml = (html) => {
        quill.clipboard.dangerouslyPasteHTML(html);
    }

    quill.setPlaceholder = (placeholder) => {
        quill.root.dataset.placeholder = placeholder;
    }
    
    quill.on('text-change', async (delta, oldContents, source) => {
        await interopReference.invokeMethodAsync(
            "TextChanged", JSON.stringify(delta), JSON.stringify(oldContents), source);
    });
    
    return quill;
}