var FileLoader = (function () {
    function FileLoader() {
        this.noop = function () { };
        this.fileChangeHandler = this.noop;

        this.files = [];
        this.fileBtn = $('.imgloader');
        this.fileInput = $('.fileloader');

        this.fileBtn.on('click', function () {
            this.fileInput.click();
        }.bind(this));

        this.fileInput.on('change', function (event) {
            this.fileChangeHandler(this.fileChange(event));
        }.bind(this));
    }

    FileLoader.prototype.upload = function () {
        return new Promise(function (resolve, reject) {
            var xhr = new XMLHttpRequest();
            var fd = new FormData();

            for (var i = 0; i < this.files.length; i++) {
                fd.append(this.files[i].url, this.files[i].file);
            }

            xhr.onloadend = function (event) {
                var res = event.target.response;
                resolve(JSON.parse(res));
            };

            xhr.onerror = function () {
                reject();
            };

            xhr.open('POST', "/File/Upload");
            xhr.send(fd);
        });
    };

    FileLoader.prototype.fileChange = function (event) {
        var file = event.target.files[0];

        var url = URL.createObjectURL(file);

        var result = { url, file };

        this.files.push(result);
    }

    return FileLoader;
})();

(function () {
    var fileUploader = new FileLoader();
    var canSubmit = false;
    var simplemde = new SimpleMDE({
        element: document.getElementById("text-input")
        //, toolbar: [
        //    {
        //        name: "custom",
        //        action: function customFunction(editor) {
        //            // Add your own code
        //        },
        //        className: "fa fa-star",
        //        title: "Custom Button",
        //    }
        //]
    });

    fileUploader.fileChangeHandler = function (result) {
        var url = result.url;
    };

    var form = document.forms[0];

    form.onsubmit = function (event) {
        if (!canSubmit) {
            event.preventDefault();
            fileUploader.upload().then(function (data) { // [{temp: '', original: ''}]
                // Replace temp url with new ones from data
                canSubmit = true;
                form.submit();
            });
        }
    };
})();