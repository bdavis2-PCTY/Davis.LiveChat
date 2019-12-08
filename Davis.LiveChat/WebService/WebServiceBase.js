var LiveChat;
(function (LiveChat) {
    var WebService;
    (function (WebService) {
        var WebServiceBase = /** @class */ (function () {
            function WebServiceBase(baseUrl) {
                this.baseUrl = "WebService/" + baseUrl;
            }
            WebServiceBase.prototype.internalInvoke = function (methodName, params, silent) {
                var settings = {
                    type: 'POST',
                    url: LiveChat.Helpers.GetAppPath(this.baseUrl + '/' + methodName),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    global: !silent,
                    data: {}
                };
                if (params) {
                    settings.data = JSON.stringify(params, null, 2);
                }
                return $.ajax(settings)
                    .then(function (reply) {
                    try {
                        return JSON.parse(reply.d);
                    }
                    catch (ex) {
                        return reply.d; // Not all web services return JSON, if we are here the reply is probably just a regular string
                    }
                }).fail(function (reply) {
                    console.log('error response');
                    console.log(reply);
                });
            };
            WebServiceBase.prototype.invokeAsync = function (methodName, params) {
                if (params === void 0) { params = {}; }
                return this.internalInvoke(methodName, params, false);
            };
            return WebServiceBase;
        }());
        WebService.WebServiceBase = WebServiceBase;
    })(WebService = LiveChat.WebService || (LiveChat.WebService = {}));
})(LiveChat || (LiveChat = {}));
//# sourceMappingURL=WebServiceBase.js.map