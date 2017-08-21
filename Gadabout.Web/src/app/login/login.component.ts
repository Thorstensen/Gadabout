import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from '../_services/authentication.service';
import {Router} from '@angular/router';

@Component({
    selector: 'login-form',
    templateUrl:'login.component.html',
    styleUrls: ['login.component.css'],
})

export class LoginComponent implements OnInit {
    
    model: any = {};
    error: string;
    
    constructor(private authenticationService:AuthenticationService,
                private router:Router) {

    }

    ngOnInit(): void {
      this.authenticationService.logut();
    }

    login(){
        this.authenticationService.login(this.model.userName, this.model.password)
                .subscribe(result => {
                    if(result == true){
                        this.error = '';
                        this.router.navigate(['/dashboard'])
                    }
                    else{
                        this.error = "Wrong Username or Password";
                    }
                });
    }
}
