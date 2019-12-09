namespace LiveChat {
    class MessageManager {
        private readonly cooldownMs: number = 500;

        private $uiDisplayNameField: JQuery;
        private $uiMessageField: JQuery;
        private $uiSendMessageBtn: JQuery;
        private $uiMessagesContainer: JQuery;

        private isSaving: boolean = false;
 
        public constructor() {
            this.$uiDisplayNameField = $("#uiUserName");
            this.$uiMessageField = $("#uiUserMessage");
            this.$uiSendMessageBtn = $("#uiSendMessage");
            this.$uiMessagesContainer = $("#uiChatLog");

            this.$uiSendMessageBtn.on('click', () => this.onSendMessage());

            this.refreshMessages();
        }

        private onSendMessage(): void {
            if (this.isSaving) {
                alert("Already saving!");
                return;
            }

            let display = this.getDisplayName();
            let message = this.getMessageText();

            this.isSaving = true;
            LiveChat.WebService.Site.SaveMessageAsync(display, message).then(() => {
                this.$uiMessageField.val("");
            }).always(() => {
                this.isSaving = false;
            });
        }

        private getDisplayName(): string {
            return this.$uiDisplayNameField.val().trim();
        }

        private getMessageText(): string {
            return this.$uiMessageField.val().trim();
        }

        /**
         * Refreshes the message log
         */
        private refreshMessages(): void {
            LiveChat.WebService.Site.GetRecentMessagesAsync().then((data: Array<LiveChat.WebService.DTO.Core.IChatMessage>) => {
                let containerHtml: string = "";
                for (let i in data) {
                    let chatMessage: LiveChat.WebService.DTO.Core.IChatMessage = data[i];
                    containerHtml += this.buildMessageHtml(chatMessage);
                }

                this.$uiMessagesContainer.html(containerHtml);

                setTimeout(() => this.refreshMessages(), this.cooldownMs);
            });
        }

        private buildMessageHtml(pMessage: LiveChat.WebService.DTO.Core.IChatMessage): string {
            return "<strong>[" + pMessage.SentDateTime + "] " + pMessage.UserName + ":</strong> " + pMessage.Message + "<br />";
        }

    }

    $(document).ready(() => new MessageManager());
}