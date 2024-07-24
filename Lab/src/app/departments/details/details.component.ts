import { Component, Input, OnInit } from '@angular/core';
import { Department } from '../../Models/Department';
import { Observable } from 'rxjs';
import { DepartmentsListService } from '../../services/Departments/departments-list.service';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent implements OnInit{

  constructor(public detailsService: DepartmentsListService){}
  deptDetails: Department | null = null;
  ngOnInit(): void {
    if(this.deptId != -1)
      this.detailsService.getById(this.deptId).subscribe(d => this.deptDetails = d);
  }
  @Input({required: true})
  deptId: number = -1;
}
