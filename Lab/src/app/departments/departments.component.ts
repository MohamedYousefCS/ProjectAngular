import { Component, OnInit } from '@angular/core';
import { Department } from '../Models/Department';
import { Student } from '../Models/Student';
import { FormsModule } from '@angular/forms';
import { DepartmentsListService } from '../services/Departments/departments-list.service';
import { OperationsDepartmentService } from '../services/Departments/operations-department.service';
import { DepartmentEditService } from '../services/Departments/department-edit.service';
import { EditComponent } from './edit/edit.component';
import { AddComponent } from './add/add.component';
import { DetailsComponent } from './details/details.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-departments',
  standalone: true,
  imports: [FormsModule, EditComponent, AddComponent, DetailsComponent, RouterLink],
  templateUrl: './departments.component.html',
  styleUrl: './departments.component.css'
})
export class DepartmentsComponent implements OnInit{
  isEdit: boolean = false;
  departments:Department[] | null = null;
  constructor(public service: OperationsDepartmentService, public editService: DepartmentEditService, 
    public listService: DepartmentsListService){
  }
  ngOnInit(): void {
    this.listService.getAll().subscribe(d => this.departments = d);
  }
  deptEdit: Department = new Department(-1, "", 10);
  detailsId: number = -1;
  Edit(input: Department){
    this.isEdit = true;
    // this.service.edit();
  }
  BindData(dept: Department){
    this.deptEdit = dept;
  }
  Details(id: number){
    if(id == this.detailsId)
      this.detailsId = -1;
    else
      this.detailsId = id;
  }
  delete(dept: Department){
    this.listService.deleteByID(dept.id).subscribe();
  }
}
