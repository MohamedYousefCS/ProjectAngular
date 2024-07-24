import { Injectable, OnInit } from '@angular/core';
import { Department } from '../../Models/Department';
import { DepartmentsListService } from './departments-list.service';
import swal from 'sweetalert2';
import { HttpClient, HttpContext } from '@angular/common/http';
import { BaseDataService } from '../base-data.service';

@Injectable({
  providedIn: 'root'
})
export class OperationsDepartmentService implements OnInit {

  baseUrl = this.baseData.baseAddress + "Departments/";
  constructor(public listService: DepartmentsListService, private httpClient: HttpClient, private baseData: BaseDataService){}
  ngOnInit(): void {
  }
  deptInput: Department = new Department(1, "", 1);
  isEdit:boolean = false;
  departments:Department[] | null = this.listService.departments;
  
  Remove(depart:Department){
    this.httpClient.delete(this.baseUrl + depart.id).subscribe();
    // this.departments?.splice(this.departments.indexOf(depart), 1)
  }
  GetDeptById(id: number){
      return this.httpClient.get<Department>(this.baseUrl + id);
  }
}
