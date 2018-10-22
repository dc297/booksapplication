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
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AddRequest } from './add/AddRequest';
import { MessageService } from './message.service';
import { catchError } from 'rxjs/operators';
import { Util } from './Util';
import { CoverResponse } from './add/CoverResponse';
var AddService = /** @class */ (function () {
    function AddService(http, messageService) {
        this.http = http;
        this.messageService = messageService;
        this.addUrl = "/api/author";
        this.uploadUrl = "/api/covers";
    }
    AddService.prototype.add = function (addRequest) {
        this.messageService.add("Add Service: adding book" + addRequest);
        return this.http.post(this.addUrl, addRequest)
            .pipe(catchError(Util.handleError('AddService.add', this.messageService, new AddRequest)));
    };
    AddService.prototype.upload = function (file) {
        if (!file)
            return;
        this.messageService.add("AddService : uploading file");
        var headers = new HttpHeaders();
        //this is the important step. You need to set content type as null
        headers.set('Content-Type', null);
        headers.set('Accept', "multipart/form-data");
        var params = new HttpParams();
        var formData = new FormData();
        formData.append('file', file, file.name);
        return this.http.post(this.uploadUrl, formData, { params: params, headers: headers }).pipe(catchError(Util.handleError("AddService: Upload File: ", this.messageService, new CoverResponse())));
    };
    AddService = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [HttpClient, MessageService])
    ], AddService);
    return AddService;
}());
export { AddService };
//# sourceMappingURL=add.service.js.map