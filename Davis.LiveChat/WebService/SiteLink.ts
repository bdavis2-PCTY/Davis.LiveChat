namespace LiveChat.WebService {
    class SiteLink extends LiveChat.WebService.WebServiceBase {
        public constructor() {
            super("SiteLink.asmx")
        }

        public SaveMessageAsync(pUserDisplayName: string, pMessageText: string): JQueryPromise<void> {
            const params: any = {
                pUserDisplayName: pUserDisplayName,
                pMessageText: pMessageText
            }

            return this.invokeAsync('SaveMessage', params);
        }

        public GetRecentMessagesAsync(): JQueryPromise<Array<LiveChat.WebService.DTO.Core.IChatMessage>> {
            return this.invokeAsync('GetRecentMessages');
        }
    }

    export const Site = new SiteLink();
}