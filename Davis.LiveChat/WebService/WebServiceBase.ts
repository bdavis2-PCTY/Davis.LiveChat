namespace LiveChat.WebService {
    export abstract class WebServiceBase {
        private baseUrl: string;

        public constructor(baseUrl: string) {
            this.baseUrl = `WebService/${baseUrl}`;
        }

        private internalInvoke(methodName: string, params: object, silent: boolean): JQueryPromise<any> {
            let settings = {
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
                .then((reply) => {
                    try {
                        return JSON.parse(reply.d);
                    } catch (ex) {
                        return reply.d; // Not all web services return JSON, if we are here the reply is probably just a regular string
                    }
                }).fail(function (reply) {
                    console.log('error response');
                    console.log(reply);
                });
        }

        public invokeAsync(methodName: string, params: object = {}): JQueryPromise<any> {
            return this.internalInvoke(methodName, params, false);
        }
    }
}