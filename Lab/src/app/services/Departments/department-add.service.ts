import { Injectable } from '@angular/core';
import { DepartmentsListService } from './departments-list.service';
import { Department } from '../../Models/Department';
import swal from 'sweetalert2';
import { HttpClient } from '@angular/common/http';
import { BaseDataService } from '../base-data.service';
@Injectable({
  providedIn: 'root'
})
export class DepartmentAddService {
  constructor(public listService: DepartmentsListService, public httpClient: HttpClient, private baseData: BaseDataService) { }
  baseAddress = this.baseData.baseAddress + "DepartmentsTemp";
  departments: Department[] | null = this.listService.departments;
  Add(dept: Department): boolean{
    if(dept.name.trim() == "" || dept.numberOfStudents <= 0){
      swal.fire({
        title: 'error',
        text: 'Plz Enter Valid Data!',
        icon: 'error',
        confirmButtonText: 'Ok'
      });
      return false;
    }
    this.httpClient.post(`${this.baseAddress}?deptname=${dept.name}&numberOfStds=${dept.numberOfStudents}`, null).subscribe();
    // this.departments?.push(new Department(dept.id, dept.name, dept.numberOfStudents));
    return true;
  }
  // getNextId():number{
  //   return this.departments?[this.departments?.length - 1]
  // }
}
