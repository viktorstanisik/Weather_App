import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model:any ={};
  invalidEmailOrPassword = '';
  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }
  login(){
    this.accountService.login(this.model).subscribe(response =>{
    console.log(response);
     this.router.navigateByUrl('getweather')
     
    },error => {
      if(error.message = "Incorrect email or password!!") {
        this.invalidEmailOrPassword = error.message
      } 
      

      console.log(error);
    })
  }
  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
