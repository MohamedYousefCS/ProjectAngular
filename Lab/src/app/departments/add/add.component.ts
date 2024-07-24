import { Component } from '@angular/core';
import { DepartmentAddService } from '../../services/Departments/department-add.service';
import { Department } from '../../Models/Department';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css'
})
export class AddComponent {

  constructor(public service: DepartmentAddService, public router: Router){}
  dept:Department = new Department(-1, "", 0);
  Add(){
    let status = this.service.Add(this.dept);
    if(status)
      this.router.navigateByUrl("/departments");
  }
}
