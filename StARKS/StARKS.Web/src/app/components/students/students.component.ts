import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { StudentService } from './../../services/student.service';

@Component({
  selector: 'students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  students: starks.Student[];

  constructor(private studentService: StudentService, private router: Router) { }

  ngOnInit() {
    this.studentService.getAll().subscribe((students: starks.Student[]) => {
      this.students = students;
    });
  }

  add() {
    this.router.navigate(['students/add']);
  }

  edit(student: starks.Student) {
    this.router.navigate(['students/edit', student.id]);
  }

  delete(student: starks.Student) {
    if (confirm('Are you sure you want to delete this student?')) {
      this.studentService.delete(student.id).subscribe(() => {
        alert('Student deleted');
        this.students = this.students.filter((s: starks.Student) => s.id != student.id);
      });
    }
  }

}
