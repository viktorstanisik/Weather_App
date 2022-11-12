import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  constructor(private accountService: AccountService, private router: Router) {}
  emailAlredyExist = '';

  ngOnInit(): void {}
  register() {
    this.accountService.register(this.model).subscribe(
      (response) => {
        console.log(response);
        this.cancel();
      },
      (error) => {
        if ((error.message = 'User Already Exist!!')) {
          this.emailAlredyExist = error.message;
          setTimeout(() => {
            this.router.navigateByUrl('/');
          }, 2000);
        }
        console.log(error);
      }
    );
    this.emailAlredyExist = '';
  }

  cancel() {
    this.router.navigateByUrl('/');

    this.cancelRegister.emit(false);
  }
}

// emailCheckUnique() {
//   this.ss.emailCheckUnique(this.registerForm.controls['s_email'].value).subscribe(res => {
//     this.studentEmailcheck = res;
//     if (this.studentEmailcheck.length > 0) {
//       this.emailAlredyExist = "Email Alredy Exist";
//     }
//     else{
//       this.emailAlredyExist = "";
//     }
//   });
//   }
