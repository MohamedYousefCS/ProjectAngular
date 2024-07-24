import { Component, OnInit } from '@angular/core';
import { StudentEditService } from '../../services/Students/student-edit.service';
import { Student } from '../../Models/Student';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OperationsStudentService } from '../../services/Students/operations-student.service';
import { StudentsListService } from '../../services/Students/students-list.service';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit{
  constructor(public service: StudentEditService,public details: StudentsListService , 
    public activatedRoute: ActivatedRoute, public router: Router){}
  ngOnInit(): void {
    this.details.getById(this.activatedRoute.snapshot.params['id']).subscribe(d => this.std = d);
  }
  std:Student | null = null;
  Edit(name: string, trackName: string){
    let status = this.service.Edit(new Student(this.activatedRoute.snapshot.params['id'], name, trackName));
    if(status)
      this.router.navigateByUrl("students");
  }
}
