import { Injectable } from '@angular/core';
import { Http, Headers, Response, URLSearchParams, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {

    public token:string;
    private authenticationEndpoint:string = "http://localhost:8081/login";
    private grant_type:string = "password";

    constructor(private http: Http) {
        var currentUser = JSON.parse(localStorage.getItem('user'));
        this.token = currentUser && currentUser.token;
    }

    login(userName: string, password:string) : Observable<boolean> {
        
        var headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded')
       
        let params: URLSearchParams = this.formatHttpParameters(userName, password);
        
        return this.http.post(this.authenticationEndpoint, params)
            .map((response) =>  {
                    let token = response.json() && response.json().access_token;
                    if(token){
                        this.token = token;
                        localStorage.setItem('user', JSON.stringify({userName: userName, token:token}));
                        return true;
                    }

                    return false;
                }).catch((err:Response, caught:Observable<boolean>) => {
                    return  Observable.of(false);
                });
    }

    logut() : void {
        this.token = null;
        localStorage.removeItem('user');
    }

    formatHttpParameters(userName:string, password:string): URLSearchParams {
        var params = new URLSearchParams();
        params.set("username", userName);
        params.set("password", password);
        params.set("grant_type", "password");

        return params;
    }
}