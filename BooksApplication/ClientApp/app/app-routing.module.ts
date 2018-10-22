import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StatsComponent } from './stats/stats.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { AddComponent } from './add/add.component';

const routes: Routes = [
  {path: 'stats', component: StatsComponent},
  {path: 'home', component: HomeComponent},
  {path: 'search', component: SearchComponent},
  {path: 'add', component: AddComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
