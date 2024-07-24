import { Routes } from '@angular/router';
import { StudentsComponent } from './students/students.component';
import { AddComponent } from './students/add/add.component';
import { HomeComponent } from './home/home.component';
import { EditComponent } from './students/edit/edit.component';
import { DepartmentsComponent } from './departments/departments.component';
import { AddComponent as DAddComponent } from './departments/add/add.component';
import { EditComponent as DEditComponent } from './departments/edit/edit.component';
import { ContactComponent } from './core/contact/contact.component';
import { AboutComponent } from './core/about/about.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoginComponent } from './login/login.component';
import { canLoginGuard } from './guards/can-login.guard';
import { LogoutComponent } from './logout/logout.component';

export const routes: Routes = [
    {path: "", redirectTo:"home", pathMatch: 'full'},
    {path: "login", component: LoginComponent},
    {path: "logout", component: LogoutComponent},
    {path: "home", component: HomeComponent},
    {path: "students", loadChildren: ()=>
        import("./students/students.routes").then(m => m.StudentRoutes),
        canActivate: [canLoginGuard]
    },
    {path: "departments", loadChildren: ()=> 
        import("./departments/departments.routes").then(m => m.DepartmentsRoutes),
        canActivate: [canLoginGuard]
    },

    {path: "contact", component:ContactComponent},
    {path: "about", component: AboutComponent},
    {path: "**", component: NotFoundComponent}
];
