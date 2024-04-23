# Quill.Blazor

(Minimal) Blazor wrapper for the [quilljs](https://quilljs.com/) library.

## Installation

### NuGet

```bash
dotnet add package Quill.Blazor
```

The version of the nuget package matches the quill version against which the wrapper was created,
including a version suffix indicating the wrapper release number. For example, `v2.0.0-r2` indicates the
second release of the wrapper for version `2.0.0` of the quill library.

Note that it is in general fine to use/include a different (minor) quill version in your project,
especially bugfix releases, but if things don't work as expected it might be best to try and match
the quill version exactly.

### index.html

Download the quill files

```bash
curl https://cdn.jsdelivr.net/npm/quill@2.0.0/dist/quill.js -o quill.js
curl https://cdn.jsdelivr.net/npm/quill@2.0.0/dist/quill.snow.css -o quill.snow.css
```

Copy these files over from to your Blazor project

```bash
wwwroot/lib/quill.js
wwwroot/lib/quill.snow.css
```

Add the following lines in `wwwroot/index.html`

```html
<head>
    ...
    <link href="lib/quill.snow.css" rel="stylesheet" />
</head>
<body>
    ...
    <script src="lib/quill.js"></script>
</body>
```

### Imports

Add a reference to the relevant namespace in the top-level `_Imports.razor` file of your project

```razor
@using Quill.Blazor
```

## Usage

At a minimum, add the `QuillEditor` component to your page with its `QuillOptions`.
A custom `QuillToolbar` can optionally be added, to be linked to the `QuillEditor` through its ID.

```razor
<QuillToolbar Id="toolbar"/>
<QuillEditor ToolbarId="toolbar"/>
```

The toolbar can be filled with controls using the `QuillToolbarSection`, `QuillToolbarButton` and
`QuillToolbarSelect` controls.

Please refer to the [demo project](https://github.com/itemzen/quill-blazor/tree/main/Quill.Blazor.Demo) for details.

## Acknowledgements

Brought to you by the [itemzen](https://itemzen.com) team.
