import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {TripListComponent} from './trips/trip-list.component'
import {LoginComponent} from './login/login.component'

@NgModule({
  declarations: [
    AppComponent,
    TripListComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
