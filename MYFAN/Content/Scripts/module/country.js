var countyScripts = (function () {

    $('#uploadImage').change(function () {
        var f = this.files[0];
        if (f) {
            $('.content-wrap').isLoading({ position: "overlay" });
            $('#fileSize').val(f.size);
            var fD = new FormData();
            var filename = $('#uploadFile').val();
            if ((filename.indexOf('/') != -1) || (filename.indexOf('\\') != -1)) {
                var filenames;
                if (filename.indexOf('/') != -1)
                    filenames = filename.split('/');
                if (filename.indexOf('\\') != -1)
                    filenames = filename.split('\\');
                if (filenames.length > 0)
                    filename = filenames[filenames.length - 1];
            }
            fD.append('uploadedFile', f);
            $.ajax({
                url: '/admin/upload-country',
                type: 'POST',
                data: fD,
                processData: false,
                contentType: false,
                success: function (data) {

                },
                error: function (jqXHR, textStatus, xhr) {
                    $('.content-wrap').isLoading("hide");
                    console.log(jqXHR.responseText);
                }
            })
        }
    });;

    return {
        init: init
    };
});

countyScripts.init();