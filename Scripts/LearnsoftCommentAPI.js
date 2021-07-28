var comment_sdk = (function (ActivityKey, ActivityType) {

    return {

        ws: function (url, task, data, complete) {
            $.support.cors = true;
            $.ajax({
                crossDomain: false,
                url: url, data: data,
                success: task,
                complete: complete,
                error: function (xhr) {
                    console.log(xhr);
                    if (xhr.status === 401) {
                        //window.location.href = "/error.aspx";
                        return;
                    }
                }
            });
        },
        load: function (DataID, URL) {
            $('#' + DataID).fadeIn(400);

            if (URL == null)
                URL = document.getElementById(DataID).getAttribute("data-url");

            comment_sdk.ws(URL, function (e) {
                $('#' + DataID).html(e);
            });
        },
        remove: function (DataID, RemoveURL) {

            comment_sdk.ws(RemoveURL, null, null, function () { comment_sdk.load(DataID); });
        },
        count: function (obj, target) {
            $('#' + target).html(obj.value.length);
        }

    }
})(0, 0);