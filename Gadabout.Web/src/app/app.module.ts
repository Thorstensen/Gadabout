import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import {TripListComponent} from './trips/trip-list.component'
import {LoginComponent} from './login/login.component'
import { FormsModule }   from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AuthenticationService } from './_services/authentication.service';
import { routing }        from './app.routing';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    TripListComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing,
    HttpClientModule
  ],
  providers: [
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
