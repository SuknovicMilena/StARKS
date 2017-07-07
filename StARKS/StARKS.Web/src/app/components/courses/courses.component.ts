import { CourseService } from './../../services/course.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  courses: starks.Course[];

  constructor(private courseService: CourseService) { }

  ngOnInit() {
    this.courseService.getAll().subscribe((courses: starks.Course[]) => {
      this.courses = courses;
    });
  }

  edit() {

  }
}
