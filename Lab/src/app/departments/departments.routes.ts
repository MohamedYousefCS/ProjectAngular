import { Routes } from "@angular/router";
import { DepartmentsComponent } from "./departments.component";
import { AddComponent } from "./add/add.component";
import { EditComponent } from "./edit/edit.component";

export const DepartmentsRoutes:Routes =[
    {path: "", component: DepartmentsComponent},
    {path: "add", component:AddComponent},
    {path: "edit/:id", component: EditComponent},
]