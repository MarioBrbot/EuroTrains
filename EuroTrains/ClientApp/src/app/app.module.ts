import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SearchTrainsComponent } from './search-trains/search-trains.component';
import { BookTrainsComponent } from './book-trains/book-trains.component';
import { RegisterPassengerComponent } from './register-passenger/register-passenger.component';
import { MyBookingsComponent } from './my-bookings/my-bookings.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SearchTrainsComponent,
    BookTrainsComponent,
    RegisterPassengerComponent,
    MyBookingsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: SearchTrainsComponent, pathMatch: 'full' },
      { path: 'search-trains', component: SearchTrainsComponent },
      { path: 'book-trains/:trainId', component: BookTrainsComponent, canActivate: [AuthGuard] },
      { path: 'register-passenger', component: RegisterPassengerComponent },
      { path: 'my-booking', component: MyBookingsComponent, canActivate: [AuthGuard] },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
