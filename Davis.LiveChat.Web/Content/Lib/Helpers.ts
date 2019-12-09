namespace LiveChat {
    export class Helpers {
        private static $uiAppRoot: JQuery = $("#uiAppRoot");

        public static GetAppRoot(): string {
            return this.$uiAppRoot.val();
        }

        public static GetAppPath(pRoute: string) {
            return (this.GetAppRoot()) + '/' + pRoute;
        }

        /**
         * Calculates how long (seconds) it will take the user to read the text
         * @param pText
         */
        public static CalculateTextReadTime(pText: string): number {
            const wordCount: number = pText.split(/\s/g).length;
            const seconds: number = wordCount / 120;
            return Math.ceil(seconds);
        }
    }
}