import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { GameList } from './gameList.component';
import { DataService } from "./shared/dataService";

@NgModule({
  declarations: [
    AppComponent,
    GameList
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
  ],
  providers: [
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
