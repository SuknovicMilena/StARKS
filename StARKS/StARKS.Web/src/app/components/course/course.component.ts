import { CourseService } from './../../services/course.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent {

  course: starks.Course;
  courses: starks.Course[];
  constructor(private courseService: CourseService, private router: Router) { }

  saveCourse(): void {
    this.courseService.saveCourse(this.course).subscribe((course: starks.Course) => {
      this.router.navigate(['/courses']);
    });
  }

  back() {
    this.router.navigate(['courses']);
  }

  edit() {

  }
}
