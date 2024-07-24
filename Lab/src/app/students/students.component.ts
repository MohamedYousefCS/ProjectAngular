import { Component, Input } from '@angular/core';
import { Student } from '../Models/Student';
import { FormsModule } from '@angular/forms';
import { OperationsStudentService } from '../services/Students/operations-student.service';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { StudentEditService } from '../services/Students/student-edit.service';
import { DetailsComponent } from './details/details.component';
import { RouterLink } from '@angular/router';
import { StudentsListService } from '../services/Students/students-list.service';

@Component({
    selector: 'app-students',
    standalone: true,
    templateUrl: './students.component.html',
    styleUrl: './students.component.css',
    imports: [FormsModule, AddComponent, EditComponent, DetailsComponent, RouterLink]
})
export class StudentsComponent {
  isEdit: boolean = false;
  constructor(public service: OperationsStudentService, public editService: StudentEditService,
    public listService: StudentsListService
  ){}
  stdEdit: Student = new Student(-1, "", "");
  detailsId: number = -1;

  Edit(input: Student){
    this.isEdit = true;
    // this.service.edit();
  }
  BindData(std: Student){
    this.stdEdit = std;
  }
  Details(id: number){
    if(id == this.detailsId)
      this.detailsId = -1;
    else
      this.detailsId = id;
    // this.detailsId = this.detailsId == -1 ? id : -1;
  }
  delete(std: Student){
    this.listService.deleteByID(std.id).subscribe();
  }
}