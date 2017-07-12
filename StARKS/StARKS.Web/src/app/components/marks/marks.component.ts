import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { MarksService } from './../../services/marks.service';
import { StudentService } from './../../services/student.service';

@Component({
  selector: 'marks',
  templateUrl: './marks.component.html',
  styleUrls: ['./marks.component.css']
})
export class MarksComponent implements OnInit {

  marks: starks.Mark[];
  student: starks.Student;

  constructor(private studentService: StudentService, private marksService: MarksService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let studentId = + this.route.snapshot.params['studentId'];
    this.studentService.get(studentId).subscribe((student: starks.Student) => {
      this.student = student;

      this.marksService.getAll(studentId).subscribe((marks: starks.Mark[]) => {
        this.marks = marks;
      });
    });
  }

  add() {
    this.router.navigate(['students', this.student.id, 'marks', 'add']);
  }

  edit(mark: starks.Mark) {
    this.router.navigate(['students', this.student.id, 'marks', 'course', mark.courseCode]);
  }

  delete(mark: starks.Mark) {
    if (confirm('Are you sure you want to delete this mark?')) {
      this.marksService.delete(mark.studentId, mark.courseCode).subscribe(() => {
        alert('Mark deleted');
        this.marks = this.marks.filter((m: starks.Mark) => m.courseCode != mark.courseCode);
      });
    }
  }

}
