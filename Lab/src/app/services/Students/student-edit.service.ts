import { Injectable } from '@angular/core';
import { StudentsListService } from './students-list.service';
import { Student } from '../../Models/Student';
import swal from 'sweetalert2';
import { HttpClient } from '@angular/common/http';
import { BaseDataService } from '../base-data.service';

@Injectable({
  providedIn: 'root'
})
export class StudentEditService {

  constructor(public listService: StudentsListService, private httpClient: HttpClient, private baseData: BaseDataService) { }
  Students: Student[] | null = this.listService.Students;
  baseAddress = this.baseData.baseAddress + "StudentsTemp/";
  Edit(stdEdit: Student) : boolean{
    if(stdEdit.name.trim() == "" || stdEdit.trackName.trim() == ""){
      swal.fire({
        title: 'error',
        text: 'Plz Enter Valid Data!',
        icon: 'error',
        confirmButtonText: 'Ok'
      });
      return false;
    };
    this.httpClient.put(this.baseAddress + stdEdit.id, {id: stdEdit.id, name: stdEdit.name, trackName: stdEdit.trackName}).subscribe();
    return true;
  }
}
