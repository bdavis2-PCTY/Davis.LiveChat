namespace LiveChat {
    export class Helpers {
        private static $uiAppRoot: JQuery = $("#uiAppRoot");

        public static GetAppRoot(): string {
            return this.$uiAppRoot.val();
        }

        public static GetAppPath(pRoute: string) {
            return (this.GetAppRoot()) + '/' + pRoute;
        }
    }
}