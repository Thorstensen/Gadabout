import { Component } from '@angular/core';

@Component({
    selector: 'trip-list',
    templateUrl:'trip-list.component.html',
    styleUrls: ['trip-list.component.css'],
})

export class TripListComponent {
    pageTitle:string = 'Trips'
}
