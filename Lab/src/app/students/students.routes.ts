import { Routes } from "@angular/router";
import { AddComponent } from "./add/add.component";
import { EditComponent } from "./edit/edit.component";
import { StudentsComponent } from "./students.component";

export const StudentRoutes:Routes = [
    {path: "", component: StudentsComponent},
    {path: "add", component: AddComponent},
    {path: "edit/:id", component: EditComponent},
]