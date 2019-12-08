var LiveChat;
(function (LiveChat) {
    var Helpers = /** @class */ (function () {
        function Helpers() {
        }
        Helpers.GetAppRoot = function () {
            return this.$uiAppRoot.val();
        };
        Helpers.GetAppPath = function (pRoute) {
            return (this.GetAppRoot()) + '/' + pRoute;
        };
        Helpers.$uiAppRoot = $("#uiAppRoot");
        return Helpers;
    }());
    LiveChat.Helpers = Helpers;
})(LiveChat || (LiveChat = {}));
//# sourceMappingURL=Helpers.js.map