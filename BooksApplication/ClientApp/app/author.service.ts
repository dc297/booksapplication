import { Injectable } from '@angular/core';
import { Author } from './home/author';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from './message.service';
import { catchError } from 'rxjs/operators';
import { Util } from './Util';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  private authorsUrl = '/api/author';

  constructor(private http: HttpClient, private messageService: MessageService) { }

  getAuthors() : Observable<Author[]>{
    this.messageService.add("AuthorService: Fetching authors with books");
    return this.http.get<Author[]>(this.authorsUrl)
      .pipe(
        catchError(Util.handleError('SearchService:autocomplete', this.messageService, [])
      ));

  }
}
