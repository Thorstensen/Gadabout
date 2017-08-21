import { Routes, RouterModule } from '@angular/router';
 
import { LoginComponent } from './login/login.component';
import { DashboardComponent} from './dashboard/dashboard.component';
import {AuthenticationGuard} from './_guards/authentication.guard'
 
const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'dashboard', component: DashboardComponent, canActivate: [AuthenticationGuard]},
    { path: '**', component: LoginComponent }
];
 
export const routing = RouterModule.forRoot(appRoutes);