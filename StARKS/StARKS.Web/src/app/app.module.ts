
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { StudentsComponent } from './components/students/students.component';
import { CoursesComponent } from './components/courses/courses.component';
import { StudentService } from './services/student.service';
import { MarkService } from './services/mark.service';
import { CourseService } from './services/course.service';
import { AppRoutingModule } from './app.routing';

@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    AppRoutingModule,
  ],
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    StudentsComponent,
    CoursesComponent
  ],
  providers: [
    CourseService,
    MarkService,
    StudentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
