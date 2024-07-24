import { Injectable } from '@angular/core';
import { DepartmentsListService } from './departments-list.service';
import { Department } from '../../Models/Department';
import swal from 'sweetalert2';
import { HttpClient } from '@angular/common/http';
import { BaseDataService } from '../base-data.service';


@Injectable({
  providedIn: 'root'
})
export class DepartmentEditService {
  constructor(public listService: DepartmentsListService, public httpClient: HttpClient, private baseData: BaseDataService) { }
  departments: Department[] | null = this.listService.departments;
  baseAddress = this.baseData.baseAddress + "DepartmentsTemp/";
  Edit(deptEdit: Department): boolean{
    if(deptEdit.name.trim() == "" || deptEdit.numberOfStudents < 0){
      swal.fire({
        title: 'error',
        text: 'Plz Enter Valid Data!',
        icon: 'error',
        confirmButtonText: 'Ok'
      });
      return false;
    }
      this.httpClient.put(this.baseAddress + deptEdit.id, {id: deptEdit.id, name: deptEdit.name, numberOfStudents: deptEdit.numberOfStudents}).subscribe();
      // let editedOne = this.departments?.find(d=> d.id == deptEdit.id);
      // if(!editedOne) return false;
      // editedOne.name = deptEdit.name;
      // editedOne.numberOfStudents = deptEdit.numberOfStudents;
      return true;
  }
}
