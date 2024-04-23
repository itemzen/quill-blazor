export function init(editor, toolbar, options) {

    if(toolbar) {
        options["modules"] = {
            'toolbar': '#' + toolbar
        };
    }
    
    const quill = new Quill(editor, options);
    
    quill.loadHtml = (html) => {
        quill.root.innerHTML = html;
    }
    
    return quill;
}