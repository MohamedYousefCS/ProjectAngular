import { Component, Input, OnInit } from '@angular/core';
import { Student } from '../../Models/Student';
import { StudentsListService } from '../../services/Students/students-list.service';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent implements OnInit{
  constructor(public detailsService: StudentsListService){}
  stdDetails: Student | null = null;
  ngOnInit(): void {
    this.detailsService.getById(this.studentId).subscribe(d => this.stdDetails = d);
  }
  @Input({required: true})
  studentId: number = -1;
}
