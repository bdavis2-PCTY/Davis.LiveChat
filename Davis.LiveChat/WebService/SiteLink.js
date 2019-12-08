var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var LiveChat;
(function (LiveChat) {
    var WebService;
    (function (WebService) {
        var SiteLink = /** @class */ (function (_super) {
            __extends(SiteLink, _super);
            function SiteLink() {
                return _super.call(this, "SiteLink.asmx") || this;
            }
            SiteLink.prototype.SaveMessageAsync = function (pUserDisplayName, pMessageText) {
                var params = {
                    pUserDisplayName: pUserDisplayName,
                    pMessageText: pMessageText
                };
                return this.invokeAsync('SaveMessage', params);
            };
            SiteLink.prototype.GetRecentMessagesAsync = function () {
                return this.invokeAsync('GetRecentMessages');
            };
            return SiteLink;
        }(LiveChat.WebService.WebServiceBase));
        WebService.Site = new SiteLink();
    })(WebService = LiveChat.WebService || (LiveChat.WebService = {}));
})(LiveChat || (LiveChat = {}));
//# sourceMappingURL=SiteLink.js.map