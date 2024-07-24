import { Component, Injectable } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DepartmentsComponent } from './departments/departments.component';
import { StudentsComponent } from './students/students.component';
import { HeaderComponent } from './core/header/header.component';
import { FooterComponent } from './core/footer/footer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DepartmentsComponent, StudentsComponent, 
    HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Project-Angular';
  @Injectable({providedIn: 'root', useValue: "https://localhost:7020/api/"})
  baseUrl:string = "";
}
