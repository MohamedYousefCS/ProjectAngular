import { Injectable, OnInit } from '@angular/core';
import { StudentsListService } from './students-list.service';
import { Student } from '../../Models/Student';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class OperationsStudentService implements OnInit {

  constructor(public listService: StudentsListService, private httpClient: HttpClient) { }

  Students: Student[] | null = this.listService.Students;
  baseUrl: string = this.listService.baseUrl;
  isEdit:boolean = false;

  ngOnInit(): void {
  }
  Remove(std:Student){
    this.httpClient.delete(this.baseUrl + std.id).subscribe();
  }
  getStudentById(id: number){
    return this.httpClient.get<Student>(this.baseUrl + id);
  }
}
