import { Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule }      from '@angular/core';

@Component({
  selector: 'app-root',
  template:`<router-outlet></router-outlet>`,
  styleUrls: ['./app.component.css'],

})
export class AppComponent {
  title = 'app';
}
