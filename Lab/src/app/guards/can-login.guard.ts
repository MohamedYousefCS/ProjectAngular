import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../services/account.service';

export const canLoginGuard: CanActivateFn = (route, state) => {
  const loginservice = inject(AccountService);
  const router = inject(Router);
  if(localStorage.getItem('token'))
    loginservice.isLoggedIn = true;
  if(loginservice.isLoggedIn){
    return true;

  }
  router.navigateByUrl("/login");
  return false;
};
