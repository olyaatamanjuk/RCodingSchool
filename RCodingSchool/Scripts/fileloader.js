var FileLoader = (function () {
    function FileLoader() {
        this.noop = function () { };
        this.fileChangeHandler = this.noop;

        this.files = [];
        this.fileInput = $('.fileloader');

        this.fileBtn.on('click', function () {
            this.fileInput.click();
        }.bind(this));

        this.fileInput.on('change', function (event) {
            this.fileChangeHandler(this.fileChange(event));
        }.bind(this));
    }

    FileLoader.prototype.fileChange = function (event) {
        var file = event.target.files[0];

        var url = URL.createObjectURL(file);

        var result = { url, file, key: 'file' + this.files.length };

        this.files.push(result);
    }

    return FileLoader;
})();

(function () {
    var fileUploader = new FileLoader();
    var canSubmit = false;
    var simplemde = new SimpleMDE({
        element: document.getElementById("text-input"),
        toolbar: [{
            name: "bold",
            action: SimpleMDE.toggleBold,
            className: "fa fa-bold",
            title: "Жирний",
        },
            "|",
        {
            name: "italic",
            action: SimpleMDE.toggleItalic,
            className: "fa fa-italic",
            title: "Курсив",
        },
            "|",
        {
            name: "сode",
            action: SimpleMDE.toggleCodeBlock,
            className: "fa fa-code",
            title: "Додати код",
        },
            "|",
        {
            name: "сode",
            action: SimpleMDE.togglePreview,
            className: "fa fa-eye no-disable",
            title: "Переглянути результат",
        },
            "|",
        {
            name: "squere",
            action: function customFunction(editor) {
                var cm = editor.codemirror;
                var text = ' <i>X</i><sup><small>2</small></sup>';
                cm.replaceSelection(text);
            },
            className: "fa fa-superscript",
            title: "Піднести до степеня",
        },
            "|",
        {
            name: "heading-2",
            action: SimpleMDE.toggleHeading2,
            className: "fa fa-header fa-header-x fa-header-2",
            title: "Заголовок h2",
        },
            "|",
        {
            name: "heading-3",
            action: SimpleMDE.toggleHeading3,
            className: "fa fa-header fa-header-x fa-header-3",
            title: "Заголовок h3",
        },
            "|",
        {
            name: "unordered-list",
            action: SimpleMDE.toggleUnorderedList,
            className: "fa fa-list-ul",
            title: "Список маркований",
        },
            "|",
        {
            name: "ordered-list",
            action: SimpleMDE.toggleOrderedList,
            className: "fa fa-list-ol",
            title: "Список",
        },
            "|",
        {
            name: "link",
            action: SimpleMDE.drawLink,
            className: "fa fa-link",
            title: "Посилання",
        },
            "|",
        {
            name: "image",
            action: SimpleMDE.drawImage,
            className: "fa fa-picture-o",
            title: "Зображення",
        },
            "|",
        {
            name: "fullscreen",
            action: SimpleMDE.toggleFullScreen,
            className: "fa fa-arrows-alt no-disable no-mobile",
            title: "На повний екран",
        },
            "|",
        {
            name: "table",
            action: SimpleMDE.drawTable,
            className: "fa fa-table",
            title: "Додати таблицю",
        },
            "|",
        {
            name: "tablvcde",
            action: function customFunction(editor) {
                var cm = editor.codemirror;
                var output = '';
                var selectedText = cm.getSelection();
                var text = selectedText || 'placeholder';

                output = '!!' + text + '!!';
                cm.replaceSelection(output);
            },
            className: "fa fa-bold",
            title: "Red text (Ctrl/Cmd-Alt-R)",
        },
        ]
    });

    fileUploader.fileChangeHandler = function (result) {
        var url = result.url;
    };

    var form = document.forms[0];

    form.onsubmit = function (event) {
        event.preventDefault();

        var fd = new FormData(form);
        fd.set('Text', encodeURI(simplemde.markdown(fd.get('Text'))));
        var markdownText = fd.get('Text');

        for (var file of fileUploader.files) {
            if (markdownText.indexOf(file.url)) {
                fd.set(file.key, file.file);
            }
        }

        var xhr = new XMLHttpRequest();
        xhr.open('POST', form.action);
        xhr.send(fd);
    };

    function getInputValue(name) {
        return document.getElementsByName(name)[0].value;
    }
})();