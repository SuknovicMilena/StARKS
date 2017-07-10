import { StudentComponent } from './components/student/student.component';
import { CourseComponent } from './components/course/course.component';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing';
import { CoursesComponent } from './components/courses/courses.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { MarksComponent } from './components/marks/marks.component';
import { StudentsComponent } from './components/students/students.component';
import { CourseService } from './services/course.service';
import { MarksService } from './services/marks.service';
import { StudentService } from './services/student.service';

@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    AppRoutingModule

  ],
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    StudentsComponent,
    CoursesComponent,
    MarksComponent,
    CourseComponent,
    StudentComponent,
  ],
  providers: [
    CourseService,
    MarksService,
    StudentService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
