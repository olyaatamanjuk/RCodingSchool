var FileLoader = (function () {
    function FileLoader() {
        this.noop = function () { };
        this.fileChangeHandler = this.noop;

        this.files = [];
        this.fileInput = $('.fileloader');

        this.fileInput.on('change', function (event) {
            this.fileChangeHandler(this.fileChange(event));
        }.bind(this));
    }

    FileLoader.prototype.fileChange = function (event) {
        var file = event.target.files[0];

        var url = URL.createObjectURL(file);

        var result = { url, file };

        this.files.push(result);

        return result;
    }

    FileLoader.prototype.openFileDialog = function () {
        this.fileInput.click();
    }

    return FileLoader;
})();

var simplemde;
var fileUploader = new FileLoader();
var form = document.forms[0];
var onsubmit = function (event) {
    event.preventDefault();

    var fd = new FormData(form);
    fd.set('Text', encodeURI(fd.get('Text')));
    var markdownText = fd.get('Text');

    for (var file of fileUploader.files) {
        if (markdownText.indexOf(file.url) >= 0) {
            fd.set(file.url, file.file);
        }
    }

    var xhr = new XMLHttpRequest();
    xhr.onloadend = function () {
        var chapterId = document.getElementsByName("ChapterId")[0].value;
        location.replace(`/Chapter/Chapter/${chapterId}`);
    };
    xhr.open('POST', form.action);
    xhr.send(fd);
};

(function () {
    var modal = $('#myModal');
    var rangeInput = $('#image-width');
    $('#image-width').val(100);
    var saveRangeBtn = $('#save-range-btn');
    var imageWidth, fileUploadResult;
    var md = markdownit({ html: true }).use(texmath.use(katex));
    simplemde = new SimpleMDE({
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
            action: function (editor) {
                fileUploader.fileChangeHandler = function (result) {
                    modal.modal('show');
                    $('#image-width-indicator').html(rangeInput.val());
                    fileUploadResult = result;
                };
                fileUploader.openFileDialog();
            }
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
        ],
        previewRender: function (plainText) {
            return md.render(plainText);
        }
    });

    saveRangeBtn.on('click', function () {
        imageWidth = rangeInput.val();
        modal.modal('hide');
    });

    modal.on('hidden.bs.modal', function () {
        var html = `<img src="${fileUploadResult.url}" width="${imageWidth}">`;
        simplemde.codemirror.replaceSelection(html);
        $('#image-width').val(100);
    });

    rangeInput.on('change', function () {
        var _this = $(this);
        $('#image-width-indicator').html(_this.val());
    });

    form.onsubmit = onsubmit;
})();