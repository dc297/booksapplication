import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpEventType, HttpHeaders, HttpParams } from '@angular/common/http';
import { AddRequest} from './add/AddRequest';
import { Observable } from 'rxjs';
import { MessageService } from './message.service';
import { catchError, map, tap, last } from 'rxjs/operators';
import { Util } from './Util';
import { CoverResponse } from './add/CoverResponse';

@Injectable({
  providedIn: 'root'
})
export class AddService {

  addUrl = "/api/author";
  uploadUrl = "/api/covers";

  constructor(private http : HttpClient, private messageService : MessageService) { }

  add(addRequest: AddRequest) : Observable<AddRequest>{
    this.messageService.add("Add Service: adding book" + addRequest);
    return this.http.post<AddRequest>(this.addUrl, addRequest)
    .pipe(
      catchError(Util.handleError('AddService.add', this.messageService, new AddRequest))
    );
  }

    upload(file: File): Observable<CoverResponse>{
    if(!file) return;
    this.messageService.add("AddService : uploading file");
      let headers = new HttpHeaders();
      //this is the important step. You need to set content type as null
      headers.set('Content-Type', null);
      headers.set('Accept', "multipart/form-data");
      let params = new HttpParams();
      const formData: FormData = new FormData();
      formData.append('file', file, file.name);
        return this.http.post<CoverResponse>(this.uploadUrl, formData, { params, headers}).pipe(
          catchError(Util.handleError("AddService: Upload File: ", this.messageService, new CoverResponse()))
          );
  }
}
