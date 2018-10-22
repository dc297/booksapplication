import {Observable, of} from "rxjs";
import { MessageService } from "./message.service";

export class Util{
  public static handleError<T> (operation = 'operation', messageService : MessageService, result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      messageService.add(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
