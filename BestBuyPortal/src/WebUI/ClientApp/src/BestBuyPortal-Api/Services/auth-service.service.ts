import { Injectable } from '@angular/core';
import { AccountClient, LoginCommand, LoginDTO, Result } from '../bestBuy-api';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  private currentUserSubject: BehaviorSubject<LoginDTO>;
  public currentUser: Observable<LoginDTO>;

  constructor(private http: HttpClient,private empClient:AccountClient) {
    this.currentUserSubject = new BehaviorSubject<LoginDTO>(
      JSON.parse(sessionStorage.getItem("currentUser"))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): LoginDTO {
    return this.currentUserSubject.value;
  }

  login(name: string, password: string):Observable<Result> {
    debugger;
    return this.empClient
      .loginRequest(<LoginCommand>{
        name,
        password,
      })
      .pipe(
        map(user => {
          console.log(user)
          if(user.succeeded==true){

          
          // store user details and basic auth credentials in session storage to keep user logged in between page refreshes
          sessionStorage.setItem('currentUser', JSON.stringify(user.lists.token));
         // user.lists = window.btoa(name + ":" + password);
         //sessionStorage.setItem("currentUser", JSON.stringify(user));
         
          this.currentUserSubject.next(user);
          }
          return user;
        })
      );
  }

  logout() {
    // remove user from session storage to log user out
    sessionStorage.removeItem("currentUser");
    this.currentUserSubject.next(null);
  }
}