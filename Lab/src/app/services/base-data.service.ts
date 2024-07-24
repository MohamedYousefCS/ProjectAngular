import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseDataService {

  baseAddress: string = "https://localhost:7020/api/";
  constructor() { }
}