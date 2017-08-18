import { Component } from '@angular/core';
import {TripListComponent} from './trips/trip-list.component'
import { BrowserModule } from '@angular/platform-browser';
import { NgModule }      from '@angular/core';

@Component({
  selector: 'app-root',
  template:`<h1><trip-list></trip-list></h1>`,
  styleUrls: ['./app.component.css'],

})
export class AppComponent {
  title = 'app';
}
