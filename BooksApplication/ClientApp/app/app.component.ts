import { Component } from '@angular/core';
import { StatsComponent } from './stats/stats.component';
import {MessageComponent} from './message/message.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'books-ui';
}
