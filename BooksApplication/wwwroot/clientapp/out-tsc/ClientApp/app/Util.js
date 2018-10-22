import { of } from "rxjs";
var Util = /** @class */ (function () {
    function Util() {
    }
    Util.handleError = function (operation, messageService, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead
            messageService.add(operation + " failed: " + error.message);
            // Let the app keep running by returning an empty result.
            return of(result);
        };
    };
    return Util;
}());
export { Util };
//# sourceMappingURL=Util.js.map