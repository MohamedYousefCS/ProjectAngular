import { Component } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(public accountService: AccountService, public router: Router){}
  invalidLogin:boolean = false;
  login(email: string, password: string){
    if(!this.accountService.isLoggedIn){
      this.accountService.login(email, password).subscribe({next: d => {
        localStorage.setItem("token", d);
        this.accountService.isLoggedIn = true;
        this.router.navigateByUrl("");
        this.invalidLogin = false;
      }, error: e => {
        this.invalidLogin = true;
      }});
    }
    else{
      this.router.navigateByUrl("");
    }
  }
}
