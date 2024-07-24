import { Injectable } from '@angular/core';
import { StudentsListService } from './students-list.service';
import { Student } from '../../Models/Student';
import swal from 'sweetalert2';
import { HttpClient } from '@angular/common/http';
import { BaseDataService } from '../base-data.service';
@Injectable({
  providedIn: 'root'
})
export class StudentAddService {
  constructor(public listService: StudentsListService, public httpClient: HttpClient, private baseData: BaseDataService) { }
  Students: Student[] | null = this.listService.Students;
  Add(std: Student) : boolean{
    if(std.name.trim() == "" || std.trackName.trim() == ""){
      swal.fire({
        title: 'error',
        text: 'Plz Enter value',
        icon: 'error',
        confirmButtonText: 'Ok'
      });
      return false;
    }
    this.httpClient.post(this.baseData.baseAddress + "StudentsTemp?name=" + std.name + "&trackName=" + std.trackName, null).subscribe();
    // this.Students.push(new Student(std.id, std.name, std.trackName));
    return true;
  }
  // getNextId():number{
  //   return this.Students[this.Students.length - 1].id + 1;
  // }
}
