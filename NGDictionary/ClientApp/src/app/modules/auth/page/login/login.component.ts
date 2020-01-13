import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { tap, finalize, catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { AuthService } from '@core/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  error: string = '';
  isLoading: boolean = false;
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {}

  login() {
    this.isLoading = true;

    const credentials = this.loginForm.value;

    this.authService.login(credentials)
      .pipe(
        tap(user => this.router.navigate(['/home'])),
        finalize(() => this.isLoading = false),
        catchError(error => of(this.error = error))
      ).subscribe();
  }

}
