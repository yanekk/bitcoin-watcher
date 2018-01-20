(function ($) {
    $.each(["get", "post", "put", "delete"], function (i, method) {
        var methodName = method + "Json";

        $[methodName] = function (url, data) {
            return jQuery.ajax({
                url: url,
                type: method,
                contentType: "application/json",
                data: JSON.stringify(data)
            });
        };
    });
}(jQuery));