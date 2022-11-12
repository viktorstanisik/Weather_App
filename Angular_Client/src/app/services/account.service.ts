import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { LoginModel } from '../models/loginModel';
import { environment } from 'src/environments/environment';
import { RegisterModel } from '../models/register';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient, private router: Router) {}

  login(loginModel: LoginModel) {
    return this.http
      .post<User>(environment.apiUrl + 'User/loginuser', loginModel)
      .pipe(
        map((response: User) => {
          const user = response;
          console.log(response);
          if (user) {
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUserSource.next(user);
          }
        })
      );
  }

  register(registerModel: RegisterModel) {
    return this.http
      .post(environment.apiUrl + 'User/registeruser', registerModel)
      .pipe(
        map((user: User) => {
          if (user) {
            this.router.navigateByUrl('');
          } else console.log('there was an error please try again');

          this.router.navigateByUrl('');
        })
      );
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
