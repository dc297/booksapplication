var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SearchResults } from './search/SearchResults';
import { MessageService } from './message.service';
import { catchError } from 'rxjs/operators';
import { Util } from './Util';
var SearchService = /** @class */ (function () {
    function SearchService(http, messageService) {
        this.http = http;
        this.messageService = messageService;
        this.searchUrl = "/api/book/search?query=";
        this.autocompleteUrl = "/api/book/autocomplete?query=";
    }
    SearchService.prototype.search = function (query) {
        this.messageService.add("SearchService: searching for " + query);
        return this.http.get(this.searchUrl + query)
            .pipe(catchError(Util.handleError('SearchService:search', this.messageService, new SearchResults)));
    };
    SearchService.prototype.autocomplete = function (query) {
        this.messageService.add("SearchService: searching suggestions for: " + query);
        return this.http
            .get(this.autocompleteUrl + query)
            .pipe(catchError(Util.handleError('SearchService:autocomplete', this.messageService, [])));
    };
    SearchService = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [HttpClient, MessageService])
    ], SearchService);
    return SearchService;
}());
export { SearchService };
//# sourceMappingURL=search.service.js.map