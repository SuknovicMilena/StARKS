import { MarkComponent } from './components/mark/mark.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseComponent } from './components/course/course.component';
import { CoursesComponent } from './components/courses/courses.component';
import { MarksComponent } from './components/marks/marks.component';
import { StudentComponent } from './components/student/student.component';
import { StudentsComponent } from './components/students/students.component';

const routes: Routes = [
  { path: '', redirectTo: 'students', pathMatch: 'full' },
  { path: 'students', component: StudentsComponent },
  { path: 'students/add', component: StudentComponent },
  { path: 'students/edit/:id', component: StudentComponent },
  { path: 'courses', component: CoursesComponent },
  { path: 'courses/add', component: CourseComponent },
  { path: 'courses/edit/:code', component: CourseComponent },
  { path: 'students/:studentId/marks', component: MarksComponent },
  { path: 'students/:studentId/marks/add', component: MarkComponent },
  { path: 'students/:studentId/marks/course/:courseCode', component: MarkComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
