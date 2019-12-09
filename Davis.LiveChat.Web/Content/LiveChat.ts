namespace LiveChat {
    class MessageManager {
        private readonly cooldownMs: number = 500;

        private $uiDisplayNameField: JQuery;
        private $uiMessageField: Quill.Quill;
        private $uiSendMessageBtn: JQuery;
        private $uiMessagesContainer: JQuery;

        private isSaving: boolean = false;
 
        public constructor() {
            this.$uiDisplayNameField = $("#uiUserName");
            this.$uiSendMessageBtn = $("#uiSendMessage");
            this.$uiMessagesContainer = $("#uiChatLog");

            this.$uiSendMessageBtn.on('click', () => this.onSendMessage());

            this.refreshMessages();

            this.$uiMessageField = new Quill('#uiInputEditor', {
                theme: 'snow',
                modules:
                {
                    toolbar: [
                        ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
                        ['blockquote', 'code-block'],

                        [{ 'header': 1 }, { 'header': 2 }],               // custom button values
                        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                        [{ 'script': 'sub' }, { 'script': 'super' }],      // superscript/subscript
                        [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
                        [{ 'direction': 'rtl' }],                         // text direction

                        [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
                        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

                        [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
                        [{ 'font': [] }],
                        [{ 'align': [] }],

                        ['clean']                                         // remove formatting button
                    ]
                }
            });
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
                this.$uiMessageField.setText("");
            }).always(() => {
                this.isSaving = false;
            });
        }

        private getDisplayName(): string {
            return this.$uiDisplayNameField.val().trim();
        }

        private getMessageText(): string {
            console.log(this.$uiMessageField.getContents());

            return this.$uiMessageField.getText().trim()
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