import { CourseService } from './../../services/course.service';
import { Component, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

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

  edit(course: starks.Course) {
    this.router.navigate(['courses/edit', course.code]);
  }

  delete(course: starks.Course) {
    if (confirm('Are you sure you want to delete this course?')) {
      this.courseService.delete(course.code).subscribe(() => {
        alert('Course deleted');
        this.courses = this.courses.filter((c: starks.Course) => c.code != course.code);
      });

    }
  }
}
