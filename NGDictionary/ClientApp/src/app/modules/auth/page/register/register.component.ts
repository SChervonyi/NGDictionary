import { AuthService } from '@core/service/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Errors } from '@core/models/errors.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  authForm: FormGroup;
  title: String = '';
  errors: Errors = {errors: {}};
  isSubmitting = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) {
        // use FormBuilder to create a form group
        this.authForm = this.fb.group({
          'email': ['', Validators.required],
          'password': ['', Validators.required],
          'username': ['', Validators.required]
        });
   }

  ngOnInit() {
  }

  submitForm() {
    this.isSubmitting = true;
    this.errors = {errors: {}};

    const credentials = this.authForm.value;
    this.authService
      .signUp(credentials)
      .subscribe(
        data => this.router.navigateByUrl('/'),
        err => {
          this.errors = err;
          this.isSubmitting = false;
        }
    );
  }
}
