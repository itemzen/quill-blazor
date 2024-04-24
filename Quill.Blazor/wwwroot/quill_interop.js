export function init(editor, toolbar, options, interopReference) {

    if(toolbar) {
        options["modules"] = {
            'toolbar': '#' + toolbar
        };
    }
    
    const quill = new Quill(editor, options);
    
    quill.loadHtml = (html) => {
        quill.root.innerHTML = html;
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