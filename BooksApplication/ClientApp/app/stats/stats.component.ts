import { Component, OnInit } from '@angular/core';
import {Stats} from './stats';
import {StatsService} from '../stats.service';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {

  stats: Stats;
  constructor(private statsService:StatsService) { }

  ngOnInit() {
    this.getStats();
  }

  getStats(): void{
    this.statsService.getStats().subscribe(stats => this.stats = stats);
  }

}
