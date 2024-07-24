import { Component } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent {
  constructor(public accountService: AccountService, public router: Router){
    if(this.accountService.isLoggedIn){
      this.accountService.logout();
      localStorage.removeItem("token");
    }
    this.router.navigateByUrl("");
  }
} 
