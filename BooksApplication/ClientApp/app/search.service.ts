import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SearchResults } from './search/SearchResults';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { Suggestions } from './search/Suggestions';
import { catchError } from 'rxjs/operators';
import { Util } from './Util';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  searchUrl = "/api/book/search?query=";
  autocompleteUrl = "/api/book/autocomplete?query=";

  constructor(private http: HttpClient, private messageService:MessageService,) { }

  search(query: string) : Observable<SearchResults>{
    this.messageService.add("SearchService: searching for " + query);
    return this.http.get<SearchResults>(this.searchUrl + query)
    .pipe(
      catchError(Util.handleError('SearchService:search', this.messageService, new SearchResults)
    ));
  }

  autocomplete(query: string) : Observable<Suggestions[]>{
    this.messageService.add("SearchService: searching suggestions for: " + query);
    return this.http
      .get<Suggestions[]>(this.autocompleteUrl + query)
        .pipe(
          catchError(Util.handleError('SearchService:autocomplete', this.messageService, [])
        ));
  }
}
