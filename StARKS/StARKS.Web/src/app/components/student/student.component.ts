import { StudentService } from './../../services/student.service';
import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {

  student: starks.Student = {} as starks.Student;

  constructor(private studentService: StudentService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let studentId = + this.route.snapshot.params['id'];
    if (studentId) {
      this.studentService.get(studentId).subscribe((student: starks.Student) => {
        this.student = student;
      });
    }
  }

  add() {
    this.studentService.add(this.student).subscribe((student: starks.Student) => {
      alert('Student added!');
      this.back();
    });
  }

  update() {
    this.studentService.update(this.student).subscribe(() => {
      alert('Student updated!');
      this.back();
    });
  }

  back() {
    this.router.navigate(['students']);
  }
}
