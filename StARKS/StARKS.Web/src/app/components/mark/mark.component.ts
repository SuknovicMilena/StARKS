import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { MarksService } from './../../services/marks.service';
import { StudentService } from './../../services/student.service';

@Component({
  selector: 'mark',
  templateUrl: './mark.component.html',
  styleUrls: ['./mark.component.css']
})
export class MarkComponent {
  mark: starks.Mark = {} as starks.Mark;
  courses: starks.Course[];
  editingExisting: boolean;

  constructor(private marksService: MarksService, private studentService: StudentService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let studentId = + this.route.snapshot.params['studentId'];
    this.mark.studentId = studentId;

    let courseCode = this.route.snapshot.params['courseCode'];
    if (courseCode) {
      this.marksService.get(studentId, +courseCode).subscribe((mark: starks.Mark) => {
        this.mark = mark;
        this.editingExisting = true;
      });
    }
    else {
      this.studentService.getAvailableCourses(studentId).subscribe((courses: starks.Course[]) => {
        this.courses = courses;
      });
    }
  }

  add() {
    this.marksService.add(this.mark).subscribe((mark: starks.Mark) => {
      alert('Mark added!');
      this.back();
    });
  }

  update() {
    this.marksService.update(this.mark).subscribe(() => {
      alert('Mark updated!');
      this.back();
    });
  }

  back() {
    this.router.navigate(['students', this.mark.studentId, 'marks']);
  }
}
