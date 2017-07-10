import { CourseService } from './../../services/course.service';
import { Component, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {
  @Output() course: starks.Course;
  courses: starks.Course[];

  constructor(private courseService: CourseService, private router: Router) { }

  ngOnInit() {
    this.courseService.getAll().subscribe((courses: starks.Course[]) => {
      this.courses = courses;
    });
  }

  add() {
    this.router.navigate(['courses/add']);
  }
  edit() {

  }
  details() {
    this.router.navigate(['course/details']);
  }
}
