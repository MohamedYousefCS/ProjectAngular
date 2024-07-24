import { Injectable, OnInit } from '@angular/core';
import { Student } from '../../Models/Student';
import { HttpClient } from '@angular/common/http';
import { BaseDataService } from '../base-data.service';

@Injectable({
  providedIn: 'root'
})
export class StudentsListService implements OnInit {

  constructor(private httpClient: HttpClient, public baseData: BaseDataService) { }
  baseUrl: string = this.baseData.baseAddress + "StudentsTemp";
  Students:Student[] | null = null;
  ngOnInit(): void {
  }
  getAll(){
    return this.httpClient.get<Student[]>(this.baseUrl);
  }
  getById(id: number){
    return this.httpClient.get<Student>(`${this.baseUrl}/${id}`);
  }
  deleteByID(id:number){
    return this.httpClient.delete(`${this.baseUrl}/${id}`);
  }
}
