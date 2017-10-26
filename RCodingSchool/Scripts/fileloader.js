(function () {
    var fileBtn = $('.imgloader');
    var fileInput = $('.fileloader');
    fileBtn.on('click', function () {
        fileInput.click();
    });
    //var filesArr = [];

    //fileInput.on('change', function (event) {
    //    var files = event.target.files[0];
    //    var fr = new FileReader();
    //    fr.onloadend = function (result) {
    //        $('#img-con').attr('src', result.target.result);
    //    };
    //    fr.readAsDataURL(files);
    //});
})();