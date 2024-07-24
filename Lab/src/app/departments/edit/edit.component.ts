import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DepartmentEditService } from '../../services/Departments/department-edit.service';
import { Department } from '../../Models/Department';
import { ActivatedRoute, Router } from '@angular/router';
import { OperationsDepartmentService } from '../../services/Departments/operations-department.service';
import { DepartmentsListService } from '../../services/Departments/departments-list.service';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit{
  constructor(public service: DepartmentEditService, public router:Router, public details: DepartmentsListService, 
    public activatedRoute: ActivatedRoute){}

  ngOnInit(): void {
    this.details.getById(this.activatedRoute.snapshot.params['id']).subscribe(d => this.dept = d);
  }
  dept:Department | null = null;
  Edit(name: string, num: number){
    let status = this.service.Edit(new Department(this.activatedRoute.snapshot.params['id'], name, num));
    if(status)
      this.router.navigateByUrl("departments");
  }
}
