import { Injectable } from '@angular/core';
import { of, Observable, throwError } from 'rxjs';

import { User } from '../../data/schema/user';

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

  login(loginContext: LoginContextInterface): Observable<User> {
    if (
      loginContext.username === defaultUser.username &&
      loginContext.password === defaultUser.password
    ) {
        return of(defaultUser);
    }

    return throwError('Invalid username or password');
  }

  logout(): Observable<boolean> {
    return of(false);
  }
}
