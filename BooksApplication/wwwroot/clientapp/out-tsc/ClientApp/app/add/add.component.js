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
import { AddRequest } from './AddRequest';
import { AddService } from '../add.service';
import { MessageService } from '../message.service';
var AddComponent = /** @class */ (function () {
    function AddComponent(addService, messageService) {
        this.addService = addService;
        this.messageService = messageService;
    }
    AddComponent.prototype.ngOnInit = function () {
        this.addRequest = new AddRequest();
    };
    AddComponent.prototype.upload = function (input) {
        var _this = this;
        var file = input.files[0];
        if (file) {
            this.addRequest.books[0].coverId = "";
            this.addService.upload(file).subscribe(function (imageId) {
                if (imageId.value == "" || imageId.value == undefined) {
                    _this.uploadStatus = "failed";
                }
                else {
                    _this.addRequest.books[0].coverId = imageId.value;
                    _this.uploadStatus = "Successfully Uploaded" + file.name;
                }
                input.value = null;
            });
        }
    };
    AddComponent.prototype.save = function () {
        var _this = this;
        this.addService.add(this.addRequest).subscribe(function (addRequest) {
            _this.addRequest = new AddRequest();
            _this.uploadStatus = "";
            if (addRequest.books[0].id != 0)
                _this.messageService.add("Added book with id" + addRequest.books[0].id);
        });
    };
    AddComponent = __decorate([
        Component({
            selector: 'app-add',
            templateUrl: './add.component.html',
            styleUrls: ['./add.component.css']
        }),
        __metadata("design:paramtypes", [AddService, MessageService])
    ], AddComponent);
    return AddComponent;
}());
export { AddComponent };
//# sourceMappingURL=add.component.js.map