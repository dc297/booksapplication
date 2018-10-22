import { Component, OnInit } from '@angular/core';
import {AddRequest} from './AddRequest';
import { AddService } from '../add.service';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  addRequest:AddRequest;
  uploadStatus : string;

  constructor(private addService : AddService, private messageService : MessageService) { }

  ngOnInit() {
    this.addRequest = new AddRequest();
  }

  upload(input: HTMLInputElement) : void{
    const file = input.files[0];
    if(file){
      this.addRequest.books[0].coverId = "";
      this.addService.upload(file).subscribe(
        imageId => {
          if(imageId.value=="" || imageId.value==undefined) {
            this.uploadStatus = "failed";

          }
          else {
            this.addRequest.books[0].coverId = imageId.value;
            this.uploadStatus = "Successfully Uploaded" + file.name;
          }
          input.value = null;
        }
      );
    }
  }
  save() : void{
    this.addService.add(this.addRequest).subscribe(addRequest=>
      {
        this.addRequest = new AddRequest();
        this.uploadStatus = "";
        if(addRequest.books[0].id!=0) this.messageService.add("Added book with id" + addRequest.books[0].id);
      })
  }

}
