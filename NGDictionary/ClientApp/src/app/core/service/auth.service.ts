import { Injectable } from '@angular/core';
import { of, Observable, throwError } from 'rxjs';
import { RegisterCredentials } from '@core/models/register-credentials.model';
import { User } from 'app/data/schema/user';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/internal/operators/tap';

interface LoginContextInterface {
  username: string;
  password: string;
  token: string;
}

const defaultUser: User = {
  username: '1',
  password: '1'
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
  ) {}

  // TODO: Implement
  login(loginContext: LoginContextInterface): Observable<User> {
    if (
      loginContext.username === defaultUser.username &&
      loginContext.password === defaultUser.password
    ) {
        return of(defaultUser);
    }

    return throwError('Invalid username or password');
  }

  signUp(credentials: RegisterCredentials): Observable<User> {
    return this.http.post<User>('api/auth', credentials)
      .pipe(tap(
      (user: User) => {
        // this.setAuth(user); //TODO: Implement
        console.log(user);
      }
    ));
  }

  // TODO: Implement
  logout(): Observable<boolean> {
    return of(false);
  }
}
