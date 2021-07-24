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

            //$('#' + DataID).html('<div id="dk-loading-div" style="position:fixed; z-index: 99999; left: 50%; top: 50%; transform: translate(-50%,-50%); -ms-transform: translate(-50%,-50%); margin:auto; text-align:center"><img src="/images/spinner-whitebg-grayfg.gif"></div>');

            comment_sdk.ws(URL, function (e) {
                $('#' + DataID).html(e);
            });
        },
        remove: function (DataID, RemoveURL) {

            comment_sdk.ws(RemoveURL, null, null, function () { comment_sdk.load(DataID); });
        }

    }
})(0, 0);