var LiveChat;
(function (LiveChat) {
    var MessageManager = /** @class */ (function () {
        function MessageManager() {
            var _this = this;
            this.CooldownMs = 40000;
            this.isSaving = false;
            this.$uiDisplayNameField = $("#uiUserName");
            this.$uiMessageField = $("#uiUserMessage");
            this.$uiSendMessageBtn = $("#uiSendMessage");
            this.$uiMessagesContainer = $("#uiChatLog");
            this.$uiSendMessageBtn.on('click', function () { return _this.onSendMessage(); });
            this.refreshMessages();
        }
        MessageManager.prototype.onSendMessage = function () {
            var _this = this;
            if (this.isSaving) {
                alert("Already saving!");
                return;
            }
            var display = this.getDisplayName();
            var message = this.getMessageText();
            this.isSaving = true;
            LiveChat.WebService.Site.SaveMessageAsync(display, message).then(function () {
                _this.$uiMessageField.val("");
            }).always(function () {
                _this.isSaving = false;
            });
        };
        MessageManager.prototype.getDisplayName = function () {
            return this.$uiDisplayNameField.val().trim();
        };
        MessageManager.prototype.getMessageText = function () {
            return this.$uiMessageField.val().trim();
        };
        MessageManager.prototype.refreshMessages = function () {
            var _this = this;
            LiveChat.WebService.Site.GetRecentMessagesAsync().then(function (data) {
                var containerHtml = "";
                for (var i in data) {
                    var chatMessage = data[i];
                    containerHtml += _this.buildMessageHtml(chatMessage);
                }
                _this.$uiMessagesContainer.html(containerHtml);
                setTimeout(function () { return _this.refreshMessages(); }, _this.CooldownMs);
            });
        };
        MessageManager.prototype.buildMessageHtml = function (pMessage) {
            return "<strong>" + pMessage.UserName + ":</strong> " + pMessage.Message + "<br />";
        };
        return MessageManager;
    }());
    $(document).ready(function () { return new MessageManager(); });
})(LiveChat || (LiveChat = {}));
//# sourceMappingURL=LiveChat.js.map