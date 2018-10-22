var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { SearchService } from '../search.service';
var SearchComponent = /** @class */ (function () {
    function SearchComponent(searchService) {
        this.searchService = searchService;
    }
    SearchComponent.prototype.ngOnInit = function () {
    };
    SearchComponent.prototype.search = function () {
        var _this = this;
        this.searchService.search(this.query).subscribe(function (searchResults) { return _this.searchResults = searchResults; });
    };
    SearchComponent.prototype.autocomplete = function () {
        var _this = this;
        this.suggestions = [];
        if (this.query != "" && this.query != undefined)
            this
                .searchService
                .autocomplete(this.query)
                .subscribe(function (suggestions) {
                return _this.suggestions = suggestions;
            });
    };
    SearchComponent.prototype.suggestionClick = function (suggestion) {
        this.query = suggestion.name;
    };
    SearchComponent = __decorate([
        Component({
            selector: 'app-search',
            templateUrl: './search.component.html',
            styleUrls: ['./search.component.css']
        }),
        __metadata("design:paramtypes", [SearchService])
    ], SearchComponent);
    return SearchComponent;
}());
export { SearchComponent };
//# sourceMappingURL=search.component.js.map