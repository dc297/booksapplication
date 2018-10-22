import { Injectable } from '@angular/core';
import {Observable, of} from 'rxjs';
import { Stats } from './stats/stats';
import { MessageService } from './message.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Util } from './Util';

@Injectable({
  providedIn: 'root'
})
export class StatsService {

  statsUrl = "/api/stats";
  constructor(private messageService: MessageService, private http : HttpClient) { }

  getStats() : Observable<Stats>{
    this.messageService.add('StatsService: Fetching stats');
    return this.http.get<Stats>(this.statsUrl)
    .pipe(
      catchError(Util.handleError('SearchService:autocomplete', this.messageService, new Stats)
    ));
  }
}
