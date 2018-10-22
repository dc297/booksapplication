import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StatsComponent } from './stats/stats.component';
import { MessageComponent } from './message/message.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { AddComponent } from './add/add.component';

@NgModule({
  declarations: [
    AppComponent,
    StatsComponent,
    MessageComponent,
    HomeComponent,
    SearchComponent,
    AddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
