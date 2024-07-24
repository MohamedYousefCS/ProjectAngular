import { Component, Input } from '@angular/core';
import { Student } from '../../Models/Student';
import { FormsModule } from '@angular/forms';
import { StudentAddService } from '../../services/Students/student-add.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css'
})
export class AddComponent {
  constructor(public service: StudentAddService, public router: Router){}
  std:Student = new Student(-1, "", "");
  Add(){
    let status = this.service.Add(this.std);
    if(status)
      this.router.navigateByUrl("/students");
  }
}
