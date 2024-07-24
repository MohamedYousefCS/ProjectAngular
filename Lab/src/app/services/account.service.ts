import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { BaseDataService } from './base-data.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService implements OnInit{
  isLoggedIn = false;
  baseAddress = "";
  constructor(public httpClient: HttpClient, public baseData: BaseDataService) { }
  ngOnInit(): void {
    this.baseAddress = this.baseData.baseAddress;
  }


  login(email: string, password: string):Observable<string>{
    return this.httpClient.get(`${this.baseAddress}username=${email}&password=${password}`, {responseType: 'text'});
  }
  logout(){
    this.isLoggedIn = false;
  }
}
