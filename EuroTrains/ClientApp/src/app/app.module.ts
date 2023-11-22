import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SearchTrainsComponent } from './search-trains/search-trains.component';
import { BookTrainsComponent } from './book-trains/book-trains.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SearchTrainsComponent,
    BookTrainsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: SearchTrainsComponent, pathMatch: 'full' },
      { path: 'search-trains', component: SearchTrainsComponent },
      { path: 'book-trains/:trainId', component: BookTrainsComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
