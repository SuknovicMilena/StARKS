import { CourseService } from './../../services/course.service';
import { Component } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent {

  course: starks.Course = {} as starks.Course;

  constructor(private courseService: CourseService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let courseId = + this.route.snapshot.params['code'];
    if (courseId) {
      this.courseService.get(courseId).subscribe((course: starks.Course) => {
        this.course = course;
      });
    }
  }

  add() {
    this.courseService.add(this.course).subscribe((course: starks.Course) => {
      alert('Course added!');
      this.back();
    });
  }
  update() {
    this.courseService.update(this.course).subscribe(() => {
      alert('Course updated!');
      this.back();
    });
  }

  back() {
    this.router.navigate(['courses']);
  }

}
