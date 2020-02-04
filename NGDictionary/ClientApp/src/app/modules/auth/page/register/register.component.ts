import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  authForm: FormGroup;

  constructor(
    private fb: FormBuilder
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

}
