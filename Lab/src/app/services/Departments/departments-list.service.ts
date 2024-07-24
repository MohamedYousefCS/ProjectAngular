import { Injectable, OnInit } from '@angular/core';
import { Department } from '../../Models/Department';
import { HttpClient, HttpContext } from '@angular/common/http';
import { BaseDataService } from '../base-data.service';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsListService implements OnInit{
  baseUrl: string = this.baseData.baseAddress + "DepartmentsTemp";
  departments:Department[] | null = null; 
  constructor(public httpClient: HttpClient, public baseData: BaseDataService) { }
  ngOnInit(): void {
  }
  getAll(){
    return this.httpClient.get<Department[]>(this.baseUrl);
  }
  getById(id: number){
    return this.httpClient.get<Department>(`${this.baseUrl}/${id}`);
  }
  deleteByID(id:number){
    return this.httpClient.delete(`${this.baseUrl}/${id}`);
  }
}
